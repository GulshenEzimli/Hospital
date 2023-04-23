using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Validations.Utils;
using HospitalManagement.ViewModels;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.Views.Dialogs;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Doctors
{
    public class DeleteDoctorCommand : BaseCommand
    {
        private readonly DoctorsViewModel _doctorsViewModel;
        private readonly DoctorMapper _doctorMapper;
        public DeleteDoctorCommand(DoctorsViewModel doctorsViewModel, IDoctorMapper doctorMapper)
        {
            _doctorsViewModel = doctorsViewModel;
            _doctorMapper = doctorMapper;
        }

        public override void Execute(object parameter)
        {
            SureDialogViewModel sureDialogViewModel = new SureDialogViewModel(_doctorsViewModel.Db);
            SureDialog sureDialog = new SureDialog();
            sureDialogViewModel.DialogText = ValidationMessageProvider.GetDeleteOperationSureQuestion();
            sureDialog.DataContext = sureDialogViewModel;
            bool? isSure =  sureDialog.ShowDialog();
            if(isSure != false)
                return;

            int id = _doctorsViewModel.CurrentValue.Id;
            Doctor doctor = _doctorsViewModel.Db.DoctorRepository.GetById(id);
            doctor.IsDelete = true;
            doctor.ModifiedDate = DateTime.Now;
            doctor.Modifier = new Admin { Id = 1 };
            _doctorsViewModel.Db.DoctorRepository.Update(doctor);
            List<Doctor> doctors = _doctorsViewModel.Db.DoctorRepository.Get();
            int no = 1;
            foreach (Doctor doctorItem in doctors)
            {
                DoctorModel doctorModel = _doctorMapper.Map(doctorItem);
                doctorModel.No = no++;
                _doctorsViewModel.Values.Add(doctorModel);
            }

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
