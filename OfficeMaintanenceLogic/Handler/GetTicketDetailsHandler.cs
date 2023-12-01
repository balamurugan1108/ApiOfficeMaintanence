using MediatR;
using OfficeMaintanenceCommon.Model;
using OfficeMaintanenceLogic.Query;
using OfficeMaintanenceRepository.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMaintanenceLogic.Handler
{
    public class GetTicketDetailsHandler : IRequestHandler<GetTicketDetailsQuery, List<TicketModel>>
    {
        private readonly IGetUserProcess _getUser;
        public GetTicketDetailsHandler(IGetUserProcess getUser)
        {
            _getUser = getUser;
        }

        public async Task<List<TicketModel>>Handle(GetTicketDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _getUser.GetTicketDetails();
        }
    }
}
