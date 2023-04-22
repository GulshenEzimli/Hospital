using HospitalManagement.Models;
using HospitalManagement.Validations.Utils;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagement.Commands.Nurses
{
    public class DeleteNurseCommand : BaseCommand
    {
        private readonly NursesViewModel _nursesViewModel;
        public DeleteNurseCommand(NursesViewModel nursesViewModel)
        {
            _nursesViewModel = nursesViewModel;
        }

        public override void Execute(object parameter)
        {
            var id = _nursesViewModel.SelectedValue.Id;
            var nurse = _nursesViewModel.Db.NurseRepository.GetById(id);

            nurse.IsDelete = true;
            nurse.ModifiedDate = DateTime.Now;
            nurse.Modifier = new Admin() { Id = 3 };

            _nursesViewModel.Db.NurseRepository.Update(nurse);

            _nursesViewModel.Message = new MessageModel
            {
                IsSuccess = true,
                Message = ValidationMessageProvider.GetOperationSuccessMessage(),
            };
            DoAnimation(_nursesViewModel.ErrorDialog);
        }
    }
}
