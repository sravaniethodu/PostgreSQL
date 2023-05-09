using PostgreSQL.DataEntities.ViewModels;
using PostgreSQL.DataEntities.Models;

namespace PostgreSQL.DataLayer.Interfaces;

public interface IPostgreSQLDataLayer
{
    public Task<Information> FindById(int id);
    public Task<IEnumerable<Information>> GetAll();
    public Task Add(InformationViewModel info);
    public Task Delete(int id);
    public Task Update(Information info);
}
