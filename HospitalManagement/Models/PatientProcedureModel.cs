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
        public DateTime UseDate { get; set; }

        public PatientProcedureModel Clone()
        {
            return new PatientProcedureModel
            {
                Id = Id,
                No = No,
                Patient = Patient,
                Doctor = Doctor,
                Nurse = Nurse,
                Procedure = Procedure,
                UseDate = UseDate,
            };
        }

    }
}
