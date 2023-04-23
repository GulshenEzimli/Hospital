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

namespace HospitalManagement.Commands.Nurses
{
    public class SaveNurseCommand : BaseCommand
    {
        private readonly NursesViewModel _nursesViewModel;
        private readonly INurseService _nurseService;
        public SaveNurseCommand(NursesViewModel nursesViewModel,INurseService nurseService)
        {
            _nursesViewModel = nursesViewModel;
            _nurseService = nurseService;
        }
        public override void Execute(object parameter)
        {
            //TO DO ...
            if (NurseValidation.IsValid(_nursesViewModel.CurrentValue, out string message) == false)
            {
                _nursesViewModel.Message = new MessageModel
                {
                    IsSuccess = false,
                    Message = message
                };
                DoAnimation(_nursesViewModel.ErrorDialog);
                return;
            }

            _nurseService.Save(_nursesViewModel.CurrentValue);

            var nurseModels = _nurseService.GetAll();
            _nursesViewModel.AllValues = nurseModels;
            _nursesViewModel.Values = new ObservableCollection<NurseModel>(_nursesViewModel.AllValues);

            _nursesViewModel.SetDefaultValues();

            _nursesViewModel.Message = new MessageModel
            {
                IsSuccess = true,
                Message = ValidationMessageProvider.GetOperationSuccessMessage(),
            };
            DoAnimation(_nursesViewModel.ErrorDialog);
        }
    }
}
