using DefaultNamespace;
using Infrostructure.Response;

using Domain;
namespace Infrostructure.Models;

public interface IRequestService
{
    Task<Response<bool>> Create(Request request);
    Task<Response<List<Request>>> GetAll();
    Task<Response<Request>> GetById(int id);
    Task<Response<bool>>  Update(Request request);
    Task<Response<bool>>  Delete(int id);
}