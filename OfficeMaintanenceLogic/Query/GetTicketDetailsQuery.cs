using MediatR;
using OfficeMaintanenceCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMaintanenceLogic.Query
{
    public class GetTicketDetailsQuery:IRequest<List<TicketModel>>
    {
    }
}
