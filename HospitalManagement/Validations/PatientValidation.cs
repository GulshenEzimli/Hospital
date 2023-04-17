using HospitalManagement.Models;
using HospitalManagement.Validations.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Validations
{
    public static class PatientValidation
    {
        
        public static bool IsValid(PatientModel patientModel, out string message)
        {
            if (string.IsNullOrWhiteSpace(patientModel.Name))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Name");
                return false;
            }
            if (string.IsNullOrWhiteSpace(patientModel.Surname))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Surname");
                return false;
            }
            if (string.IsNullOrWhiteSpace(patientModel.PIN))
            {
                message = ValidationMessageProvider.GetRequiredMessage("PIN");
                return false;
            }
            if ((patientModel.PIN.Length < 7) || (patientModel.PIN.Length > 7))
            {
                message = ValidationMessageProvider.GetCorrectMessage("PIN");
                return false;
            }

            message = null;
            return true;
        }
    }
}
