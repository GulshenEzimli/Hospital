using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Utils
{
    public static class ValidationMessageProvider
    {
        public static string GetRequiredMessage(string propName)
        {
            return $"{propName} is required.";
        }

        public static string GetLengthMessage(string propName,int length)
        {
            return $"{propName} length should be less than {length}";
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
