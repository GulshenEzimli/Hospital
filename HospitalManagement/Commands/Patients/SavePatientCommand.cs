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

            var savePatient = _patientMapper.Map(_patientViewModel.CurrentValue);

            
            savePatient.IsDelete = false;
            savePatient.Gender = true;
            savePatient.Modifier = new Admin() { Id = 2 };
            savePatient.ModifiedDate = DateTime.Now;
            if (savePatient.Id == 0)
            {
                savePatient.Creator = new Admin() { Id = 2 };
                savePatient.CreationDate = DateTime.Now;

                _patientViewModel.Db.PatientRepository.Insert(savePatient);

                _patientViewModel.CurrentValue.No = _patientViewModel.Values.LastOrDefault()?.No ?? 1;
                _patientViewModel.Values.Add(_patientViewModel.CurrentValue);
            }
            else
            {
                var existPatient = _patientViewModel.Db.PatientRepository.GetById(_patientViewModel.CurrentValue.Id);

                savePatient.Creator = existPatient.Creator;
                savePatient.CreationDate = existPatient.CreationDate;

                _patientViewModel.Db.PatientRepository.Update(savePatient);

                var existingValue=_patientViewModel.Values.FirstOrDefault(x => x.Id == existPatient.Id);
                var existingValueIndex=_patientViewModel.Values.IndexOf(existingValue);
                _patientViewModel.Values[existingValueIndex]=_patientViewModel.CurrentValue;
            }

            _patientViewModel.SetDefaultValues();
        }
        
        
    }
}
