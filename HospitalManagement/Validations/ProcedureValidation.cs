using HospitalManagement.Models;
using HospitalManagement.Validations.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Validations
{
    public static class ProcedureValidation
    {
        public static bool IsValid(ProcedureModel procedureModel,out string message)
        {
            if (string.IsNullOrWhiteSpace(procedureModel.Name))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Procedure name");
                return false;
            }
            if (procedureModel.Cost==0)
            {
                message = ValidationMessageProvider.GetRequiredMessage("Cost");
                return false;
            }
            message = null;
            return true;
        }
    }
}
