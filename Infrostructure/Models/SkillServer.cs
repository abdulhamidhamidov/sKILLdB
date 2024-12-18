using System.Net;
using Dapper;
using DefaultNamespace;

namespace Infrostructure.Response;

public class SkillServer(DapperConText conText): ISkillServer
{
    public async Task<Response<bool>> Create(Skill skill)
    {
        using var connection = conText.Connection();
        var sql = "insert into Skills(UserId, Title, Description) values (@UserId, @Title, @Description);";
        var res = await connection.ExecuteAsync(sql,skill);
        if (res > 0) return new Response<bool>(res!=0);
        else
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
        }
    }

    public async Task<Response<List<Skill>>> GetAll()
    {
        using var connection = conText.Connection();
        var sql = "select * from Skills;";
        var res = (await connection.QueryAsync<Skill>(sql)).ToList();
        return new Response<List<Skill>>(res);
    }

    public async Task<Response<Skill>> GetById(int id)
    {
        using var connection = conText.Connection();
        var sql = "select * from Skills where Id=@Id;";
        var res = await connection.QuerySingleAsync<Skill>(sql,new {Id=id});
        if (res !=null) return new Response<Skill>(res);
        else
        {
            return new Response<Skill>(HttpStatusCode.NotFound, "Not Found");
        }  
    }

    public async Task<Response<bool>> Update(Skill skill)
    {
        using var connection = conText.Connection();
        var sql = "update Skills set UserId=@UserId, Title=@Title, Description=@Description where Id=@Id;";
        var res = await connection.ExecuteAsync(sql,skill);
        if (res > 0) return new Response<bool>(res!=0);
        else
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
        }       
    }

    public async Task<Response<bool>> Delete(int id)
    {
        using var connection = conText.Connection();
        var sql = "delete from Skills where Id=@Id;";
        var res = await connection.ExecuteAsync(sql,new {Id=id});
        if (res > 0) return new Response<bool>(res!=0);
        else
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
        }   
    }
}