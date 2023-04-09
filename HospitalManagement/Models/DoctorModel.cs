﻿using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class DoctorModel
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string PositionName { get; set; }
        public string DepartmentName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PIN { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public decimal Salary { get; set; }
        public bool IsChiefDoctor { get; set; }
    }
}
