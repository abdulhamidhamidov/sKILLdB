using Npgsql;
namespace DefaultNamespace;

public class DapperConText
{
   private string connectionString = "Server=localhost;Port=5432;Database=SkillDb;Username=postgres;Password=12345";

   public NpgsqlConnection Connection()
   {
      return new NpgsqlConnection(connectionString);
   }
}