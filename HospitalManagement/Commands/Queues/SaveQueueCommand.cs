using HospitalManagement.Enums;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Queues
{
    public class SaveQueueCommand: BaseCommand
    {
        private readonly QueuesViewModel _queueViewModel;
        public SaveQueueCommand(QueuesViewModel queueViewModel)
        {
            _queueViewModel = queueViewModel;
        }

        public override void Execute(object parameter)
        {
            //TO DO:IMPLEMENT SAVE
            _queueViewModel.CurrentSituation = (int)Situations.NORMAL;
        }
    }
}
