using EFCoreAssignment.DataAccess;
using EFCoreAssignment.Models;
using EFCoreAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailTemplateController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;
        public EmailTemplateController(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("getEmailTempList")]
        public async Task<ActionResult<ResponseModel<IEnumerable<EmailTemplate>>>> GetEmailTempList()
        {
            var allEmailTemplates = await _applicationDbContext.EmailTemplates.ToListAsync();

            return Ok(CustomResponseMessage.OkCustom("Query successful.", allEmailTemplates));

        }



        [HttpPost]
        [Route("upsertTemplate")]
        public async Task<ActionResult<ResponseModel<EmailTemplate>>> UpsertTemplate([FromBody] EmailTemplate emailTemplate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(CustomResponseMessage.ErrorCustom("Bad Request", "Invalid request parameters?"));

            }
            EmailTemplate? _emailTemplate;



            try
            {
                if (emailTemplate.EmailTemplateId.HasValue)
                {
                    _emailTemplate = await _applicationDbContext.EmailTemplates.FindAsync(emailTemplate.EmailTemplateId.Value);
                    if (_emailTemplate == null)
                    {
                        return NotFound(CustomResponseMessage.ErrorCustom("Error", "Template not found."));
                    }
                    _emailTemplate.EmailTemplateName = emailTemplate.EmailTemplateName;
                    _emailTemplate.EmailTemplateBody = emailTemplate.EmailTemplateBody;
                    _emailTemplate.EmailTemplateSubject = emailTemplate.EmailTemplateSubject;
                    _applicationDbContext.EmailTemplates.Update(_emailTemplate);
                }
                else
                {
                    _emailTemplate = new EmailTemplate
                    {
                        EmailTemplateName = emailTemplate.EmailTemplateName,
                        EmailTemplateBody = emailTemplate.EmailTemplateBody,
                        EmailTemplateSubject = emailTemplate.EmailTemplateSubject,
                    };
                    await _applicationDbContext.EmailTemplates.AddAsync(_emailTemplate);
                }

                await _applicationDbContext.SaveChangesAsync();
                return Ok(CustomResponseMessage.OkCustom("Action successful.", _emailTemplate));
            }
            catch (Exception ex)
            {
                return StatusCode(500, CustomResponseMessage.ErrorCustom("Error", "An error occurred while saving the Template. Please try again later."));
            }

        }

        [HttpDelete]
        [Route("deleteEmailTemp/{emailTemplateId}")]
        public async Task<ActionResult<ResponseModel<string>>> DeleteEmailTemp (int emailTemplateId)
        {
            if (emailTemplateId < 1)
            {
                return BadRequest(CustomResponseMessage.ErrorCustom("Bad Request", "Invalid request parameters?"));

            }
            try
            {
                var template = await _applicationDbContext.EmailTemplates.FindAsync(emailTemplateId);
                if (template == null)
                {
                    return NotFound(CustomResponseMessage.ErrorCustom("Error", "Template not found."));
                }
                //try to find a node
                var node = await _applicationDbContext.Nodes.Where(node => node.EmailTemplateId == emailTemplateId).FirstOrDefaultAsync();

                if (node != null)
                {
                    return StatusCode(StatusCodes.Status403Forbidden, CustomResponseMessage.ErrorCustom("Error", "Template has active node."));
                }
                //delete _emailTemplate

                _applicationDbContext.EmailTemplates.Remove(template);


                await _applicationDbContext.SaveChangesAsync();
                return Ok(CustomResponseMessage.OkCustom("Action successful.", "Template deleted"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, CustomResponseMessage.ErrorCustom("Error", "An error occurred while saving the Template. Please try again later."));
            }

        }


    }
}
