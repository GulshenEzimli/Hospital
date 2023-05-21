using DocumentFormat.OpenXml.Wordprocessing;
using HospitalManagement.Models.Interfaces;
using HospitalManagement.Utils;
using HospitalManagementCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models.Implementations
{
    public class OtherEmployeeModel : IControlModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int No { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PIN { get; set; }
        public JobModel Job { get; set; }
        public decimal Salary { get; set; }
        public Gender Gender { get; set; }
        public IControlModel Clone()
        {
            return new OtherEmployeeModel()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                Email = Email,
                PIN = PIN,
                Job = (JobModel)Job.Clone(),
                Salary = Salary,
                BirthDate = BirthDate,
                No = No,
                Gender = Gender,
            };
        }
        public bool IsCompatibleWithFilter(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return true;

            string lowerSearchText = searchText.ToLower();

            if (FirstName?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (LastName?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (BirthDate.ToString(SystemConstants.DateDisplayFormat).Contains(lowerSearchText))
                return true;

            if (PIN?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (Gender.ToString()?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (Salary.ToString().Contains(lowerSearchText))
                return true;

            if (PhoneNumber?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (Email?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (Job.IsCompatibleWithFilter(lowerSearchText))
                return true;

            return false;           
        }
    }
}
