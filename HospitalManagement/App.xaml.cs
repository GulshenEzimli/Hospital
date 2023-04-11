﻿using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.ViewModels.Windows;
using HospitalManagement.Views.Windows;
using HospitalManagementCore.DataAccess.Implementations.SqlServer;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "GULSHAN\\SQLEXPRESS";
            builder.InitialCatalog = "Hospital";
            builder.IntegratedSecurity = true;

            IUnitOfWork db = new SqlUnitOfWork(builder.ConnectionString);
            IDoctorMapper doctorMapper = new DoctorMapper();
            INurseMapper nurseMapper = new NurseMapper();
            IOtherEmployeeMapper otherEmployeeMapper = new OtherEmployeeMapper();
            DashboardWindow dashboardWindow = new DashboardWindow();
            DashboardViewModel viewModel = new DashboardViewModel(db, doctorMapper,nurseMapper, otherEmployeeMapper);

            dashboardWindow.DataContext = viewModel;
            viewModel.CenterGrid = dashboardWindow.grdCenter;

            MainWindow = dashboardWindow;
            MainWindow.Show();
        }
    }
}
