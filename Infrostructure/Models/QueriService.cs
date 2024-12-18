using Dapper;
using DefaultNamespace;
using Infrostructure.Response;

namespace Infrostructure.Models;

public class QueriService(DapperConText conText): IQueriService
{
    public async Task<Response<List<User>>> GetByTitle(string title)
    {
        using var connection = conText.Connection();
        var sql = "select u.id,u.fullname, u.email, u.phone, u.city from Users u join Skills s on u.UserId = S.Id where s.Title=@Title";
        var res = (await connection.QueryAsync<User>(sql)).ToList();
        return new Response<List<User>>(res);
    }
    
}