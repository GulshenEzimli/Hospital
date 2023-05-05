using HospitalManagement.Models;
using HospitalManagement.Validations.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Validations
{
    public class QueueValidation
    {
        public static bool IsValid(QueueModel queueModel,out string message)
        {
            if (string.IsNullOrEmpty(queueModel.Patient.DisplayPatient))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Patient value");
                return false;
            }

            if (string.IsNullOrEmpty(queueModel.Doctor.DisplayDoctor))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Doctor value");
                return false;
            }
            if (string.IsNullOrEmpty(queueModel.Procedure.Name))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Procedure value");
                return false;
            }
            if(queueModel.QueueNumber==0)
            {
                message = ValidationMessageProvider.GetRequiredMessage("Queue number");
                return false;
            }

            message = null;
            return true;
        }
    }
}
