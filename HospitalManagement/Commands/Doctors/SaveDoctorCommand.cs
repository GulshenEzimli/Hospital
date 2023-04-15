using HospitalManagement.Enums;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Validations;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Doctors
{
    public class SaveDoctorCommand : BaseCommand
    {
        private readonly DoctorsViewModel _doctorsViewModel;
        private readonly IDoctorMapper _doctorMapper;
        public SaveDoctorCommand(DoctorsViewModel doctorsViewModel, IDoctorMapper doctorMapper)
        {
            _doctorsViewModel = doctorsViewModel;
            _doctorMapper = doctorMapper;
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
            Doctor doctor = _doctorMapper.Map(_doctorsViewModel.CurrentValue);
            doctor.CreationDate = DateTime.Now;
            doctor.ModifiedDate = DateTime.Now;
            doctor.Creator = new Admin() { Id = 1 };
            doctor.Modifier = new Admin() { Id = 1 };
            if (doctor.Id==0)
            {
                _doctorsViewModel.Db.DoctorRepository.Insert(doctor);
            }
            else
            {
                _doctorsViewModel.Db.DoctorRepository.Update(doctor);
            }

            _doctorsViewModel.Values.Clear();
            List<Doctor> doctors = _doctorsViewModel.Db.DoctorRepository.Get();
            int no = 1;
            foreach (Doctor doctorItem in doctors)
            {
                DoctorModel doctorModel = _doctorMapper.Map(doctorItem);
                doctorModel.No = no++;
                _doctorsViewModel.Values.Add(doctorModel);
            }

            _doctorsViewModel.SetDefaultValues();
        }
    }
}
