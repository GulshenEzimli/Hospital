using HospitalManagement.Enums;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Utils;
using HospitalManagement.ViewModels.UserControls;
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
            if(IsValid(_nursesViewModel.CurrentValue,out string message) == false)
            {
                return;
            }

            var nurse = _nurseMapper.Map(_nursesViewModel.CurrentValue);

            if (nurse.Id == 0)
            {
                _nursesViewModel.Db.NurseRepository.Insert(nurse);
            }
            else
            {
                _nursesViewModel.Db.NurseRepository.Update(nurse);
            }
            _nursesViewModel.CurrentSituation = (int)Situations.NORMAL;
        }

        private bool IsValid(NurseModel nurseModel,out string message)
        {
            if (string.IsNullOrWhiteSpace(nurseModel.FirstName))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Name");
                return false;
            }
            if(nurseModel.FirstName.Length > 25)
            {
                message = ValidationMessageProvider.GetLengthMessage("Name",25);
                return false;
            }
            if (string.IsNullOrWhiteSpace(nurseModel.LastName))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Surname");
                return false;
            }
            if (nurseModel.LastName.Length > 25)
            {
                message = ValidationMessageProvider.GetLengthMessage("Surname", 25);
                return false;
            }

            if (string.IsNullOrWhiteSpace(nurseModel.PhoneNumber))
            {
                message = ValidationMessageProvider.GetRequiredMessage("PhoneNumber");
                return false;
            }
            if(nurseModel.PhoneNumber.Length != 13)
            {
                message = ValidationMessageProvider.GetSpecificLength("PhoneNumber",13);
                return false;
            }
            if (string.IsNullOrWhiteSpace(nurseModel.PIN))
            {
                message = ValidationMessageProvider.GetRequiredMessage("PIN");
                return false;
            }
            if (nurseModel.PIN.Length != 7)
            {
                message = ValidationMessageProvider.GetSpecificLength("PIN", 7);
                return false;
            }

            if (string.IsNullOrWhiteSpace(nurseModel.Email))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Email");
                return false;
            }
            if (nurseModel.Email.Length > 50)
            {
                message = ValidationMessageProvider.GetLengthMessage("Email", 50);
                return false;
            }

            if(nurseModel.Salary < 0)
            {
                message = ValidationMessageProvider.GetSalaryMessage(); 
                return false;
            }
            if (nurseModel.Salary > 10000)
            {
                message = ValidationMessageProvider.GetSalaryMessage(10000);
                return false;
            }

            message = null;
            return true;
        }
    }
}
