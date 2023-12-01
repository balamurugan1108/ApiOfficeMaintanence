﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMaintanenceCommon.Model
{
    public class UserDataViewModel
    {
        [Key]
        //public int Emp_Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Mobilenumber { get; set; }
        public string DOB { get; set; }
        public string Address { get; set; }
        public string ImageFilePath { get; set; }
        public string Role { get; set; }
    }
}
