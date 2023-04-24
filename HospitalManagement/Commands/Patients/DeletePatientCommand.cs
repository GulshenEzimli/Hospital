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

namespace HospitalManagement.Commands.Patients
{
    public class DeletePatientCommand:BaseCommand
    {
        private readonly PatientsViewModel _patientViewModel;
        private readonly IPatientService _patientService;
        public DeletePatientCommand(PatientsViewModel patientViewModel,IPatientService patientService)
        {
            _patientViewModel = patientViewModel;
            _patientService=patientService;
        }
        public override void Execute(object parameter)
        {
            SureDialogViewModel sureDialogViewModel = new SureDialogViewModel();
            SureDialog sureDialog = new SureDialog();

            sureDialogViewModel.DialogText = ValidationMessageProvider.GetDeleteOperationSureQuestion();
            sureDialog.DataContext = sureDialogViewModel;

            var isSure = sureDialog.ShowDialog();
            if (isSure != true)
                return;

            var id = _patientViewModel.SelectValue.Id;
            _patientService.Delete(id);

            var patientModels = _patientService.GetAll();
            _patientViewModel.AllValues = patientModels;
            _patientViewModel.Values = new ObservableCollection<PatientModel>(patientModels);

            _patientViewModel.Message = new MessageModel
            {
                IsSuccess = true,
                Message = ValidationMessageProvider.GetOperationSuccessMessage()
            };
            DoAnimation(_patientViewModel.ErrorDialog);

        }
    }
}
