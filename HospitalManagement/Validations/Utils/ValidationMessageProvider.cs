using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Validations.Utils
{
    public static class ValidationMessageProvider
    {
        public static string GetRequiredMessage(string propName)
        {
            return $"{propName} is required.";
        }
        public static string GetCorrectMessage(string propName)
        {
            return $"{propName} is incorrect.";
        }

        public static string GetMaxLengthMessage(string propName, int maxLength)
        {
            return $"{propName} length should be less than {maxLength}";
        }
        public static string GetMinLengthMessage(string propName, int minLength)
        {
            return $"{propName} length should be more than {minLength}";
        }

        public static string GetSpecificLength(string propName, int length)
        {
            return $"{propName} length can't be less than {length} or greater than {length}";
        }
        public static string GetSalaryMessage() 
        {
            return "Salary should be greater than 0.";
        }
        public static string GetSalaryMessage(decimal salary)
        {
            return $"Salary should be less than {salary}.";
        }
        public static string GetPINMessage()
        {
            return $"PIN should be 7.";
        }

    }
}
