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
            if (string.IsNullOrWhiteSpace(patientModel.PhoneNumber))
            {
                message=ValidationMessageProvider.GetRequiredMessage("PhoneNumber");
                return false;
            }
            if (string.IsNullOrWhiteSpace(patientModel.PIN))
            {
                message = ValidationMessageProvider.GetRequiredMessage("PIN");
                return false;
            }
            if ((patientModel.PIN.Length < 7) || (patientModel.PIN.Length > 7))
            {
                message = ValidationMessageProvider.GetSpecificLength("PIN",7);
                return false;
            }
            if((patientModel.PhoneNumber.Length < 13)|| (patientModel.PhoneNumber.Length > 13))
            {
                message = ValidationMessageProvider.GetSpecificLength("Phonenumber", 13);
                return false;
            }
            if (patientModel.Gender == 0)
            {
                message = ValidationMessageProvider.GetRequiredMessage("Gender");
                return false;
            }

            message = null;
            return true;
        }
    }
}
