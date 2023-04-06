using HospitalManagement.Enums;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Nurses
{
    public class EditNurseCommand : BaseCommand
    {
        private readonly NursesViewModel _nursesViewModel;
        public EditNurseCommand(NursesViewModel nursesViewModel)
        {
            _nursesViewModel = nursesViewModel;
        }
        public override void Execute(object parameter)
        {
            _nursesViewModel.CurrentSituation = (int)Situations.EDIT;
        }
    }
}
