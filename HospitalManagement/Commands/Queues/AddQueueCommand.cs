﻿using HospitalManagement.Enums;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Queues
{
    public class AddQueueCommand : BaseCommand
    {
        private readonly QueuesViewModel _queueViewModel;

        public AddQueueCommand(QueuesViewModel queueViewModel)
        {
            _queueViewModel = queueViewModel;
        }
        public override void Execute(object parameter)
        {
            _queueViewModel.CurrentSituation = Situations.ADD;
        }
    }
}
