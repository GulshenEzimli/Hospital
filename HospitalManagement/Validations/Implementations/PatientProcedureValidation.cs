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
    public class PatientProcedureValidation : IControlModelValidation<PatientProcedureModel>
    {
        public bool IsValid(PatientProcedureModel patientProcedureModel, out string message)
        {
            if (string.IsNullOrEmpty(patientProcedureModel.Patient.DisplayPatient))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Patient value");
                return false;
            }

            if (string.IsNullOrEmpty(patientProcedureModel.Doctor.DisplayDoctor))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Doctor value");
                return false;
            }

            if (string.IsNullOrEmpty(patientProcedureModel.Nurse.DisplayNurse))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Nurse value");
                return false;
            }
            if (string.IsNullOrEmpty(patientProcedureModel.Procedure.DisplayProcedure))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Procedure value");
                return false;
            }

            message = null;
            return true;
        }
    }
}
