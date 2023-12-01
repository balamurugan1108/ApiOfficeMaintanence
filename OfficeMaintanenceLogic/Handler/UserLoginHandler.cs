using MediatR;
using OfficeMaintanenceCommon.Model;
using OfficeMaintanenceLogic.Command;
using OfficeMaintanenceRepository.InterFaces;

namespace OfficeMaintanenceLogic.Handler
{
    public class UserLoginHandler : IRequestHandler<UserLoginCommand, ResponseMessage>
    {
        private readonly IUserRegister _userRegister;
        public UserLoginHandler(IUserRegister userRegister)
        {
            _userRegister = userRegister;
        }


        public async Task<ResponseMessage> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var LoginDatas = new LoginModel()
            {
                Email = request.Email,
                Password = request.Password,
            };
            return await _userRegister.Login(LoginDatas);
        }
    }
}
