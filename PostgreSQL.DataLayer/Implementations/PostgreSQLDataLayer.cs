using AutoMapper;
using PostgreSQL.DataEntities.Models;
using PostgreSQL.DataEntities.ViewModels;
using PostgreSQL.DataLayer.Interfaces;
using PostgreSQL.Repository.Interfaces;

namespace PostgreSQL.DataLayer.Implementations
{
    public class PostgreSQLDataLayer : IPostgreSQLDataLayer
    {
        public readonly IPostgreSQLRepository repository;
        public readonly IMapper mapper;
        public PostgreSQLDataLayer(IPostgreSQLRepository repository, IMapper mapper) 
        { 
            this.repository = repository;
            this.mapper = mapper;
        }
        /// <summary>
        /// Inserts to the information table
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task Add(InformationViewModel info)
        {
            try
            {
                Information information = mapper.Map<Information>(info);
                await repository.Add(information);
            }
            catch (Exception)
            {
                throw;
            }
                
        }
        /// <summary>
        /// Deletes entry based on id from information table 
        /// </summary>
        /// <param name="id">id to uniquely identify the tuple</param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            try
            {
                await repository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Finds the unique record using the id
        /// </summary>
        /// <param name="id">Id used to identify the tuple</param>
        /// <returns>Information pertaining to id</returns>
        public async Task<Information> FindById(int id)
        {
            try
            {
                Information info = await repository.FindById(id);
                return info;
            }
            catch(Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Fetches all the entries from the db
        /// </summary>
        /// <returns>A list containing all entries</returns>
        public async Task<IEnumerable<Information>> GetAll()
        {
            try
            {
                var allEntries = await repository.GetAll();
                return allEntries;
            }
            catch(Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Updates the information in the db 
        /// </summary>
        /// <param name="info">Info that is to be updated</param>
        /// <returns></returns>
        public async Task Update(Information info)
        {
            try
            {
                await repository.Update(info);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
