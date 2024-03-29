﻿using HospitalManagementCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementCore.Domain.Entities
{
    public class DoctorPosition : IEntity
    {
        public int Id { get; set ; }
        public string Name { get; set; }
        public int DepartmentId => Department?.Id ?? 0;
        public Department Department { get; set ; }
    }
}
