using HospitalManagement.Models;
using HospitalManagement.Validations.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Validations
{
    public static class DoctorValidation
    {
        public static bool IsValid(DoctorModel doctorModel, out string message)
        {
            if (string.IsNullOrWhiteSpace(doctorModel.FirstName))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Name");
                return false;
            }
            if (doctorModel.FirstName.Length > 25)
            {
                message = ValidationMessageProvider.GetLengthMessage("Name", 25);
                return false;
            }
            if (string.IsNullOrWhiteSpace(doctorModel.LastName))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Surname");
                return false;
            }
            if (doctorModel.LastName.Length > 25)
            {
                message = ValidationMessageProvider.GetLengthMessage("Surname", 25);
                return false;
            }

            if (string.IsNullOrWhiteSpace(doctorModel.Phonenumber))
            {
                message = ValidationMessageProvider.GetRequiredMessage("PhoneNumber");
                return false;
            }
            if (doctorModel.Phonenumber.Length != 13)
            {
                message = ValidationMessageProvider.GetSpecificLength("PhoneNumber", 13);
                return false;
            }
            if (string.IsNullOrEmpty(doctorModel.PIN))
            {
                message = ValidationMessageProvider.GetRequiredMessage("PIN");
                return false;
            }
            if (doctorModel.PIN.Length != 7)
            {
                message = ValidationMessageProvider.GetSpecificLength("PIN", 7);
                return false;
            }

            if (string.IsNullOrWhiteSpace(doctorModel.Email))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Email");
                return false;
            }
            if (doctorModel.Email.Length > 50)
            {
                message = ValidationMessageProvider.GetLengthMessage("Email", 50);
                return false;
            }

            if (doctorModel.Salary < 0)
            {
                message = ValidationMessageProvider.GetSalaryMessage();
                return false;
            }
            if (doctorModel.Salary > 10000)
            {
                message = ValidationMessageProvider.GetSalaryMessage(10000);
                return false;
            }

            message = null;
            return true;
        }
    }
}
