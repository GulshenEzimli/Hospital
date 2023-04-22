using HospitalManagementCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementCore.Domain.Entities
{
    public class Receptionist : IEntity
    {
        // demeli birinci kateqoriyalara ayirim daha rahat anlasilsin id hec yazdiq 
        public int Id { get; set; }

        // Receptionist main data

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
    }
}
