using DocumentFormat.OpenXml.Wordprocessing;
using HospitalManagement.Attributes;
using HospitalManagement.Models.Interfaces;
using HospitalManagement.Validations.Utils;
using HospitalManagementCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models.Implementations
{
    public class NurseModel : IControlModel
    {
        [ExcelIgnore]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public int No { get; set; }
        [ExcelColumn("Dat of birth")]
        public DateTime BirthDate { get; set; }
        [ExcelColumn("Phone Number")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PIN { get; set; }
        public PositionModel Position { get; set; }
        [ExcelColumn("Department")]
        public string DepartmentName { get; set; }
        public decimal Salary { get; set; }
        public Gender Gender { get; set; }
        [ExcelIgnore]
        public string DisplayNurse => $"{FirstName} {LastName} {PIN}";
        
        public IControlModel Clone()
        {
            return new NurseModel()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                BirthDate = BirthDate,
                PhoneNumber = PhoneNumber,
                Email = Email,
                PIN = PIN,
                Position = (PositionModel)Position.Clone(),
                DepartmentName = DepartmentName,
                Salary = Salary,
                Gender = Gender,
            };
        }
        public bool IsCompatibleWithFilter(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return true;

            string lowerSearchText = searchText.ToLower();

            if (BirthDate.ToString(SystemConstants.DateDisplayFormat).Contains(lowerSearchText)==true)
                return true;
            if (DepartmentName?.ToLower().Contains(lowerSearchText) == true)
                return true;
            if (Email?.ToLower().Contains(lowerSearchText) == true)
                return true;
            if (FirstName?.ToLower().Contains(lowerSearchText) == true)
                return true;
            if (LastName?.ToLower().Contains(lowerSearchText) == true)
                return true;
            if (PhoneNumber?.ToLower().Contains(lowerSearchText) == true)
                return true;
            if (PIN?.ToLower().Contains(lowerSearchText) == true)
                return true;
            if (Position.ICompatibleWithFilter(lowerSearchText))
                return true;
            if (Salary.ToString()?.ToLower().Contains(lowerSearchText) == true)
                return true;           
            if (Gender.ToString()?.ToLower().Contains(lowerSearchText) == true)
                return true;
            
            return false;
        }
    }
}
