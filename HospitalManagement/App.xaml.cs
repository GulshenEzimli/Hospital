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
            IMapperUnitOfWork mapperUnitOfWork = new MapperUnitOfWork();
            IServiceUnitOfWork serviceUnitOfWork = new ServiceUnitOfWork(db,mapperUnitOfWork);
            
            IPatientMapper patientMapper = new PatientMapper();
            IProcedureMapper procedureMapper=new ProcedureMapper();
            IPatientProcedureMapper patientProcedureMapper = new PatientProcedureMapper();
            IPositionMapper positionMapper = new PositionMapper();
            IOperationMapper operationMapper = new OperationMapper();
            IOperationDoctorMapper operationDoctorMapper = new OperationDoctorMapper();
            IOperationNurseMapper operationNurseMapper  = new OperationNurseMapper();

            DashboardWindow dashboardWindow = new DashboardWindow();
            DashboardViewModel viewModel = new DashboardViewModel(serviceUnitOfWork,patientMapper, procedureMapper, positionMapper, operationMapper, operationDoctorMapper, operationNurseMapper);

            dashboardWindow.DataContext = viewModel;
            viewModel.CenterGrid = dashboardWindow.grdCenter;

            MainWindow = dashboardWindow;
            MainWindow.Show();
        }
    }
}
