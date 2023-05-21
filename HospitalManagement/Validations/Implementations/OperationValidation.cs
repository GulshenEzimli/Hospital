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
    public class OperationValidation : IControlModelValidation<OperationModel>
    {
        public bool IsValid(OperationModel operationModel, out string message)
        {            
            if (string.IsNullOrEmpty(operationModel.OperationReason))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Operation reason");
                return false;
            }           
            if (operationModel.OperationCost < 0)
            {
                message = ValidationMessageProvider.GetOperationCostMessage();
                return false;
            }
            if (operationModel.Nurses == null)
            {
                message = ValidationMessageProvider.GetRequiredMessage("Nurse");
                return false;
            }
            if (operationModel.Doctors == null)
            {
                message = ValidationMessageProvider.GetRequiredMessage("Nurse");
                return false;
            }
            if (operationModel.Patient == null)
            {
                message = ValidationMessageProvider.GetRequiredMessage("Patient");
                return false;
            }
            if (operationModel.Room == null)
            {
                message = ValidationMessageProvider.GetRequiredMessage("Room");
                return false;
            }

            message = null;
            return true;
        }
    }
}
