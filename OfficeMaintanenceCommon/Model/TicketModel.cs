using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMaintanenceCommon.Model
{
    public class TicketModel
    {
        [Key]
        public string TicketNO { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public string Command { get; set; }
        public DateTime CreateBy { get; set; }
        public string Priority { get; set; }
    }
}
