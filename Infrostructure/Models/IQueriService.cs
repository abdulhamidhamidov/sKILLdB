using DefaultNamespace;
using Infrostructure.Response;

namespace Infrostructure.Models;

public interface IQueriService
{
    Task<Response<List<User>>> GetByTitle(string title);
}