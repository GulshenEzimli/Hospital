using HospitalManagementCore.Domain.Entities;
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
        public PositionModel Position { get; set; }        
        public string DepartmentName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

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
        public DateTime BirthDate { get; set; }
        public string PIN { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public decimal Salary { get; set; }

        private bool[] _isChiefDoctor = { false, false };
        public bool[] IsChiefDoctor
        {
            get { return _isChiefDoctor; }
            set { _isChiefDoctor= value; }
        }
        public string IsChiefDoctorValue
        {
            get
            {
                return IsChiefDoctor[0] ? "Baş həkim" : "Həkim";
            }
        }

        public string DisplayDoctor => $"{FirstName} {LastName} {PIN}";
        public DoctorModel Clone()
        {
            return new DoctorModel()
            {
                BirthDate = BirthDate,
                DepartmentName = DepartmentName,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                Id = Id,
                Phonenumber = Phonenumber,
                PIN = PIN,
                Position = Position,
                Salary = Salary,
                No = No,
                Gender = Gender,
                IsChiefDoctor = IsChiefDoctor
            };
        }
    }
}
