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

        public ProcedureDoctorModel  Doctor { get; set; }   
        public ProcedureNurseModel Nurse { get; set; }
        public ProcedurePatientModel Patient { get; set; }
        public ProcedureModel Procedure { get; set; }

        public string DisplayNurse => $"{Nurse.Name} {Nurse.Surname} {Nurse.PIN}";
        public string DisplayPatient => $"{Patient.Name} {Patient.Surname} {Patient.PIN}";
        public string DisplayDoctor => $"{Doctor.Name} {Doctor.Surname} {Doctor.PIN}";

        public DateTime UseDate { get; set; }

    }
}
