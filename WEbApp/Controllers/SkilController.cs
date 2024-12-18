using DefaultNamespace;
using Infrostructure.Response;
using Microsoft.AspNetCore.Mvc;

namespace WEbApp.Controllers;
[ApiController]
[Route("[controller]")]
public class SkilController(ISkillServer skillServer): ControllerBase
{
    [HttpPost]
    async Task<Response<bool>> Create(Skill skill)
    {
        return await skillServer.Create(skill);
    }
    [HttpGet]
    async Task<Response<List<Skill>>> GetAll()
    {
        return await skillServer.GetAll();
    }
    [HttpGet("/get-by-id")]
    async Task<Response<Skill>> GetById(int id)
    {
        return await skillServer.GetById(id);
    }
    [HttpPut]
    async Task<Response<bool>> Update(Skill skill)
    {
        return await skillServer.Update(skill);
    }
    [HttpDelete]
    async Task<Response<bool>> Delete(int id)
    {
        return await skillServer.Delete(id);
    }   
}