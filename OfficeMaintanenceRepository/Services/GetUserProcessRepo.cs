using Microsoft.EntityFrameworkCore;
using OfficeMaintanenceCommon.Helper;
using OfficeMaintanenceCommon.Model;
using OfficeMaintanenceRepository.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMaintanenceRepository.Services
{
    public class GetUserProcessRepo:IGetUserProcess
    {
        private readonly MaintanenceDbContext _dbContext;
        public GetUserProcessRepo(MaintanenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<SystemDetailsModel>> GetSystemDetails()
        {
            var userDataView = await _dbContext.SystemDetails
                .Select(item => new SystemDetailsModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    SystemNumber = item.SystemNumber,
                    IPAddress = item.IPAddress,
                    SystemName = item.SystemName,
                    Ram = item.Ram,
                    Processor = item.Processor,
                    OSType = item.OSType,
                }).ToListAsync();

            return userDataView;
        }

        public async Task<List<TicketModel>> GetTicketDetails()
        {
            var TicketData = await _dbContext.Tickets.ToListAsync();
            return TicketData;
        }
    }
}
