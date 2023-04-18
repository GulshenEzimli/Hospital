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

namespace HospitalManagement.Commands.Nurses
{
    public class SaveNurseCommand : BaseCommand
    {
        private readonly NursesViewModel _nursesViewModel;
        private readonly INurseMapper _nurseMapper;
        public SaveNurseCommand(NursesViewModel nursesViewModel, INurseMapper nurseMapper)
        {
            _nursesViewModel = nursesViewModel;
            _nurseMapper = nurseMapper;
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

            var nurse = _nurseMapper.Map(_nursesViewModel.CurrentValue);
            nurse.CreationDate = DateTime.Now;
            nurse.ModifiedDate = DateTime.Now;
            nurse.IsDelete = false;
            nurse.Creator = new Admin() { Id = 3 };
            nurse.Modifier = new Admin() { Id = 3 };
            nurse.Position = new DoctorPosition() { Name = _nursesViewModel.CurrentValue.PositionName };

            if (nurse.Id == 0)
            {
                _nursesViewModel.Db.NurseRepository.Insert(nurse);
            }
            else
            {
                _nursesViewModel.Db.NurseRepository.Update(nurse);
            }

            _nursesViewModel.CurrentValue.No = _nursesViewModel.Values.LastOrDefault()?.No + 1 ?? 1;
            _nursesViewModel.Values.Add(_nursesViewModel.CurrentValue);
            _nursesViewModel.SetDefaultValues();
        }
    }
}
