using HospitalManagement.Services.Interfaces;
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
    public class OpenAdminsCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        private readonly IAdminService _adminService;

        public OpenAdminsCommand(DashboardViewModel viewModel, IAdminService adminService)
        {
            _viewModel = viewModel;
            _adminService = adminService;
        }
        public override void Execute(object parameter)
        {
            AdminControl adminControl = new AdminControl();
            //AdminsViewModel adminsViewModel = new AdminsViewModel(_viewModel.Db);

            //var adminmodels = _serviceUnitOfWork.adminService.GetAll();


            //adminControl.DataContext = adminsViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(adminControl);
        }
    }
}
