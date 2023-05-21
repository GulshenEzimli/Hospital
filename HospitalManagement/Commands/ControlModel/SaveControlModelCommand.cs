using HospitalManagement.Models;
using HospitalManagement.Models.Interfaces;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Validations.Utils;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.ViewModels;
using HospitalManagement.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Validations;
using HospitalManagement.Validations.Interfaces;

namespace HospitalManagement.Commands.ControlModel
{
    public class SaveControlModelCommand<T> : BaseCommand where T : IControlModel,new()
    {
        private readonly BaseControlViewModel<T> _viewModel;
        private readonly IControlModelService<T> _service;
        private readonly IControlModelValidation<T> _validation;
        public SaveControlModelCommand(BaseControlViewModel<T> viewModel, 
                                        IControlModelService<T> service, 
                                        IControlModelValidation<T> validation)
        {
            _viewModel = viewModel;
            _service = service;
            _validation = validation;
        }
        public override void Execute(object parameter)
        {
            if (_validation.IsValid(_viewModel.CurrentValue, out string message) == false)
            {
                _viewModel.Message = new MessageModel
                {
                    IsSuccess = false,
                    Message = message
                };
                DoAnimation(_viewModel.ErrorDialog);
                return;
            }

            _service.Save(_viewModel.CurrentValue);

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
