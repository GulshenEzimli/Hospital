using HospitalManagement.Models;
using HospitalManagement.Validations.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Validations
{
    public static class PatientProcedureValidation
    {
        public static bool IsValid(PatientProcedureModel patientProcedureModel, out string message)
        {
            if (string.IsNullOrEmpty(patientProcedureModel.DisplayPatient))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Patient value");
                return false;
            }

            if (string.IsNullOrEmpty(patientProcedureModel.DisplayDoctor))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Doctor value");
                return false;
            }

            if (string.IsNullOrEmpty(patientProcedureModel.DisplayNurse))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Nurse value");
                return false;
            }

            message = null;
            return true;
        }
    }
}
