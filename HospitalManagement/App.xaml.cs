using HospitalManagement.ViewModels.Windows;
using HospitalManagement.Views.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HospitalManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DashboardWindow dashboardWindow = new DashboardWindow();
            DashboardViewModel viewModel = new DashboardViewModel();

            dashboardWindow.DataContext = viewModel;
            MainWindow = dashboardWindow;
            MainWindow.Show();
        }
    }
}
