using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Queues
{
    public class DeleteQueueCommand : BaseCommand
    {
        private readonly QueuesViewModel _queueViewModel;
        public DeleteQueueCommand(QueuesViewModel queueViewModel)
        {
            _queueViewModel = queueViewModel;
        }
        public override void Execute(object parameter)
        {

        }
    }
}
