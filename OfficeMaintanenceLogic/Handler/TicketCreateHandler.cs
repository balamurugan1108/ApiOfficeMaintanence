using MediatR;
using OfficeMaintanenceCommon.Helper;
using OfficeMaintanenceCommon.Model;
using OfficeMaintanenceLogic.Command;
using OfficeMaintanenceRepository.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMaintanenceLogic.Handler
{
    public class TicketCreateHandler : IRequestHandler<TicketCreateCommand, ResponseMessage>
    {
        private readonly IUserProcess _userProcess;
        private readonly MaintanenceDbContext _context;
        public TicketCreateHandler(IUserProcess userProcess,MaintanenceDbContext context)
        {
            _userProcess = userProcess;
            _context = context;
        }
        public async Task<ResponseMessage> Handle(TicketCreateCommand request, CancellationToken cancellationToken)
        {
            TicketNoGenerate tic = new TicketNoGenerate(_context);

            var ticketData = new TicketModel
            {
                TicketNO = await tic.UserNameAsync(),
                Name = request.Name,
                IpAddress = request.IpAdress,
                Command = request.Command,
                CreateBy = request.CreateBy,
                Priority = request.Priority
            };

            
            var result = await _userProcess.CreateTicket(ticketData);
            return result;
        }
    }
}
