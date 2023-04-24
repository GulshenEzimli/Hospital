using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Services.Implementations;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.ViewModels.Windows;
using HospitalManagement.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Dashboard
{
    public class OpenProceduresCommand:BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        private readonly IProcedureService _procedureService;

        public OpenProceduresCommand(DashboardViewModel viewModel, IProcedureService procedureService)
        {
            _viewModel = viewModel;
            _procedureService = procedureService;
        }

        public override void Execute(object parameter)
        {
            var procedureControl = new ProceduresControl();
            var controlViewModel = new ProceduresViewModel(_procedureService, procedureControl.ErrorDialog);

            var procedureModels = _procedureService.GetAll();
            controlViewModel.AllValues = procedureModels;
            controlViewModel.Values = new ObservableCollection<ProcedureModel>(procedureModels);

            procedureControl.DataContext = controlViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(procedureControl);
        }

    }
}
