using HospitalManagement.Enums;
using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Validations;
using HospitalManagement.Validations.Utils;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.PatientProcedures
{
    public class SavePatientProcedureCommand : BaseCommand
    {
        private readonly PatientProcedureViewModel _patientProcedureViewModel;
        private readonly IPatientProcedureService _patientProcedureService;
        public SavePatientProcedureCommand(PatientProcedureViewModel patientProcedureViewModel, IPatientProcedureService patientProcedureService)
        {
            _patientProcedureViewModel = patientProcedureViewModel;
            _patientProcedureService = patientProcedureService;
        }
        public override void Execute(object parameter)
        {
            //TO DO...
            if(PatientProcedureValidation.IsValid(_patientProcedureViewModel.CurrentValue,out string message) == false)
            {
                _patientProcedureViewModel.Message = new MessageModel()
                {
                    Message = message,
                    IsSuccess = false,
                };
                DoAnimation(_patientProcedureViewModel.ErrorDialog);
                return;
            }

            _patientProcedureService.Save(_patientProcedureViewModel.CurrentValue);

            var patientProcedureModels = _patientProcedureService.GetAll();
            _patientProcedureViewModel.AllValues = patientProcedureModels;
            _patientProcedureViewModel.Values = new ObservableCollection<PatientProcedureModel>(patientProcedureModels);

            _patientProcedureViewModel.SetDefaultValues();

            _patientProcedureViewModel.Message = new MessageModel()
            {
                Message = ValidationMessageProvider.GetOperationSuccessMessage(),
                IsSuccess = true,
            };
            DoAnimation(_patientProcedureViewModel.ErrorDialog);
        }
    }
}
