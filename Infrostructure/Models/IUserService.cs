using Infrostructure.Response;

namespace DefaultNamespace;

public interface IUserService
{
    Task<Response<bool>> Create(User user);
    Task<Response<List<User>>> GetAll();
    Task<Response<User>> GetById(int id);
    Task<Response<bool>>  Update(User user);
    Task<Response<bool>>  Delete(int id);
}