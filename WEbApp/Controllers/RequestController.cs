using DefaultNamespace;
using Infrostructure.Models;
using Infrostructure.Response;
using Microsoft.AspNetCore.Mvc;

namespace WEbApp.Controllers;

[ApiController]
[Route("[controller]")]
public class RequestController(IRequestService requestService): ControllerBase
{
    [HttpPost]
    public async Task<Response<bool>> Create(Request request)
    {
        return await requestService.Create(request);
    }
    [HttpGet]
    public async Task<Response<List<Request>>> GetAll()
    {
        return await requestService.GetAll();
    }
    [HttpGet("/get-by-id")]
    public async Task<Response<Request>> GetById(int id)
    {
        return await requestService.GetById(id);
    }
    [HttpPut]
    public async Task<Response<bool>> Update(Request request)
    {
        return await requestService.Update(request);
    }
    [HttpDelete]
    public async Task<Response<bool>> Delete(int id)
    {
        return await requestService.Delete(id);
    }   
}