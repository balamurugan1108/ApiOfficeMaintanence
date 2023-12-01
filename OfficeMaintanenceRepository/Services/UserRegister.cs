using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OfficeMaintanenceCommon;
using OfficeMaintanenceCommon.Helper;
using OfficeMaintanenceCommon.Model;
using OfficeMaintanenceRepository.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMaintanenceRepository.Services
{
    public class UserRegister : IUserRegister
    {
        private readonly MaintanenceDbContext _context;
        private readonly IConfiguration _config;
        private readonly EmailSettings _emailSettings;
      
        public UserRegister(MaintanenceDbContext context, IConfiguration config, IOptions<EmailSettings> mailSettings)
        {
            _context = context;
            _config = config;
            _emailSettings = mailSettings.Value;
        }
        public async Task<ResponseMessage> Login(LoginModel emp)
        {
            GenerateJwtToken jwtToken = new GenerateJwtToken(_config);
            var logindata = await _context.userRegisterDatas.Where(a => a.Email == emp.Email && a.PassWord == emp.Password).FirstOrDefaultAsync();

            IOptions<EmailSettings> emailSettingsOptions = Options.Create(_emailSettings);

            EmailService emailService = new EmailService(emailSettingsOptions);

            if (logindata != null)
            {
                var data =
                new {
                    token= jwtToken.TockenGenarate(logindata),
                    id=logindata.Emp_Id,
                    username= logindata.Email, 
                    role= logindata.Role
                };
                emailService.SendEmailAsync(logindata);
                return ResponseMessage.New(ResponseCode.OK, data);
            }
            return ResponseMessage.New(ResponseCode.BadRequest, "Invalid credentials");
        }

        public async Task<AddUserModel> getbyId(int id)
        {
            var data = await _context.userRegisterDatas.Where(a => a.Emp_Id == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<AddUserModel> userRegister(AddUserModels emp)
        {

            try
            {
                if (emp.ImageFilePath == null || emp.ImageFilePath.Length == 0)
                {
                    return null;
                }

                string username = $"{emp.Firstname.ToLower()}{emp.Lastname.ToLower()}";
                string userFolderPath = Path.Combine("wwwroot", "images", username);

                if (!Directory.Exists(userFolderPath))
                {
                    Directory.CreateDirectory(userFolderPath);
                }


                string timestamp = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
                string uniqueFileName = $"{username}_{timestamp}{Path.GetExtension(emp.ImageFilePath.FileName)}";

                string imagePath = Path.Combine(userFolderPath, uniqueFileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await emp.ImageFilePath.CopyToAsync(stream);
                }

                AddUserModel dbvalu = new AddUserModel()
                {
                    //Emp_Id = emp.Emp_Id,
                    Firstname = emp.Firstname,
                    ImageFilePath = imagePath,
                    Address = emp.Address,
                    DOB = emp.DOB,
                    Email = emp.Email,
                    Lastname = emp.Lastname,
                    Mobilenumber = emp.Mobilenumber,
                    PassWord = emp.PassWord,
                    Role = emp.Role
                };

                var datas = _context.userRegisterDatas.Add(dbvalu);
                await _context.SaveChangesAsync();

                IOptions<EmailSettings> emailSettingsOptions = Options.Create(_emailSettings);

                EmailService emailService = new EmailService(emailSettingsOptions);
                emailService.SendEmailAsync(dbvalu);
                return datas.Entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving image: {ex.Message}");
                return null;
            }
        }
    }
}
