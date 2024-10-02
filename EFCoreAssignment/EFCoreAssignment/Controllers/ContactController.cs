using EFCoreAssignment.DataAccess;
using EFCoreAssignment.Models;
using EFCoreAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;
        public ContactController(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("getContactByPlayer")]
        public async Task<ActionResult<ResponseModel<IEnumerable<Contact>>>> GetContactByPlayer([FromQuery] string? name)
        {
            var filtered = await _applicationDbContext.Contacts.Where(contact => contact.Player.Equals(name)).ToListAsync();

            return Ok(CustomResponseMessage.OkCustom("Query successful.", filtered));

        }





    }
}
