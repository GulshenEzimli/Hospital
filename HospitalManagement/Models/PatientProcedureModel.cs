using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class PatientProcedureModel
    {
        public int Id { get; set; }
        public int No { get; set; }
        public PatientModel Patient { get; set; }
        public DoctorModel Doctor { get; set; }
        public NurseModel Nurse { get; set; }
        public ProcedureModel Procedure { get; set; }
        public string DisplayPatient => $"{Patient.Name} {Patient.Surname} {Patient.PIN}";
        public string DisplayDoctor => $"{Doctor.FirstName} {Doctor.LastName} {Doctor.PIN}";
        public string DisplayNurse => $"{Nurse.FirstName} {Nurse.LastName} {Nurse.PIN}";
        public string DisplayProcedure => $"{ProcedureName} {Procedure.Cost}";
        public string ProcedureName => Procedure.Name;
        public decimal Cost => Procedure.Cost;
        public DateTime UseDate { get; set; }

    }
}
