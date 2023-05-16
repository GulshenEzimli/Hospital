using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Services.Implementations;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.ViewModels.Windows;
using HospitalManagement.Views.Windows;
using HospitalManagementCore.DataAccess.Implementations.SqlServer;
using HospitalManagementCore.DataAccess.Interfaces;
using System.Data.SqlClient;
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

            builder.DataSource = "localhost";
            builder.InitialCatalog = "Hospital";
            builder.IntegratedSecurity = true;

            IUnitOfWork db = new SqlUnitOfWork(builder.ConnectionString);
            IAdminService adminService = new AdminService(db);
            IMapperUnitOfWork mapperUnitOfWork = new MapperUnitOfWork();
            IServiceUnitOfWork serviceUnitOfWork = new ServiceUnitOfWork(db,mapperUnitOfWork);

            LoginPage loginPage = new LoginPage();
            LoginViewModel loginViewModel = new LoginViewModel(adminService, serviceUnitOfWork,loginPage);
            loginPage.DataContext = loginViewModel;
            
            MainWindow = loginPage;
            MainWindow.Show();
        }
    }
}
