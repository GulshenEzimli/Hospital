using HospitalManagement.Enums;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Validations;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.Views.Components;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.OtherEmployees
{
    public class SaveOtherEmployeeCommand : BaseCommand
    {
        private readonly OtherEmployeesViewModel _otherEmployeesViewModel;
        private readonly IOtherEmployeeMapper _otherEmployeeMapper;
        public SaveOtherEmployeeCommand(OtherEmployeesViewModel otherEmployeesViewModel, IOtherEmployeeMapper otherEmployeeMapper)
        {
            _otherEmployeesViewModel = otherEmployeesViewModel;
            _otherEmployeeMapper = otherEmployeeMapper;
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

            OtherEmployee toSavedOtherEmployee = _otherEmployeeMapper.Map(_otherEmployeesViewModel.CurrentOtherEmployeeValue);
            
            toSavedOtherEmployee.Modifier = new Admin() { Id = 3 };
            toSavedOtherEmployee.ModifiedDate = DateTime.Now;
            
            if(toSavedOtherEmployee.Id == 0)
            {
                toSavedOtherEmployee.Creator = new Admin() { Id = 3 }; 
                toSavedOtherEmployee.CreationDate = DateTime.Now;
                toSavedOtherEmployee.IsDelete = false;
                _otherEmployeesViewModel.Db.OtherEmployeeRepository.Insert(toSavedOtherEmployee);
                _otherEmployeesViewModel.CurrentOtherEmployeeValue.No = _otherEmployeesViewModel.OtherEmployeeValues.LastOrDefault()?.No + 1 ?? 1;
                _otherEmployeesViewModel.OtherEmployeeValues.Add(_otherEmployeesViewModel.CurrentOtherEmployeeValue);
            }
            else
            {
                var existingOtherEmployee = _otherEmployeesViewModel.Db.OtherEmployeeRepository.GetById(_otherEmployeesViewModel.CurrentOtherEmployeeValue.Id);
                toSavedOtherEmployee.Creator = existingOtherEmployee.Creator;
                toSavedOtherEmployee.CreationDate = existingOtherEmployee.CreationDate;
                toSavedOtherEmployee.IsDelete = existingOtherEmployee.IsDelete;
                _otherEmployeesViewModel.Db.OtherEmployeeRepository.Update(toSavedOtherEmployee);

                var existingValue = _otherEmployeesViewModel.OtherEmployeeValues.FirstOrDefault(x => x.Id == existingOtherEmployee.Id);
                var existingValueIndex = _otherEmployeesViewModel.OtherEmployeeValues.IndexOf(existingValue);
                _otherEmployeesViewModel.OtherEmployeeValues[existingValueIndex] = _otherEmployeesViewModel.CurrentOtherEmployeeValue;
            }
            
            _otherEmployeesViewModel.SetDefaultValues();
        }
    }
}
