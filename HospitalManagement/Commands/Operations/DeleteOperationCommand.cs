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

namespace HospitalManagement.Commands.Operations
{
    public class DeleteOperationCommand : BaseCommand
    {
        private readonly OperationsViewModel _operationsViewModel;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public DeleteOperationCommand(OperationsViewModel operationsViewModel, IServiceUnitOfWork serviceUnitOfWork)
        {
            _operationsViewModel = operationsViewModel;
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        public override void Execute(object parameter)
        {
            SureDialogViewModel sureDialogViewModel = new SureDialogViewModel();
            SureDialog sureDialog = new SureDialog();
            sureDialogViewModel.DialogText = ValidationMessageProvider.GetDeleteOperationSureQuestion();
            sureDialog.DataContext = sureDialogViewModel;
            bool? isSure = sureDialog.ShowDialog();
            if (isSure == false)
                return;

            int id = _operationsViewModel.CurrentValue.Id;
            _serviceUnitOfWork.operationService.DeleteOperation(id);

            List<OperationModel> operationModels = _serviceUnitOfWork.operationService.GetAll();
            _operationsViewModel.AllValues = operationModels;
            _operationsViewModel.Values = new ObservableCollection<OperationModel>(operationModels);

            _operationsViewModel.SetDefaultValues();

            _operationsViewModel.Message = new MessageModel
            {
                IsSuccess = true,
                Message = ValidationMessageProvider.GetOperationSuccessMessage()
            };
            DoAnimation(_operationsViewModel.ErrorDialog);
        }
    }
}
