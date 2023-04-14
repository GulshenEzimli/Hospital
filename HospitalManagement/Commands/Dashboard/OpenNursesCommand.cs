using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.ViewModels.Windows;
using HospitalManagement.Views.UserControls;
using HospitalManagementCore.Domain.Entities;
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
            NurseControl nurseControl = new NurseControl();

            NursesViewModel nursesViewModel = new NursesViewModel(_viewModel.Db, _nurseMapper,nurseControl.ErrorDialog);
            var nurses = _viewModel.Db.NurseRepository.Get();
            int no = 1;
            foreach (var nurse in nurses)
            {
                var nurseModel = _nurseMapper.Map(nurse);
                nurseModel.No = no++;
                nursesViewModel.Values.Add(nurseModel);
            }
            List<DoctorPosition> positions = _viewModel.Db.PositionRepository.Get();
            foreach (var position in positions)
            {
                nursesViewModel.PositionNames.Add(position.Name);
            }

            nurseControl.DataContext = nursesViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(nurseControl);
        }
    }
}
