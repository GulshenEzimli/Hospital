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

            var toBeSavedNurse = _nurseMapper.Map(_nursesViewModel.CurrentValue);
            toBeSavedNurse.ModifiedDate = DateTime.Now;
            toBeSavedNurse.Modifier = new Admin() { Id = 3 };

            if (toBeSavedNurse.Id == 0)
            {
                toBeSavedNurse.CreationDate = DateTime.Now;
                toBeSavedNurse.Creator = new Admin() { Id = 3 };
                toBeSavedNurse.IsDelete = false;
                _nursesViewModel.Db.NurseRepository.Insert(toBeSavedNurse);
                _nursesViewModel.CurrentValue.No = _nursesViewModel.Values.LastOrDefault()?.No + 1 ?? 1;
                _nursesViewModel.Values.Add(_nursesViewModel.CurrentValue);
            }
            else
            {
                var existingNurse = _nursesViewModel.Db.NurseRepository.GetById(_nursesViewModel.CurrentValue.Id);
                toBeSavedNurse.Creator = existingNurse.Creator;
                toBeSavedNurse.CreationDate = existingNurse.CreationDate;
                toBeSavedNurse.IsDelete = existingNurse.IsDelete;
                _nursesViewModel.Db.NurseRepository.Update(toBeSavedNurse);

                var existingValue = _nursesViewModel.Values.FirstOrDefault(x=>x.Id==existingNurse.Id);
                var existValueIndex = _nursesViewModel.Values.IndexOf(existingValue);
                _nursesViewModel.Values[existValueIndex] = _nursesViewModel.CurrentValue;
            }

           
            _nursesViewModel.SetDefaultValues();
        }
    }
}
