using HospitalManagement.Enums;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
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

namespace HospitalManagement.Commands.Doctors
{
    public class SaveDoctorCommand : BaseCommand
    {
        private readonly DoctorsViewModel _doctorsViewModel;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public SaveDoctorCommand(DoctorsViewModel doctorsViewModel, IServiceUnitOfWork serviceUnitOfWork)
        {
            _doctorsViewModel = doctorsViewModel;
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        public override void Execute(object parameter)
        {
            if (DoctorValidation.IsValid(_doctorsViewModel.CurrentValue, out string message) == false)
            {
                _doctorsViewModel.Message = new MessageModel
                {
                    IsSuccess = false,
                    Message = message
                };
                DoAnimation(_doctorsViewModel.ErrorDialog);
                return;
            }

            _serviceUnitOfWork.DoctorService.SaveDoctor(_doctorsViewModel.CurrentValue);

            List<DoctorModel> doctorModels = _serviceUnitOfWork.DoctorService.GetAll();
            _doctorsViewModel.AllValues = doctorModels;
            _doctorsViewModel.Values = new ObservableCollection<DoctorModel>(doctorModels);

            _doctorsViewModel.SetDefaultValues();

            _doctorsViewModel.Message = new MessageModel
            {
                IsSuccess = true,
                Message = ValidationMessageProvider.GetOperationSuccessMessage()
            };
            DoAnimation(_doctorsViewModel.ErrorDialog);
        }
    }
}
