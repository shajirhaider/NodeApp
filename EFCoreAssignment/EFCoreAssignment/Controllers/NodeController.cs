using EFCoreAssignment.DataAccess;
using EFCoreAssignment.Models;
using EFCoreAssignment.Models.DTOs;
using EFCoreAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;
        public NodeController(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("getNodeList")]
        public async Task<ActionResult<ResponseModel<IEnumerable<Node>>>> GetNodeList()
        {
            var allNodes = await _applicationDbContext.Nodes.ToListAsync();

            return Ok(CustomResponseMessage.OkCustom("Query successful.", allNodes));

        }



        [HttpPost]
        [Route("upsertNode")]
        public async Task<ActionResult<ResponseModel<Node>>> UpsertNode([FromBody] NodeRequestDto nodeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(CustomResponseMessage.ErrorCustom("Bad Request", "Invalid request parameters?"));

            }
            Node? _node;



            try
            {
                if (nodeDto.NodeId.HasValue && nodeDto.NodeId > 0)
                {
                    _node = await _applicationDbContext.Nodes.FindAsync(nodeDto.NodeId.Value);
                    if (_node == null)
                    {
                        return NotFound(CustomResponseMessage.ErrorCustom("Error", "Node not found."));
                    }

                    _node.NodeName = nodeDto.NodeName;
                    _node.Alias = nodeDto.Alias;
                    _node.Aggregate = nodeDto.Aggregate;
                    _node.NodeType = nodeDto.NodeType;
                    _node.NodeSubType = nodeDto.NodeSubType;
                    _node.SlaId = nodeDto.SlaId;
                    _node.TaskType = nodeDto.TaskType;
                    _node.EmailTemplateId = nodeDto.EmailTemplateId;
                    _node.Shifting = nodeDto.Shifting;
                    _node.ProcessDuration = nodeDto.ProcessDuration;
                    _node.ContactId = nodeDto.ContactId;
                    _node.ContactCCId = nodeDto.ContactCCId;
                    _node.Player = nodeDto.Player;


                    _applicationDbContext.Nodes.Update(_node);
                }
                else
                {
                    _node = new Node
                    {
                        NodeName = nodeDto.NodeName,
                        Alias = nodeDto.Alias,
                        Aggregate = nodeDto.Aggregate,
                        NodeType = nodeDto.NodeType,
                        NodeSubType = nodeDto.NodeSubType,
                        SlaId = nodeDto.SlaId,
                        TaskType = nodeDto.TaskType,
                        EmailTemplateId = nodeDto.EmailTemplateId,
                        Shifting = nodeDto.Shifting,
                        ProcessDuration = nodeDto.ProcessDuration,
                        ContactId = nodeDto.ContactId,
                        ContactCCId = nodeDto.ContactCCId,
                        Player = nodeDto.Player,
                        LifeInsuranceClass = "default",
                        PeriodicFormat = "default",
                        PeriodicFormatStartDate = DateTime.UtcNow,
                        TransactionFormat = "default",
                        TransactionFormatStartDate = DateTime.UtcNow,

                    };
                    await _applicationDbContext.Nodes.AddAsync(_node);
                }

                await _applicationDbContext.SaveChangesAsync();
                return Ok(CustomResponseMessage.OkCustom("Action successful.", _node));
            }
            catch (Exception ex)
            {
                return StatusCode(500, CustomResponseMessage.ErrorCustom("Error", "An error occurred while saving the Node. Please try again later." + ex.Message));
            }

        }

        [HttpDelete]
        [Route("deleteNode/{emailTemplateId}")]
        public async Task<ActionResult<ResponseModel<string>>> DeleteNode(int emailTemplateId)
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
                //delete _node

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
