using HospitalManagement.Attributes;
using HospitalManagementCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class NurseModel
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
        
        public NurseModel Clone()
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
                Position = Position,
                DepartmentName = DepartmentName,
                Salary = Salary,
                Gender = Gender,
            };
        }
    }
}
