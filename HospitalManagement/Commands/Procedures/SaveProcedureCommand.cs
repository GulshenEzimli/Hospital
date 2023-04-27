using HospitalManagement.Enums;
using HospitalManagement.Models;
using HospitalManagement.Services.Implementations;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Validations;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Procedures
{
    public class SaveProcedureCommand : BaseCommand
    {
        private readonly ProceduresViewModel _procedureViewModel;
        private readonly IProcedureService _procedureService;

        public SaveProcedureCommand(ProceduresViewModel procedureViewModel,IProcedureService procedureService)
        {
            _procedureViewModel = procedureViewModel;
            _procedureService = procedureService;
        }

        public override void Execute(object parameter)
        {
            if (ProcedureValidation.IsValid(_procedureViewModel.CurrentValue, out string message) == false)
            {
                _procedureViewModel.Message = new MessageModel()
                {
                    IsSuccess = false,
                    Message = message
                };

                DoAnimation(_procedureViewModel.ErrorDialog);
                return;

            }
            _procedureService.Save(_procedureViewModel.CurrentValue);

            var procedureModels = _procedureService.GetAll();
            _procedureViewModel.AllValues = procedureModels;
            _procedureViewModel.Values = new ObservableCollection<ProcedureModel>(procedureModels);

            _procedureViewModel.SetDefaultValues();

        }
    }
}
