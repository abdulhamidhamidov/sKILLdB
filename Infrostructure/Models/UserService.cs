using System.Net;
using Dapper;
using Infrostructure.Response;

namespace DefaultNamespace;

public class UserService(DapperConText conText): IUserService
{
    public async Task<Response<bool>> Create(User user)
    {
        using var connection = conText.Connection();
        var sql = "insert into Users(fullname, email, phone, city) values (@FullName, @Email, @Phone, @City);";
        var res = await connection.ExecuteAsync(sql,user);
        if (res > 0) return new Response<bool>(res!=0);
        else
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
        }
    }

    public async Task<Response<List<User>>> GetAll()
    {
        using var connection = conText.Connection();
        var sql = "select * from Users;";
        var res = (await connection.QueryAsync<User>(sql)).ToList();
        return new Response<List<User>>(res);
    }

    public async Task<Response<User>> GetById(int id)
    {
        using var connection = conText.Connection();
        var sql = "select * from Users where Id=@Id;";
        var res = await connection.QuerySingleAsync<User>(sql,new {Id=id});
        if (res !=null) return new Response<User>(res);
        else
        {
            return new Response<User>(HttpStatusCode.NotFound, "Not Found");
        }
    }

    public async Task<Response<bool>> Update(User user)
    {
        using var connection = conText.Connection();
        var sql = "update Users set @FullName=fullname, @Email=email, @Phone=phone, @City=city where Id=@Id;\n";
        var res = await connection.ExecuteAsync(sql,user);
        if (res > 0) return new Response<bool>(res!=0);
        else
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
        }    
    }

    public async Task<Response<bool>> Delete(int id)
    {
        using var connection = conText.Connection();
        var sql = "delete from Users where Id=@Id;";
        var res = await connection.ExecuteAsync(sql,new {Id=id});
        if (res > 0) return new Response<bool>(res!=0);
        else
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
        }      
    }
}