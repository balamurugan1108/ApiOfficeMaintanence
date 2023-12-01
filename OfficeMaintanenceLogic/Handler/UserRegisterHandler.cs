using MediatR;
using OfficeMaintanenceCommon.Model;
using OfficeMaintanenceLogic.Command;
using OfficeMaintanenceRepository.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OfficeMaintanenceLogic.Handler
{
    public class UserRegisterHandler : IRequestHandler<UserRegisterCommand, AddUserModel>
    {
        private readonly IUserRegister _userRegister;
        public UserRegisterHandler(IUserRegister userRegister)
        {
            _userRegister = userRegister;
        }
        public async Task<AddUserModel> Handle(UserRegisterCommand command, CancellationToken cancellationToken)
        {
            var canditate = new AddUserModels()
            {

                //Emp_Id = command.Emp_Id,
                Firstname = command.Firstname,
                Lastname = command.Lastname,
                Email = command.Email,
                DOB = command.DateOfBirth,
                Mobilenumber = command.Mobilenumber,
                Role = command.Role,
                Address = command.Address,
                ImageFilePath = command.ImagePath,
                PassWord = command.PassWord,
            };
            return await _userRegister.userRegister(canditate);
        }
    }
}
