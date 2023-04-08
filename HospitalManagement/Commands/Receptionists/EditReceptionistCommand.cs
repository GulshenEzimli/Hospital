using HospitalManagement.Enums;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Receptionists
{
    public class EditReceptionistCommand:BaseCommand
    {

            private readonly ReceptionistViewModel _receptionistViewModel;
            public EditReceptionistCommand(ReceptionistViewModel receptionistViewModel)
            {
                _receptionistViewModel = receptionistViewModel;
            }
            public override void Execute(object parameter)
            {
                _receptionistViewModel.CurrentSituation = (int)Situations.EDIT;
            }
        
    }
}
