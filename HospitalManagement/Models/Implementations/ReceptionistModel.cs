﻿using HospitalManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class ReceptionistModel : IControlModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int No { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PIN { get; set; }
        public string JobName { get; set; }
        public string DepartmentName { get; set; }
        public decimal Salary { get; set; }
        private bool[] _gender = { false, false };
        public bool[] Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public string GenderValue
        {
            get
            {
                return _gender[0] ? "Kişi" : "Qadın";
            }
        }

        public ReceptionistModel Clone()
        {
            return new ReceptionistModel()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                BirthDate = BirthDate,
                PhoneNumber = PhoneNumber,
                Email = Email,
                PIN = PIN,
                JobName = JobName,
                DepartmentName = DepartmentName,
                Salary = Salary,
                Gender = Gender,

            };
        }

    }
}