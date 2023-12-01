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
    public class GetAllUserDetailsHandler : IRequestHandler<GetAllUserQuery, List<UserDataViewModel>>
    {
        private readonly IGetUserDetail _getUser;
        public GetAllUserDetailsHandler(IGetUserDetail getUser)
        {
            _getUser = getUser;
        }
        public async Task<List<UserDataViewModel>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return await _getUser.GetUser();
        }
    }
}
