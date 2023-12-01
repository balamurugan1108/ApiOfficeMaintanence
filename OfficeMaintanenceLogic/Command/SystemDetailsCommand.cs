using MediatR;
using OfficeMaintanenceCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMaintanenceLogic.Command
{
    public class SystemDetailsCommand : IRequest<ResponseMessage>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SystemNumber { get; set; }
        public string IPAddress { get; set; }
        public string SystemName { get; set; }
        public string Ram { get; set; }
        public string Processor { get; set; }
        public string OSType { get; set; }

        public SystemDetailsCommand(int id, string name, int systemNumber, string ipAddress, string systemName, string ram, string processor,string osType )
        {
            Id = id;
            Name = name;
            SystemNumber = systemNumber;
            IPAddress = ipAddress;
            SystemName = systemName;
            Ram = ram;
            Processor = processor;
            OSType = osType;
        }
    }
}
