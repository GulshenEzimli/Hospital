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

namespace HospitalManagement.Commands.Operations
{
    public class SaveOperationCommand : BaseCommand
    {
        private readonly OperationsViewModel _operationsViewModel;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public SaveOperationCommand(OperationsViewModel operationsViewModel, IServiceUnitOfWork serviceUnitOfWork)
        {
            _operationsViewModel = operationsViewModel;
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        public override void Execute(object parameter)
        {
            if (OperationValidation.IsValid(_operationsViewModel.CurrentValue, out string message) == false)
            {
                _operationsViewModel.Message = new MessageModel
                {
                    IsSuccess = false,
                    Message = message
                };
                DoAnimation(_operationsViewModel.ErrorDialog);
                return;
            }

            _serviceUnitOfWork.operationService.SaveOperation(_operationsViewModel.CurrentValue);

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
