using MediatR;
using OfficeMaintanenceCommon.Model;
using OfficeMaintanenceLogic.Command;
using OfficeMaintanenceRepository.InterFaces;
using OfficeMaintanenceRepository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMaintanenceLogic.Handler
{
    public class SystemDetailsHandler : IRequestHandler<SystemDetailsCommand, ResponseMessage>
    {
        private readonly IUserProcess _userProcess;
        public SystemDetailsHandler(IUserProcess userProcess)
        {
            _userProcess = userProcess;
        }
        public async Task<ResponseMessage> Handle(SystemDetailsCommand request, CancellationToken cancellationToken)
        {
            var systemDetailsEntity = new SystemDetailsModel
            {
                Id = request.Id,
                Name = request.Name,
                SystemNumber = request.SystemNumber,
                IPAddress = request.IPAddress,
                SystemName = request.SystemName,
                Ram = request.Ram,
                Processor = request.Processor,
                OSType = request.OSType,
            };
            return await _userProcess.createsystem(systemDetailsEntity);
        }
    }
}
