using DefaultNamespace;
using Infrostructure.Response;
using Microsoft.AspNetCore.Mvc;

namespace WEbApp.Controllers;
[ApiController]
[Route("[controller]")]
public class SkilController(ISkillServer skillServer): ControllerBase
{
    [HttpPost]
    public async Task<Response<bool>> Create(Skill skill)
    {
        return await skillServer.Create(skill);
    }
    [HttpGet]
    public async Task<Response<List<Skill>>> GetAll()
    {
        return await skillServer.GetAll();
    }
    [HttpGet("/get-by-id")]
    public async Task<Response<Skill>> GetById(int id)
    {
        return await skillServer.GetById(id);
    }
    [HttpPut]
    public async Task<Response<bool>> Update(Skill skill)
    {
        return await skillServer.Update(skill);
    }
    [HttpDelete]
    public async Task<Response<bool>> Delete(int id)
    {
        return await skillServer.Delete(id);
    }   
}