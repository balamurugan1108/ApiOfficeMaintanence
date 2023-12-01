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
    public class GetUserDetailsRepo : IGetUserDetail
    {
        private readonly MaintanenceDbContext _dbContext;
        public GetUserDetailsRepo(MaintanenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<UserDataViewModel>> GetUser()
        {
            var userDataView = await _dbContext.userRegisterDatas
                .Select(item => new UserDataViewModel
                {
                    //Emp_Id = item.Emp_Id,
                    Address = item.Address,
                    Email = item.Email,
                    DOB = item.DOB,
                    Firstname = item.Firstname,
                    Lastname = item.Lastname,
                    ImageFilePath = item.ImageFilePath,
                    Mobilenumber = item.Mobilenumber,
                    Role = item.Role,
                }).ToListAsync();

            return userDataView;
        }

    }
}
