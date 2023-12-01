using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeMaintanenceCommon.Model;
using OfficeMaintanenceLogic.Command;
using OfficeMaintanenceLogic.Query;

namespace OfficeMaintanence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allUser = await _mediator.Send(new GetAllUserQuery());
            return Ok(allUser);
        }

        [HttpPost("SystemDetails")]
        public async Task<IActionResult> CreateSystemDetails(SystemDetailsModel systemDetails)
        {
            var allUser = await _mediator.Send(new SystemDetailsCommand(
                systemDetails.Id,
                systemDetails.Name,
                systemDetails.SystemNumber,
                systemDetails.IPAddress,
                systemDetails.SystemName,
                systemDetails.Ram,
                systemDetails.Processor,
                systemDetails.OSType));
            return Ok(allUser);
        }

        [HttpPost("CreateTicket")]
        public async Task<IActionResult> CreateTicket(TicketModel ticketModel)
        {
            var creat = await _mediator.Send(new TicketCreateCommand(
             // ticketModel.TicketNO,
              ticketModel.Name,
              ticketModel.IpAddress,
              ticketModel.Priority,
              ticketModel.CreateBy,
              ticketModel.Command));
            return Ok(creat);
        }

        [HttpGet("GetSystemDetails")]
        public async Task<IActionResult> GetSystemDetails()
        {
            var allUser = await _mediator.Send(new GetSystemDetailsQuery());
            return Ok(allUser);
        }

        [HttpGet("GetTicketDetails")]
        public async Task<IActionResult> GetTicketDetails()
        {
            var TicketData = await _mediator.Send(new GetTicketDetailsQuery());
            return Ok(TicketData);
        }
    }
}
