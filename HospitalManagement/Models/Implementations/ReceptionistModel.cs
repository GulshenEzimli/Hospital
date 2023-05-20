using DocumentFormat.OpenXml.Wordprocessing;
using HospitalManagement.Models.Interfaces;
using HospitalManagement.Validations.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models.Implementations
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

        public IControlModel Clone()
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

            if (PhoneNumber?.Contains(lowerSearchText) == true)
                return true;

            if (Email?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (PIN?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (JobName?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (DepartmentName?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (Salary.ToString().Contains(lowerSearchText))
                return true;

            if (GenderValue?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (DepartmentName?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (DepartmentName?.ToLower().Contains(lowerSearchText) == true)
                return true;

            return false;
        }

    }
}
