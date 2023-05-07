using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.ViewModels.Windows;
using HospitalManagement.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HospitalManagement.Commands
{
    public class SignInCommand : BaseCommand
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAdminService _adminService;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public SignInCommand(LoginViewModel loginViewModel, IAdminService adminService, IServiceUnitOfWork serviceUnitOfWork)
        {
            _loginViewModel = loginViewModel;
            _adminService = adminService;
            _serviceUnitOfWork = serviceUnitOfWork;
        }
        public override void Execute(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var passWord = passwordBox.Password;

            var authorizationSuccess = _adminService.Authorize(_loginViewModel.Username, passWord);
            if(authorizationSuccess)
            {
                DashboardWindow dashboardWindow = new DashboardWindow();
                DashboardViewModel dashboardViewModel = new DashboardViewModel(_serviceUnitOfWork);

                dashboardViewModel.CenterGrid = dashboardWindow.grdCenter;
                dashboardWindow.DataContext = dashboardViewModel;

                dashboardWindow.Show();
                _loginViewModel.LoginPage.Close();
            }
            else _loginViewModel.ErrorVisibility = System.Windows.Visibility.Visible;
        }
    }
}
