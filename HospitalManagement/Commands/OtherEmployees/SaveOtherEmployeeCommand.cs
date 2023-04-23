using HospitalManagement.Enums;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Validations;
using HospitalManagement.Validations.Utils;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.Views.Components;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.OtherEmployees
{
    public class SaveOtherEmployeeCommand : BaseCommand
    {
        private readonly OtherEmployeesViewModel _otherEmployeesViewModel;
        private readonly IOtherEmployeeService _otherEmployeeService;
        public SaveOtherEmployeeCommand(OtherEmployeesViewModel otherEmployeesViewModel, IOtherEmployeeService otherEmployeeService)
        {
            _otherEmployeesViewModel = otherEmployeesViewModel;
            _otherEmployeeService = otherEmployeeService;
        }
        public override void Execute(object parameter)
        {
            if(OtherEmployeeValidation.IsValid(_otherEmployeesViewModel.CurrentOtherEmployeeValue,out string message) == false)
            {
                _otherEmployeesViewModel.Message = new MessageModel()
                {
                    Message = message,
                    IsSuccess = false,
                };
                DoAnimation(_otherEmployeesViewModel.ErrorDialog);
                return;
            }

            _otherEmployeeService.Save(_otherEmployeesViewModel.CurrentOtherEmployeeValue);

            var otherEmployeeModels = _otherEmployeeService.GetAll();
            _otherEmployeesViewModel.AllValues = otherEmployeeModels;
            _otherEmployeesViewModel.OtherEmployeeValues = new ObservableCollection<OtherEmployeeModel>(otherEmployeeModels);

            _otherEmployeesViewModel.SetDefaultValues();

            _otherEmployeesViewModel.Message = new MessageModel()
            {
                Message = ValidationMessageProvider.GetOperationSuccessMessage(),
                IsSuccess = true,
            };
            DoAnimation(_otherEmployeesViewModel.ErrorDialog);
            return;
        }
    }
}
