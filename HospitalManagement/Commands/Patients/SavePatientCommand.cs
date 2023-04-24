using HospitalManagement.Enums;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Validations;
using HospitalManagement.Validations.Utils;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagement.Commands.Patients
{
    public class SavePatientCommand : BaseCommand
    {
        private readonly PatientsViewModel _patientViewModel;
        private readonly IPatientService _patientService;

        public SavePatientCommand(PatientsViewModel patientViewModel,IPatientService patientService)
        {
            _patientViewModel = patientViewModel;
            _patientService = patientService;
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
            _patientService.Save(_patientViewModel.CurrentValue);
            
            var patientModels= _patientService.GetAll();
            _patientViewModel.AllValues = patientModels;
            _patientViewModel.Values = new ObservableCollection<PatientModel>(patientModels);

            _patientViewModel.SetDefaultValues();
        }
        
        
    }
}
