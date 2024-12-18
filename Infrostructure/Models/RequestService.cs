using System.Net;
using Dapper;
using DefaultNamespace;
using Infrostructure.Response;

namespace Infrostructure.Models;

public class RequestService(DapperConText conText): IRequestService
{
    public async Task<Response<bool>> Create(Request request)
    {
        using var connection = conText.Connection();
        var sql = "insert into Requests( fromuserid, touserid, requestedskillid, offeredskillid, status) values ( @FromUserId, @ToUserId, @RequestedSkillId, @OfferedSkillId, @Status);\n";
        var res = await connection.ExecuteAsync(sql,request);
        if (res > 0) return new Response<bool>(res!=0);
        else
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
        }
    }

    public async Task<Response<List<Request>>> GetAll()
    {
        using var connection = conText.Connection();
        var sql = "select * from Requests;";
        var res = (await connection.QueryAsync<Request>(sql)).ToList();
        return new Response<List<Request>>(res);
    }

    public async Task<Response<Request>> GetById(int id)
    {
        using var connection = conText.Connection();
        var sql = "select * from Requests where Id=@Id;;";
        var res = await connection.QuerySingleAsync<Request>(sql,new {Id=id});
        if (res !=null) return new Response<Request>(res);
        else
        {
            return new Response<Request>(HttpStatusCode.NotFound, "Not Found");
        }
    }

    public async Task<Response<bool>> Update(Request request)
    {
        using var connection = conText.Connection();
        var sql = "update Requests set FromUserId=@FromUserId,ToUserId=@ToUserId,RequestedSkillId=@RequestedSkillId,OfferedSkillId=@OfferedSkillId,Status=@Status where Id=@Id;\n";
        var res = await connection.ExecuteAsync(sql,request);
        if (res > 0) return new Response<bool>(res!=0);
        else
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
        }  
    }

    public async Task<Response<bool>> Delete(int id)
    {
        using var connection = conText.Connection();
        var sql = "delete from Requests where Id=@Id;";
        var res = await connection.ExecuteAsync(sql,new {Id=id});
        if (res > 0) return new Response<bool>(res!=0);
        else
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
        }
    }
}