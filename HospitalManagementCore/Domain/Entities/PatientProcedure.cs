using HospitalManagementCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementCore.Domain.Entities
{
    public class PatientProcedure : IEntity
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int NurseId { get; set; }
        public int ProcedureId { get; set; }
        public DateTime UseDate { get; set; }

        //public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Nurse Nurse { get; set; }
        //public Procedure Procedure { get; set; }
    }
}
