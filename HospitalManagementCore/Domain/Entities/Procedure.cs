using HospitalManagementCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementCore.Domain.Entities
{
    public class Procedure:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public bool IsDelete { get; set; }
    }
}
