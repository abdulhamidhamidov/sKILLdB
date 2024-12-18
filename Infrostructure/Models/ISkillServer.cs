using DefaultNamespace;

namespace Infrostructure.Response;

public interface ISkillServer
{
    Task<Response<bool>> Create(Skill skill);
    Task<Response<List<Skill>>> GetAll();
    Task<Response<Skill>> GetById(int id);
    Task<Response<bool>>  Update(Skill skill);
    Task<Response<bool>>  Delete(int id);
}