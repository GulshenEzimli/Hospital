using HospitalManagement.Commands;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HospitalManagement.ViewModels.Windows
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAdminService _adminService;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public LoginViewModel(IAdminService adminService, IServiceUnitOfWork serviceUnitOfWork,LoginPage loginPage)
        {
            _adminService = adminService;
            _serviceUnitOfWork = serviceUnitOfWork;
            LoginPage = loginPage;
        }
        public LoginPage LoginPage { get; set; }

        public SignInCommand SignIn => new SignInCommand(this, _adminService,_serviceUnitOfWork);

        private string _username;
        public string Username
        {
            get => _username; set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private Visibility _errorVisibility = Visibility.Collapsed;
        public Visibility ErrorVisibility
        {
            get => _errorVisibility;
            set
            {
                _errorVisibility = value;
                OnPropertyChanged(nameof(ErrorVisibility));
            }
        }
    }
}
