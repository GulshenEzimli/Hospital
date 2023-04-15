using HospitalManagement.Enums;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Utils;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Patients
{
    public class SavePatientCommand : BaseCommand
    {
        private readonly PatientsViewModel _patientViewModel;
        private readonly IPatientMapper _patientMapper;

        public SavePatientCommand(PatientsViewModel patientViewModel,IPatientMapper patientMapper)
        {
            _patientViewModel = patientViewModel;
            _patientMapper=patientMapper;
        }

        public override void Execute(object parameter)
        {
            if(IsValid(_patientViewModel.CurrentValue,out var message) == false)
            {
                return;
            }


            var patient = _patientMapper.Map(_patientViewModel.CurrentValue);
            if (patient.Id == 0)
            {
                _patientViewModel.Db.PatientRepository.Insert(patient);
            }
            else
            {
                _patientViewModel.Db.PatientRepository.Update(patient);
            }

            _patientViewModel.SetDefaultValues(); 
        }
        
        #region IsValid
        private bool IsValid(PatientModel patientModel, out string message)
        {
            if (string.IsNullOrWhiteSpace(patientModel.PIN))
            {
                message = ValidationMessageProvider.GetRequiredMessage("PIN");
                return false;
            }
            if ((patientModel.PIN.Length < 7) || (patientModel.PIN.Length > 7))
            {
                message = ValidationMessageProvider.GetPINMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(patientModel.Name))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Name");
                return false;
            }
            if (string.IsNullOrWhiteSpace(patientModel.Surname))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Surname");
                return false;
            }
            message = null;
            return true;
        }
        #endregion
    }
}
