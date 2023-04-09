using HospitalManagementCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementCore.Domain.Entities
{
    public class Admin : IEntity
    {
        public int Id { get ; set ; }
        public string UserName { get ; set ; }
        public string Password { get; set; }
    }
}
