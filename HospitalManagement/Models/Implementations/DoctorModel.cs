using DocumentFormat.OpenXml.Wordprocessing;
using HospitalManagement.Attributes;
using HospitalManagement.Models.Interfaces;
using HospitalManagement.Validations.Utils;
using HospitalManagementCore.Domain.Entities;
using HospitalManagementCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models.Implementations
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
        public IControlModel Clone()
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
                Position = (PositionModel)Position.Clone(),
                Salary = Salary,
                No = No,
                Gender = Gender,
                IsChiefDoctor = IsChiefDoctor
            };
        }

       

        public bool IsCompatibleWithFilter(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return true;

            string lowerSearchText = searchText.ToLower();

            if (BirthDate.ToString(SystemConstants.DateDisplayFormat).Contains(lowerSearchText))
                return true;
            if (DepartmentName?.ToLower().Contains(lowerSearchText) == true)
                return true;
            if (Email?.ToLower().Contains(lowerSearchText) == true)
                return true;
            if (FirstName?.ToLower().Contains(lowerSearchText) == true)
                return true;
            if (LastName?.ToLower().Contains(lowerSearchText) == true)
                return true;
            if (Phonenumber?.ToLower().Contains(lowerSearchText) == true)
                return true;
            if (PIN?.ToLower().Contains(lowerSearchText) == true)
                return true;
            if (Position.ICompatibleWithFilter(lowerSearchText))
                return true;
            if (Salary.ToString()?.ToLower().Contains(lowerSearchText) == true)
                return true;
            if (Gender.ToString()?.ToLower().Contains(lowerSearchText) == true)
                return true;
            if (IsChiefDoctor.ToString()?.ToLower().Contains(lowerSearchText) == true)
                return true;
            return false;
        }
    }
}
