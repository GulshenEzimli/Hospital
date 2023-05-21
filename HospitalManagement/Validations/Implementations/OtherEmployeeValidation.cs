using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Validations.Interfaces;
using HospitalManagement.Validations.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Validations.Implementations
{
    public class OtherEmployeeValidation : IControlModelValidation<OtherEmployeeModel>
    {
        public bool IsValid(OtherEmployeeModel otherEmployeeModel, out string message)
        {
            if (string.IsNullOrWhiteSpace(otherEmployeeModel.FirstName))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Name");
                return false;
            }
            if(otherEmployeeModel.FirstName.Length > 25)
            {
                message = ValidationMessageProvider.GetMaxLengthMessage("Name", 25);
                return false;
            }
            if (string.IsNullOrWhiteSpace(otherEmployeeModel.LastName))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Surname");
                return false;
            }
            if (otherEmployeeModel.LastName.Length > 25)
            {
                message = ValidationMessageProvider.GetMaxLengthMessage("Surname", 25);
                return false;
            }
            if (string.IsNullOrWhiteSpace(otherEmployeeModel.PhoneNumber))
            {
                message = ValidationMessageProvider.GetRequiredMessage("PhoneNumber");
                return false;
            }
            if(otherEmployeeModel.PhoneNumber.Length != 13)
            {
                message = ValidationMessageProvider.GetSpecificLength("PhoneNumber", 13);
                return false;
            }
            if (string.IsNullOrWhiteSpace(otherEmployeeModel.PIN))
            {
                message = ValidationMessageProvider.GetRequiredMessage("PIN");
                return false;
            }
            if (otherEmployeeModel.PIN.Length != 7)
            {
                message = ValidationMessageProvider.GetSpecificLength("PIN", 7);
                return false;
            }
            if (string.IsNullOrWhiteSpace(otherEmployeeModel.Email))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Email");
                return false;
            }
            if (otherEmployeeModel.Email.Length > 50)
            {
                message = ValidationMessageProvider.GetMaxLengthMessage("Email", 50);
                return false;
            }
            if (otherEmployeeModel.Salary < 0)
            {
                message = ValidationMessageProvider.GetSalaryMessage();
                return false;
            }
            if (otherEmployeeModel.Salary > 10000)
            {
                message = ValidationMessageProvider.GetSalaryMessage(10000);
                return false;
            }

            message = null;
            return true;

        }
    }
}
