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
    public class UsersProcessRepo : IUserProcess
    {
        private readonly MaintanenceDbContext _dbContext;
        public UsersProcessRepo(MaintanenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseMessage> createsystem(SystemDetailsModel systemDetail)
        {
            try
            {
                _dbContext.SystemDetails.Add(systemDetail);
                await _dbContext.SaveChangesAsync();

                return ResponseMessage.New(ResponseCode.OK, "Success");
            }
            catch (Exception ex)
            {
                return new ResponseMessage(ResponseCode.BadRequest, $"Internal Server Error: {ex.Message}");
            }
        }

        public async Task<ResponseMessage> CreateTicket(TicketModel ticketData)
        {
            try
            {
                _dbContext.Tickets.Add(ticketData);
                await _dbContext.SaveChangesAsync();

                return ResponseMessage.New(ResponseCode.OK, "Success");
            }
            catch (Exception ex)
            {
                return new ResponseMessage(ResponseCode.BadRequest, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
