using HospitalManagement.Enums;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Validations;
using HospitalManagement.Validations.Utils;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Queues
{
    public class SaveQueueCommand: BaseCommand
    {
        private readonly QueuesViewModel _queueViewModel;
        private readonly IQueueService _queueService;

        public SaveQueueCommand(QueuesViewModel queueViewModel,IQueueService queueService)
        {
            _queueViewModel = queueViewModel;
            _queueService = queueService;
        }

        public override void Execute(object parameter)
        {
            if (QueueValidation.IsValid(_queueViewModel.CurrentValue, out string message) == false)
            {
                _queueViewModel.Message = new MessageModel()
                {
                    Message = message,
                    IsSuccess = true
                };
                DoAnimation(_queueViewModel.ErrorDialog);
                return;
            }

            _queueService.Save(_queueViewModel.CurrentValue);

            var queueModels = _queueService.GetAll();
            _queueViewModel.AllValues = queueModels;
            _queueViewModel.Values = new ObservableCollection<QueueModel>(queueModels);

            _queueViewModel.SetDefaultValues();
            _queueViewModel.Message = new MessageModel()
            {
                Message = ValidationMessageProvider.GetOperationSuccessMessage(),
                IsSuccess = true
            };
            DoAnimation(_queueViewModel.ErrorDialog);
        }
    }
}
