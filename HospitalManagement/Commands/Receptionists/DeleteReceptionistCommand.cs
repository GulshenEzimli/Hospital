using HospitalManagement.ViewModels;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Receptionists
{
    internal class DeleteReceptionistCommand:BaseCommand
    { 
        private readonly ReceptionistViewModel _receptionistViewModel;
        public DeleteReceptionistCommand(ReceptionistViewModel receptionistViewModel)
        {
            _receptionistViewModel = receptionistViewModel;
        }

        public override void Execute(object parameter)
        {

        }
    }
}
