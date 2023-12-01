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
    public class GetSystemDetailsHandler : IRequestHandler<GetSystemDetailsQuery, List<SystemDetailsModel>>
    {
        private readonly IGetUserProcess _getUser;
        public GetSystemDetailsHandler(IGetUserProcess getUser)
        {
            _getUser = getUser;
        }
        public async Task<List<SystemDetailsModel>> Handle(GetSystemDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _getUser.GetSystemDetails();
        }
    }
}
