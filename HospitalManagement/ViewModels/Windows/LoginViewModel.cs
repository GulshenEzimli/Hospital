using HospitalManagement.Commands;
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
        public LoginViewModel(IAdminService adminService,LoginPage loginPage)
        {
            _adminService = adminService;
            LoginPage = loginPage;
        }
        public LoginPage LoginPage { get; set; }

        public SignInCommand SignIn => new SignInCommand(this, _adminService);

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
