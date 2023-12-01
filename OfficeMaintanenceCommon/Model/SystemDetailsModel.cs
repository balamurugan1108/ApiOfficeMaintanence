using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMaintanenceCommon.Model
{
    public class SystemDetailsModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int SystemNumber { get; set; }
        public string IPAddress { get; set; }
        public string SystemName { get; set; }
        public string Ram { get; set; }
        public string Processor { get; set; }
        public string OSType { get; set; }

    }
}
