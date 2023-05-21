using HospitalManagement.Enums;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Models;
using HospitalManagement.Models.Interfaces;
using HospitalManagement.Utils;
using HospitalManagement.ViewModels;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Services.Interfaces;

namespace HospitalManagement.Commands.ControlModel
{
    public class DeleteControlModelCommand<T> : BaseCommand where T : IControlModel,new()
    {
        private readonly BaseControlViewModel<T> _viewModel;
        private readonly IControlModelService<T> _service;
        public DeleteControlModelCommand(BaseControlViewModel<T> viewModel, IControlModelService<T> service)
        {
            _viewModel = viewModel;
            _service = service;
        }
        public override void Execute(object parameter)
        {
            SureDialogViewModel sureDialogViewModel = new SureDialogViewModel();
            SureDialog sureDialog = new SureDialog();
            sureDialogViewModel.DialogText = ValidationMessageProvider.GetDeleteOperationSureQuestion();
            sureDialog.DataContext = sureDialogViewModel;
            bool? isSure = sureDialog.ShowDialog();
            if (isSure == false)
                return;

            int id = _viewModel.CurrentValue.Id;
            _service.Delete(id);

            List<T> models = _service.GetAll();
            _viewModel.AllValues = models;
            _viewModel.Values = new ObservableCollection<T>(models);

            _viewModel.SetDefaultValues();

            _viewModel.Message = new MessageModel
            {
                IsSuccess = true,
                Message = ValidationMessageProvider.GetOperationSuccessMessage()
            };
            DoAnimation(_viewModel.ErrorDialog);
        }
    }
}
