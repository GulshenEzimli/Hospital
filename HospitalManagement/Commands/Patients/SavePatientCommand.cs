using HospitalManagement.Enums;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Validations;
using HospitalManagement.Validations.Utils;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if(PatientValidation.IsValid(_patientViewModel.CurrentValue,out string message) == false)
            {
                _patientViewModel.Message = new MessageModel()
                {
                    IsSuccess = false,
                    Message = message
                };
                DoAnimation(_patientViewModel.ErrorDialog);
                return;

            }

            var patient = _patientMapper.Map(_patientViewModel.CurrentValue);

            patient.Creator = new Admin() { Id = 1 };
            patient.Modifier= new Admin() { Id = 2 };
            patient.CreationDate = DateTime.Now;
            patient.ModifiedDate=DateTime.Now;

            if (patient.Id == 0)
            {
                _patientViewModel.Db.PatientRepository.Insert(patient);
            }
            else
            {
                _patientViewModel.Db.PatientRepository.Update(patient);
            }

            _patientViewModel.CurrentValue.No = _patientViewModel.Values.LastOrDefault()?.No ?? 1;
            _patientViewModel.Values.Add(_patientViewModel.CurrentValue);
            _patientViewModel.SetDefaultValues(); 
        }
        
        
    }
}
