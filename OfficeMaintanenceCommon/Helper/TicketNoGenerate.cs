using Microsoft.EntityFrameworkCore;
using OfficeMaintanenceCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMaintanenceCommon.Helper
{
    public class TicketNoGenerate
    {
        private readonly MaintanenceDbContext _context;

        public TicketNoGenerate(MaintanenceDbContext context)
        {
            _context = context;
        }

        public async Task<List<TicketModel>> GetAllUserData()
        {
            var data = await _context.Tickets.ToListAsync();
            return data;
        }

        public async Task<string> UserNameAsync()
        {
            var data = await GetAllUserData();

            int lastTwoDigits = data
                .Where(e => e.TicketNO.StartsWith("UDT"))
                .Select(e => int.Parse(e.TicketNO.Split('T').Last()))
                .DefaultIfEmpty(0)
                .Max();

            var userQuery = data
                .Where(u => u.TicketNO.StartsWith($"UDT{lastTwoDigits:000}"))
                .Select(u => u.TicketNO);

            var userIDs = userQuery.ToList();

            if (userIDs.Count == 0)
            {
                return $"UDT001";
            }

            var maxNumericPart = userIDs
                .Select(u => int.Parse(u.Split('T').Last()))
                .Max();

            string newUserId = $"UDT{(maxNumericPart + 1):000}";

            return newUserId;

        }

    }
}
