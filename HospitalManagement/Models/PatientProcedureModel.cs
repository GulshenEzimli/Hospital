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

        #region old properties
        //public string PatientName { get; set; }
        //public string PatientSurname { get; set; }
        //public string PatientPIN { get; set; }
        //public string Patient => $"{PatientName} {PatientSurname} {PatientPIN}";
        //public string DoctorName { get; set; }
        //public string DoctorSurname { get; set; }
        //public string DoctorPIN { get; set; }
        //public string Doctor => $"{DoctorName} {DoctorSurname} {DoctorPIN}";
        //public string NurseName { get; set; }
        //public string NurseSurname { get; set; }
        //public string NursePIN { get; set; }
        //public string Nurse => $"{NurseName} {NurseSurname} {NursePIN}";
        //public string ProcedureName { get; set; }
        //public decimal Cost { get; set; }
        //public DateTime UseDate { get; set; }
        #endregion

    }
}
