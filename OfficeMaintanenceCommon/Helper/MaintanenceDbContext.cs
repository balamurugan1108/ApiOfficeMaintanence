using Microsoft.EntityFrameworkCore;
using OfficeMaintanenceCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMaintanenceCommon.Helper
{
    public class MaintanenceDbContext: DbContext
    {
        public MaintanenceDbContext(DbContextOptions <MaintanenceDbContext> options):base(options) { }
        public DbSet<AddUserModel> userRegisterDatas { get; set; }
        public DbSet<SystemDetailsModel> SystemDetails { get; set; }
        public DbSet<TicketModel> Tickets { get; set; }
    }
}
