using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.ViewModels.Windows;
using HospitalManagement.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Dashboard
{
    public class OpenProceduresCommand:BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        private readonly IProcedureMapper _procedureMapper;

        public OpenProceduresCommand(DashboardViewModel viewModel, IProcedureMapper procedureMapper)
        {
            _viewModel = viewModel;
            _procedureMapper = procedureMapper;
        }

        public override void Execute(object parameter)
        {
            var controlViewModel = new ProceduresViewModel(_viewModel.Db);
            var proceduresControl = new ProceduresControl();

            int no = 1;
            var procedures = _viewModel.Db.ProcedureRepository.Get();

            foreach(var procedure in procedures)
            {
                var procedureModel = _procedureMapper.Map(procedure);
                procedureModel.No = no++;
                controlViewModel.Values.Add(procedureModel);
            }
            proceduresControl.DataContext = controlViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(proceduresControl);
        }

    }
}
