using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Validations.Utils;
using HospitalManagement.ViewModels;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.Views.Dialogs;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Doctors
{
    public class DeleteDoctorCommand : BaseCommand
    {
        private readonly DoctorsViewModel _doctorsViewModel;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public DeleteDoctorCommand(DoctorsViewModel doctorsViewModel, IServiceUnitOfWork serviceUnitOfWork)
        {
            _doctorsViewModel = doctorsViewModel;
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        public override void Execute(object parameter)
        {
            SureDialogViewModel sureDialogViewModel = new SureDialogViewModel();
            SureDialog sureDialog = new SureDialog();
            sureDialogViewModel.DialogText = ValidationMessageProvider.GetDeleteOperationSureQuestion();
            sureDialog.DataContext = sureDialogViewModel;
            bool? isSure =  sureDialog.ShowDialog();
            if(isSure != false)
                return;

            int id = _doctorsViewModel.CurrentValue.Id;
            _serviceUnitOfWork.doctorService.DeleteDoctor(id);

            List<DoctorModel> doctorModels = _serviceUnitOfWork.doctorService.GetAll();
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
