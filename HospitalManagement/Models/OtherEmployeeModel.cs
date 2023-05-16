using HospitalManagementCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class OtherEmployeeModel
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
        public OtherEmployeeModel Clone()
        {
            return new OtherEmployeeModel()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                Email = Email,
                PIN = PIN,
                Job = Job,
                Salary = Salary,
                BirthDate = BirthDate,
                No = No,
                Gender = Gender,
            };
        }
    }
}
