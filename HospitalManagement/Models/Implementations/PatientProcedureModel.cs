using DocumentFormat.OpenXml.Wordprocessing;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Models.Interfaces;
using HospitalManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models.Implementations
{
    public class PatientProcedureModel : IControlModel
    {
        public int Id { get; set; }
        public int No { get; set; }
        public PatientModel Patient { get; set; }
        public DoctorModel Doctor { get; set; }
        public NurseModel Nurse { get; set; }
        public ProcedureModel Procedure { get; set; }
        public DateTime UseDate { get; set; }

        public IControlModel Clone()
        {
            return new PatientProcedureModel
            {
                Id = Id,
                No = No,
                Patient = (PatientModel)Patient.Clone(),
                Doctor = (DoctorModel)Doctor.Clone(),
                Nurse = (NurseModel)Nurse.Clone(),
                Procedure = (ProcedureModel)Procedure.Clone(),
                UseDate = UseDate,
            };
        }
        public bool IsCompatibleWithFilter(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return true;

            string lowerSearchText = searchText.ToLower();

            if (Doctor.DisplayDoctor?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (Nurse.DisplayNurse?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (UseDate.ToString(SystemConstants.DateDisplayFormat).ToLower().Contains(lowerSearchText))
                return true;

            if (Patient.DisplayPatient?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (Procedure.DisplayProcedure?.ToLower().Contains(lowerSearchText) == true)
                return true;

            return false;            
        }

    }
}
