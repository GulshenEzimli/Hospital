﻿using HospitalManagementCore.Domain.Enums;
using HospitalManagementCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementCore.Domain.Entities
{
    public class Nurse : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PIN { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Salary { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatorId => Creator?.Id ?? 0;
        public int ModifierId => Modifier?.Id ?? 0;
        public int PositionId => Position?.Id ?? 0;
        public Admin Creator { get; set; }
        public Admin Modifier { get; set; }
        public DoctorPosition Position { get; set; }

    }
}
