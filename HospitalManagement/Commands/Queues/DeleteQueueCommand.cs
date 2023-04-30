using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Validations.Utils;
using HospitalManagement.ViewModels;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Queues
{
    public class DeleteQueueCommand : BaseCommand
    {
        private readonly QueuesViewModel _queueViewModel;
        private readonly IQueueService _queueService;

        public DeleteQueueCommand(QueuesViewModel queueViewModel,IQueueService queueService)
        {
            _queueViewModel = queueViewModel;
            _queueService = queueService;
        }
        public override void Execute(object parameter)
        {
            SureDialog sureDialog = new SureDialog();
            SureDialogViewModel sureDialogViewModel = new SureDialogViewModel();

            sureDialogViewModel.DialogText = ValidationMessageProvider.GetDeleteOperationSureQuestion();
            sureDialog.DataContext=sureDialogViewModel;
            bool? isSure = sureDialog.ShowDialog();
            if (isSure != true)
                return;
            int id = _queueViewModel.CurrentValue.Id;
            _queueService.Delete(id);

            var queueModels = _queueService.GetAll();
            _queueViewModel.AllValues = queueModels;
            _queueViewModel.Values = new ObservableCollection<QueueModel>(queueModels);

            _queueViewModel.Message = new MessageModel()
            {
                Message = ValidationMessageProvider.GetOperationSuccessMessage(),
                IsSuccess = true
            };
            DoAnimation(_queueViewModel.ErrorDialog);
        }
    }
}
