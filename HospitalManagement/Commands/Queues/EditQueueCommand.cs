using HospitalManagement.Enums;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Queues
{
    public class EditQueueCommand : BaseCommand
    {
        private readonly QueuesViewModel _queueViewModel;
        public EditQueueCommand(QueuesViewModel queueViewModel)
        {
            _queueViewModel = queueViewModel;
        }

        public override void Execute(object parameter)
        {
            _queueViewModel.CurrentSituation = Situations.EDIT;
        }
    }
}
