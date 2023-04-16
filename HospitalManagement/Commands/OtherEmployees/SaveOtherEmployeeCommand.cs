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

            OtherEmployee otherEmployee = _otherEmployeeMapper.Map(_otherEmployeesViewModel.CurrentOtherEmployeeValue);
            otherEmployee.Creator = new Admin() { Id = 2 };
            otherEmployee.Modifier = new Admin() { Id = 2 };
            otherEmployee.CreationDate = DateTime.Now;
            otherEmployee.ModifiedDate = DateTime.Now;
            otherEmployee.IsDelete = false;
            otherEmployee.Job = new Job() { Name = _otherEmployeesViewModel.CurrentOtherEmployeeValue.JobName };
            otherEmployee.Gender = true;
            if(otherEmployee.Id == 0)
            {
                _otherEmployeesViewModel.Db.OtherEmployeeRepository.Insert(otherEmployee);
            }
            else
            {
                _otherEmployeesViewModel.Db.OtherEmployeeRepository.Update(otherEmployee);
            }
            _otherEmployeesViewModel.CurrentOtherEmployeeValue.No = _otherEmployeesViewModel.OtherEmployeeValues.LastOrDefault()?.No + 1 ?? 1;
            _otherEmployeesViewModel.OtherEmployeeValues.Add(_otherEmployeesViewModel.CurrentOtherEmployeeValue);
            _otherEmployeesViewModel.SetDefaultValues();
        }
    }
}
