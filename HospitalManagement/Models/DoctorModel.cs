using HospitalManagementCore.Domain.Entities;
using HospitalManagementCore.Domain.Enums;
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

        public Gender Gender { get; set; }
        
        public DateTime BirthDate { get; set; }
        public string PIN { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public decimal Salary { get; set; }

        public bool IsChiefDoctor { get; set; }
        public string IsChiefDoctorValue
        {
            get
            {
                return IsChiefDoctor ? "Baş həkim" : "Həkim";
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
