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

namespace HospitalManagement.Commands.OtherEmployees
{
    public class DeleteOtherEmployeeCommand : BaseCommand
    {
        private readonly OtherEmployeesViewModel _otherEmployeesViewModel;
        private readonly IOtherEmployeeService _otherEmployeeService;
        public DeleteOtherEmployeeCommand(OtherEmployeesViewModel otherEmployeesViewModel, IOtherEmployeeService otherEmployeeService)
        {
            _otherEmployeesViewModel = otherEmployeesViewModel;
            _otherEmployeeService = otherEmployeeService;
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

            int id = _otherEmployeesViewModel.SelectedValue.Id;
            _otherEmployeeService.Delete(id);

            var otherEmployeeModels = _otherEmployeeService.GetAll();
            _otherEmployeesViewModel.AllValues = otherEmployeeModels;
            _otherEmployeesViewModel.Values = new ObservableCollection<OtherEmployeeModel>(otherEmployeeModels);

            _otherEmployeesViewModel.Message = new MessageModel()
            {
                Message = ValidationMessageProvider.GetOperationSuccessMessage(),
                IsSuccess = true,
            };
            DoAnimation(_otherEmployeesViewModel.ErrorDialog);

        }
    }
}
