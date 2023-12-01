using OfficeMaintanenceCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMaintanenceRepository.InterFaces
{
    public interface IUserRegister
    {
        Task<AddUserModel> userRegister(AddUserModels emp);
        Task<ResponseMessage> Login(LoginModel emp);
        Task<AddUserModel> getbyId(int id);
    }
}
