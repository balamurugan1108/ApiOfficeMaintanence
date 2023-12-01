using MediatR;
using Microsoft.AspNetCore.Http;
using OfficeMaintanenceCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMaintanenceLogic.Command
{
    public class UserRegisterCommand: IRequest<AddUserModel>
    {
        //public int Emp_Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string Mobilenumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public IFormFile ImagePath { get; set; }
        public UserRegisterCommand( string firstname, string lastname, string email, string passWord, string mobilenumber, string dateOfBirth, string address, string role, IFormFile imagePath)
        {
            //Emp_Id = emp_Id;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            PassWord = passWord;
            Mobilenumber = mobilenumber;
            DateOfBirth = dateOfBirth;
            Address = address;
            Role = role;
            ImagePath = imagePath;
        }
    }
}
