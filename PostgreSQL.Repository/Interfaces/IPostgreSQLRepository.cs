using PostgreSQL.DataEntities.Models;

namespace PostgreSQL.Repository.Interfaces;

public interface IPostgreSQLRepository
{
    public Task<Information> FindById(int id);
    public Task<IEnumerable<Information>> GetAll();
    public Task Add(Information info);
    public Task Delete(int id);
    public Task Update(Information info);
}
