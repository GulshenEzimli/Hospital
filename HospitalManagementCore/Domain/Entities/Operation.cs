using HospitalManagementCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementCore.Domain.Entities
{
    public class Operation : IEntity
    {
        public int Id { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal OperationCost { get; set; }
        public string OperationReason { get; set; }
        public int PatientId => Patient?.Id ?? 0;
        public int RoomId => Room?.Id ?? 0;
        public Patient Patient { get; set; }
        public Room Room { get; set; }
    }
}
