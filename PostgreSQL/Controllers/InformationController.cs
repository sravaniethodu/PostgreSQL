using Microsoft.AspNetCore.Mvc;
using PostgreSQL.DataEntities.Models;
using PostgreSQL.DataEntities.ViewModels;
using PostgreSQL.DataLayer.Interfaces;

namespace PostgreSQL.Controllers;
[Route("api/[controller]")]
[ApiController]
public class InformationController : ControllerBase
{
    public readonly IPostgreSQLDataLayer dataLayer;

    public InformationController(IPostgreSQLDataLayer dataLayer)
    {
        this.dataLayer = dataLayer;
    }
    /// <summary>
    /// Finds the unique record using the id
    /// </summary>
    /// <param name="id">Id used to identify the tuple</param>
    /// <returns>Information pertaining to id</returns>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> FindById(int id)
    {
        try
        {
            Information info = await dataLayer.FindById(id);
            if (info == null)
            {
                throw new NullReferenceException();
            }
            return Ok(info);
        }
        catch (NullReferenceException ex)
        {
            return Problem(statusCode: 400, title: $"Info not found {ex.Message}", detail: $"The Database does not contain info with id - {id}");
        }
        catch (Exception ex)
        {
            return Problem(statusCode: 400, title: ex.Message, detail: ex.StackTrace);
        }
    }
    /// <summary>
    /// Fetches all the entries from the db
    /// </summary>
    /// <returns>A list containing all entries</returns>
    [HttpGet("AllInfo")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var allInfo = await dataLayer.GetAll();
            if (allInfo == null)
            {
                throw new NullReferenceException();
            }
            return Ok(allInfo);
        }
        catch (NullReferenceException ex)
        {
            return Problem(statusCode: 400, title: $"Info not found {ex.Message}", detail: $"The Database does not contain info");
        }
        catch (Exception ex)
        {
            return Problem(statusCode: 400, title: ex.Message, detail: ex.StackTrace);
        }
    }
    /// <summary>
    /// Inserts to the information table
    /// </summary>
    /// <param name="info"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Add(InformationViewModel information)
    {
        try
        {
            if (information == null)
            {
                throw new NullReferenceException();
            }

            await dataLayer.Add(information);
            return Ok(information);
        }
        catch (NullReferenceException ex)
        {
            return Problem(statusCode: 400, title: $"Info not added {ex.Message}", detail: "The Database not updated");
        }
        catch (Exception ex)
        {
            return Problem(statusCode: 400, title: ex.Message, detail: ex.StackTrace);
        }
    }
    /// <summary>
    /// Updates the information in the db 
    /// </summary>
    /// <param name="information">Info that is to be updated</param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Update(Information information)
    {
        try
        {
            if (information == null)
            {
                throw new NullReferenceException();
            }
            await dataLayer.Update(information);
            return Ok(information);
        }
        catch (NullReferenceException ex)
        {
            return Problem(statusCode: 400, title: $"Info not updated {ex.Message}", detail: $"The Database isn't updated");
        }
        catch (Exception ex)
        {
            return Problem(statusCode: 400, title: ex.Message, detail: ex.StackTrace);
        }
    }
    /// <summary>
    /// Deletes entry based on id from information table 
    /// </summary>
    /// <param name="id">id to uniquely identify the tuple</param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await dataLayer.Delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return Problem(statusCode: 400, title: ex.Message, detail: ex.StackTrace);
        }
    }
}
