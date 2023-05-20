using DocumentFormat.OpenXml.Wordprocessing;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Models.Interfaces;
using HospitalManagement.Validations.Utils;
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

            if (Name?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (Surname?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (BirthDate.ToString(SystemConstants.DateDisplayFormat).Contains(lowerSearchText))
                return true;

            if (Note?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (Motherland?.ToLower().Contains(lowerSearchText) == true)
                return true;

            return false;
        }

    }
}
