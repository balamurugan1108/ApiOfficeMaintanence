using MediatR;
using OfficeMaintanenceCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMaintanenceLogic.Command
{
    public class TicketCreateCommand:IRequest<ResponseMessage>
    {

       // public string TicketNO { get; set; }
        public string Name { get; set; }
        public string IpAdress { get; set; }
        public string Command { get; set; }
        public DateTime CreateBy { get; set; }
        public string Priority { get; set; }

        public TicketCreateCommand(  string name, string ipAddress, string command, DateTime createBy, string priority)
        {
            //TicketNO = ticketNO;
            Name = name;
            IpAdress = ipAddress;
            Command = command;
            CreateBy = createBy;
            Priority = priority;
        }
    }
}
