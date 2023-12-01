using OfficeMaintanenceCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMaintanenceRepository.InterFaces
{
    public interface IGetUserProcess
    {
        Task<List<SystemDetailsModel>> GetSystemDetails();
        Task<List<TicketModel>> GetTicketDetails();
    }
}
