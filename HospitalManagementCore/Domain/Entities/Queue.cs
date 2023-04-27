using HospitalManagementCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementCore.Domain.Entities
{
    public class Queue : IEntity
    {
        public int Id { get; set; }
        public Doctor DoctorId { get; set; }
        public Patient PatientId { get; set; }
        public int QueueNumber { get; set; }
        public DateTime Date { get; set; }
    }
}
