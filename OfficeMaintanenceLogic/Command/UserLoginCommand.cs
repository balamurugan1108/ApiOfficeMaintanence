using MediatR;
using OfficeMaintanenceCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMaintanenceLogic.Command
{
    public class UserLoginCommand: IRequest<ResponseMessage>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public UserLoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
