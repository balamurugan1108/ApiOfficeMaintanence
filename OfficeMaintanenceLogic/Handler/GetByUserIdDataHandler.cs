using MediatR;
using OfficeMaintanenceCommon.Model;
using OfficeMaintanenceLogic.Query;
using OfficeMaintanenceRepository.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMaintanenceLogic.Handler
{
    public class GetByUserIdDataHandler: IRequestHandler<GetByUserIdQuery, AddUserModel>
    {
        private readonly IUserRegister _userRegister;
        public GetByUserIdDataHandler(IUserRegister userRegister)
        {
            _userRegister = userRegister;
        }
        public async Task<AddUserModel> Handle(GetByUserIdQuery request, CancellationToken cancellationToken)
        {
            int LoginDatas = request.Id;
            return await _userRegister.getbyId(LoginDatas);
        }
    }
}
