
using Microsoft.EntityFrameworkCore;
using PostgreSQL.DataEntities.Models;
using PostgreSQL.Repository.Interfaces;

namespace PostgreSQL.Repository.Implementations;

public class PostgreSQLRepository : IPostgreSQLRepository
{
    private readonly TestContext _context;
    public PostgreSQLRepository(TestContext testContext)
    {
        this._context = testContext;
    }
    /// <summary>
    /// Inserts to the information table
    /// </summary>
    /// <param name="info"></param>
    /// <returns></returns>
    public async Task Add(Information info)
    {
        try
        {
            await _context.Information.AddAsync(info);
            await _context.SaveChangesAsync();
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
            Information? recordToDelete = await _context.Information.FirstOrDefaultAsync(t => t.Id == id);
            if (recordToDelete is null)
            {
                throw new NullReferenceException("Object is null.");
            }
            else
            {
                _context.Information.Remove(recordToDelete);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }

    }
    /// <summary>
    /// Finds the unique record using the id
    /// </summary>
    /// <param name="id">id is used to uniquely identify the tuple</param>
    /// <returns>the details of tuple fetched from the db</returns>
    public async Task<Information> FindById(int id)
    {
        try
        {
            Information? record = await _context.Information.FirstOrDefaultAsync(t => t.Id == id);
            if (record is null)
            {
                throw new NullReferenceException("Object is null.");
            }
            else
            {
                return record;
            }
        }
        catch (Exception)
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
            var allRecords = await _context.Information.ToListAsync();
            return allRecords;
        }
        catch (Exception)
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
            _context.Entry(info).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
