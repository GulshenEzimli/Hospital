using HospitalManagement.Models;
using HospitalManagement.Validations.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                message = ValidationMessageProvider.GetMaxLengthMessage("Name", 26);
                return false;
            }
            if (doctorModel.FirstName.Length < 3)
            {
                message = ValidationMessageProvider.GetMinLengthMessage("Name", 2);
                return false;
            }

            if (string.IsNullOrWhiteSpace(doctorModel.LastName))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Surname");
                return false;
            }
            if (doctorModel.LastName.Length > 25)
            {
                message = ValidationMessageProvider.GetMaxLengthMessage("Surname", 26);
                return false;
            }
            if (doctorModel.LastName.Length > 25)
            {
                message = ValidationMessageProvider.GetMinLengthMessage("Surname", 2);
                return false;
            }

            if (doctorModel.Gender == 0)
            {
                message = ValidationMessageProvider.GetRequiredMessage("Gender");
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
            foreach (char item in doctorModel.PIN)
            {
                if (item < 48 || (item > 57 && item < 65) || (item > 90 && item < 97) || item > 122)
                {
                    message = ValidationMessageProvider.GetCorrectMessage("Pin");
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(doctorModel.Email))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Email");
                return false;
            }
            if (doctorModel.Email.Length > 50)
            {
                message = ValidationMessageProvider.GetMaxLengthMessage("Email", 50);
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
            if(doctorModel.Position == null)
            {
                message = ValidationMessageProvider.GetRequiredMessage("Position");
                return false;
            }

            message = null;
            return true;
        }
    }
}
