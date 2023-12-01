using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeMaintanenceCommon.Model;
using OfficeMaintanenceLogic.Command;
using OfficeMaintanenceLogic.Query;

namespace OfficeMaintanence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Register")]
        public async Task<AddUserModel> AddStudentAsync([FromForm]AddUserModels EmployeeDetails)
        {
            var studentDetail = await _mediator.Send(new UserRegisterCommand(
               // EmployeeDetails.Emp_Id,
                EmployeeDetails.Firstname,
                EmployeeDetails.Lastname,
                EmployeeDetails.Email,
                EmployeeDetails.PassWord,
                EmployeeDetails.Mobilenumber,
                EmployeeDetails.DOB,
                EmployeeDetails.Address,
                EmployeeDetails.Role,
                EmployeeDetails.ImageFilePath
                ));
            return studentDetail;
        }

        [HttpPost("Login")]
        public async Task<ResponseMessage> LoginCandidate(LoginModel LoginDetails)
        {
            var CandidateDetail = await _mediator.Send(new UserLoginCommand(
                       LoginDetails.Email,
                       LoginDetails.Password
                       ));
            return CandidateDetail;
        }

        [HttpPost("UserGetById")]
        public async Task<AddUserModel> GetById(int id)
        {
            var CandidateDetail = await _mediator.Send(new GetByUserIdQuery(id));
            return CandidateDetail;
        }
    }
}
