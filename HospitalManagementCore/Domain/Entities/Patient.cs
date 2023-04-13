﻿using HospitalManagementCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementCore.Domain.Entities
{
    public class Patient : IEntity
    {
        public int Id { get ; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PIN { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatorId { get; set; }
        public int ModifierId { get; set; }
        public Admin Creator { get; set; }
        public Admin Modifier { get; set; }
    }
}