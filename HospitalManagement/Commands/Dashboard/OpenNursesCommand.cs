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
    public class OpenNursesCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        private readonly INurseMapper _nurseMapper;
        public OpenNursesCommand(DashboardViewModel viewModel,INurseMapper nurseMapper)
        {
            _viewModel = viewModel;
            _nurseMapper = nurseMapper;
        }
        public override void Execute(object parameter)
        {
            NursesViewModel nursesViewModel = new NursesViewModel(_viewModel.Db, _nurseMapper);
            var nurses = _viewModel.Db.NurseRepository.Get();
            int no = 1;
            foreach (var nurse in nurses)
            {
                var nurseModel = _nurseMapper.Map(nurse);
                nurseModel.No = no++;
                nursesViewModel.Values.Add(nurseModel);
            }
            NurseControl nurseControl = new NurseControl();

            nurseControl.DataContext = nursesViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(nurseControl);
        }
    }
}
