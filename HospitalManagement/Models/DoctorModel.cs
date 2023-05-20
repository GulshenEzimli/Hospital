using HospitalManagement.Attributes;
using HospitalManagement.Models.Interfaces;
using HospitalManagementCore.Domain.Entities;
using HospitalManagementCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class DoctorModel : IControlModel
    {
        [ExcelIgnore]
        public int Id { get; set; }
        public int No { get; set; }
        public PositionModel Position { get; set; }

        [ExcelColumn("Department")]
        public string DepartmentName { get; set; }

        [ExcelColumn("Name")]
        public string FirstName { get; set; }

        [ExcelColumn("Surname")]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        [ExcelColumn("Date of Birth")]
        public DateTime BirthDate { get; set; }
        public string PIN { get; set; }
        public string Email { get; set; }

        [ExcelColumn("Phone number")]
        public string Phonenumber { get; set; }
        public decimal Salary { get; set; }

        [ExcelIgnore]
        public bool IsChiefDoctor { get; set; }

        [ExcelColumn("Rank of doctor")]
        public string IsChiefDoctorValue
        {
            get
            {
                return IsChiefDoctor ? "Baş həkim" : "Həkim";
            }
        }

        [ExcelIgnore]
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
