using Homework1.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            return Ok(StaticDb.Users);
        }


        [HttpGet("{index}")]
        public ActionResult<string> GetByIndex(int index)
        {
            try
            {
                if (index < 0)
                {
                    return BadRequest("The index has negative value");
                }
                if (index >= StaticDb.Users.Count)
                {
                    return NotFound("The User was not found");
                }

                return Ok(StaticDb.Users[index]);
            }
            catch (Exception ex)
            {
                
                 return StatusCode(StatusCodes.Status500InternalServerError, "An error occured. Please contact your administrator");
                
            }
        }
    }

  
    
        
    
}
