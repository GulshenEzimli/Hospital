using HospitalManagementCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementCore.Domain.Entities
{
    public class Doctor : IEntity
    {
        public int Id { get; set; }
        public int PositionId { get; set; }
        public DoctorPosition Position { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PIN { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public decimal Salary { get; set; }
        public bool IsDelete { get; set; }
        public bool IsChiefDoctor { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatorId { get; set; }
        public int ModifierId { get; set; }
        public Admin Creator { get; set; }
        public Admin Modifier { get; set; }
    }
}
