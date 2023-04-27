using HospitalManagement.Enums;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Validations.Utils;
using HospitalManagement.ViewModels;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.PatientProcedures
{
    public class DeletePatientProcedureCommand : BaseCommand
    {
        private readonly PatientProcedureViewModel _patientProcedureViewModel;
        private readonly IPatientProcedureService _patientProcedureService;
        public DeletePatientProcedureCommand(PatientProcedureViewModel patientProcedureViewModel, IPatientProcedureService patientProcedureService)
        {
            _patientProcedureViewModel = patientProcedureViewModel;
            _patientProcedureService = patientProcedureService;
        }
        public override void Execute(object parameter)
        {
            SureDialog sureDialog = new SureDialog();
            SureDialogViewModel sureDialogViewModel = new SureDialogViewModel();

            sureDialogViewModel.DialogText = ValidationMessageProvider.GetDeleteOperationSureQuestion();
            sureDialog.DataContext = sureDialogViewModel;

            bool? isSure = sureDialog.ShowDialog();
            if (isSure != true)
                return;

            int id = _patientProcedureViewModel.CurrentValue.Id;
            _patientProcedureService.Delete(id);

            var patientProcedureModels = _patientProcedureService.GetAll();
            _patientProcedureViewModel.AllValues = patientProcedureModels;
            _patientProcedureViewModel.Values = new ObservableCollection<PatientProcedureModel>(patientProcedureModels);

            _patientProcedureViewModel.Message = new MessageModel()
            {
                Message = ValidationMessageProvider.GetOperationSuccessMessage(),
                IsSuccess = true,
            };
            DoAnimation(_patientProcedureViewModel.ErrorDialog);

        }
    }
}
