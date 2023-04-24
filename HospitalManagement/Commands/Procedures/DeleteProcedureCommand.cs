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

namespace HospitalManagement.Commands.Procedures
{
    public class DeleteProcedureCommand : BaseCommand
    {
        private readonly ProceduresViewModel _procedureViewModel;
        private readonly IProcedureService _procedureService;
        public DeleteProcedureCommand(ProceduresViewModel procedureViewModel,IProcedureService procedureService)
        {
            _procedureViewModel = procedureViewModel;
            _procedureService = procedureService;
        }
        public override void Execute(object parameter)
        {
            SureDialogViewModel sureDialogViewModel = new SureDialogViewModel();
            SureDialog sureDialog=new SureDialog();

            sureDialogViewModel.DialogText = ValidationMessageProvider.GetDeleteOperationSureQuestion();
            sureDialog.DataContext= sureDialogViewModel;

            var isSure = sureDialog.ShowDialog();
            if (isSure != true)
                return;
            var id = _procedureViewModel.SelectValue.Id;
            _procedureService.Delete(id);

            var procedureModels=_procedureService.GetAll();
            _procedureViewModel.AllValues = procedureModels;
            _procedureViewModel.Values = new ObservableCollection<ProcedureModel>(procedureModels);

            _procedureViewModel.Message = new MessageModel()
            {
                IsSuccess = true,
                Message = ValidationMessageProvider.GetOperationSuccessMessage()
            };
            DoAnimation(_procedureViewModel.ErrorDialog);
        }
    }
}
