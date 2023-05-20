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
    public class PatientModel : IControlModel
    {
        [ExcelIgnore]
        public int Id { get; set; }
        [ExcelIgnore]
        public bool IsDelete { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string PIN { get; set; }

        [ExcelColumn("Phone number")]
        public string PhoneNumber { get; set; }

        public string DisplayPatient => $"{Name} {Surname} {PIN}";
        public Gender Gender { get; set; }

        public IControlModel Clone()
        {
            return new PatientModel()
            {
                No = No,
                Id = Id,
                Name = Name,
                Surname = Surname,
                BirthDate = BirthDate,
                PIN = PIN,
                PhoneNumber = PhoneNumber,
                Gender= Gender,
            };
        }
        public bool IsCompatibleWithFilter(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return true;

            string lowerSearchText = searchText.ToLower();

            if (Name?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (Surname?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (BirthDate.ToString(SystemConstants.DateDisplayFormat).Contains(lowerSearchText))
                return true;

            if (Gender.ToString().ToLower().Contains(lowerSearchText))
                return true;

            if (PIN?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (PhoneNumber?.ToLower().Contains(lowerSearchText) == true)
                return true;

            return false;            
        }
    }
}
    

