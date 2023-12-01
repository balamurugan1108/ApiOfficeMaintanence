using OfficeMaintanenceCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMaintanenceRepository.InterFaces
{
    public interface IUserProcess
    {
        Task<ResponseMessage> createsystem(SystemDetailsModel systemDetail);
        Task<ResponseMessage> CreateTicket(TicketModel ticketData);
    }
}
