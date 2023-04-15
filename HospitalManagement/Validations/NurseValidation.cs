using HospitalManagement.Models;
using HospitalManagement.Validations.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Validations
{
    public static class NurseValidation
    {
        public static bool IsValid(NurseModel nurseModel, out string message)
        {
            if (string.IsNullOrWhiteSpace(nurseModel.FirstName))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Name");
                return false;
            }
            if (nurseModel.FirstName.Length > 25)
            {
                message = ValidationMessageProvider.GetLengthMessage("Name", 25);
                return false;
            }
            if (string.IsNullOrWhiteSpace(nurseModel.LastName))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Surname");
                return false;
            }
            if (nurseModel.LastName.Length > 25)
            {
                message = ValidationMessageProvider.GetLengthMessage("Surname", 25);
                return false;
            }

            if (string.IsNullOrWhiteSpace(nurseModel.PhoneNumber))
            {
                message = ValidationMessageProvider.GetRequiredMessage("PhoneNumber");
                return false;
            }
            if (nurseModel.PhoneNumber.Length != 13)
            {
                message = ValidationMessageProvider.GetSpecificLength("PhoneNumber", 13);
                return false;
            }
            if (string.IsNullOrEmpty(nurseModel.PIN))
            {
                message = ValidationMessageProvider.GetRequiredMessage("PIN");
                return false;
            }
            if (nurseModel.PIN.Length != 7)
            {
                message = ValidationMessageProvider.GetSpecificLength("PIN", 7);
                return false;
            }

            if (string.IsNullOrWhiteSpace(nurseModel.Email))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Email");
                return false;
            }
            if (nurseModel.Email.Length > 50)
            {
                message = ValidationMessageProvider.GetLengthMessage("Email", 50);
                return false;
            }

            if (nurseModel.Salary < 0)
            {
                message = ValidationMessageProvider.GetSalaryMessage();
                return false;
            }
            if (nurseModel.Salary > 10000)
            {
                message = ValidationMessageProvider.GetSalaryMessage(10000);
                return false;
            }

            message = null;
            return true;
        }
    }
}
