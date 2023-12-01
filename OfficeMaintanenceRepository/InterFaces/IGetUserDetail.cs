using OfficeMaintanenceCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMaintanenceRepository.InterFaces
{
    public interface IGetUserDetail
    {
        Task<List<UserDataViewModel>> GetUser();
    }
}
