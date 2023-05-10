using HospitalManagementCore.Domain.Entities;
using HospitalManagementCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class PatientModel
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string PIN { get; set; }
        public string PhoneNumber { get; set; }
        public string DisplayPatient => $"{Name} {Surname} {PIN}";

        public bool IsDelete { get; set; }
        public Gender Gender { get; set; }

        public PatientModel Clone()
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
    }
}
    

