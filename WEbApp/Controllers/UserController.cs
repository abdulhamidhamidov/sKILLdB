using DefaultNamespace;
using Infrostructure.Response;
using Microsoft.AspNetCore.Mvc;

namespace WEbApp.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController(IUserService userService): ControllerBase
{
    [HttpPost]
    public async Task<Response<bool>> Create(User user)
    {
        return await userService.Create(user);
    }
    [HttpGet]
    public async Task<Response<List<User>>> GetAll()
    {
        return await userService.GetAll();
    }
    [HttpGet("/get-by-id")]
    public  async Task<Response<User>> GetById(int id)
    {
        return await userService.GetById(id);
    }
    [HttpPut]
    public async Task<Response<bool>> Update(User user)
    {
        return await userService.Update(user);
    }
    [HttpDelete]
    public  async Task<Response<bool>> Delete(int id)
    {
        return await userService.Delete(id);
    }
}