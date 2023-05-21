using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Services.Implementations;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.ViewModels.Windows;
using HospitalManagement.Views.Windows;
using HospitalManagementCore.DataAccess.Implementations.SqlServer;
using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
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

            #region Mappers
            IControlModelMapper<DoctorPosition, PositionModel> positionMapper = new PositionMapper();
            IControlModelMapper<Job, JobModel> jobMapper = new JobMapper();
            IControlModelMapper<Room, RoomModel> roomMapper = new RoomMapper();
            IControlModelMapper<Doctor, DoctorModel> doctorMapper = new DoctorMapper(positionMapper);
            IControlModelMapper<Patient, PatientModel> patientMapper = new PatientMapper();
            IControlModelMapper<Nurse, NurseModel> nurseMapper = new NurseMapper(positionMapper);
            IControlModelMapper<OtherEmployee, OtherEmployeeModel> otherEmployeeMapper = new OtherEmployeeMapper(jobMapper);
            IControlModelMapper<Procedure, ProcedureModel> procedureMapper = new ProcedureMapper();
            IControlModelMapper<Queue, QueueModel> queueMapper = new QueueMapper(patientMapper,doctorMapper,procedureMapper);
            IControlModelMapper<Operation, OperationModel> operationMapper = new OperationMapper(patientMapper, roomMapper, nurseMapper, doctorMapper);
            IControlModelMapper<Receptionist, ReceptionistModel> receptionistMapper = new ReceptionistMapper();
            IControlModelMapper<PatientProcedure, PatientProcedureModel> patientProcedureMapper = new PatientProcedureMapper(patientMapper, nurseMapper, doctorMapper,procedureMapper);
            #endregion

            #region Services
            IAdminService adminService = new AdminService(db);
            IControlModelService<DoctorModel> doctorService = new DoctorService(db,doctorMapper);
            IControlModelService<PatientModel> patientService = new PatientService(db,patientMapper);
            IControlModelService<NurseModel> nurseService = new NurseService(db,nurseMapper);
            IControlModelService<OtherEmployeeModel> otherEmployeeService = new OtherEmployeeService(db,otherEmployeeMapper);
            IControlModelService<ProcedureModel> procedureService = new ProcedureService(db,procedureMapper);
            IControlModelService<QueueModel> queueService = new QueueService(db,queueMapper);
            IControlModelService<OperationModel> operationService = new OperationService(db,operationMapper,nurseMapper,doctorMapper);
            IControlModelService<ReceptionistModel> receptionistService = new ReceptionistService(db,receptionistMapper);
            IControlModelService<RoomModel> roomService = new RoomService(db,roomMapper);
            IControlModelService<PatientProcedureModel> patientProcedureService = new PatientProcedureService(db,patientProcedureMapper);
            IControlModelService<JobModel> jobService = new JobService(db,jobMapper);
            IControlModelService<PositionModel> positionService = new PositionService(db,positionMapper);
            #endregion


            LoginPage loginPage = new LoginPage();
            LoginViewModel loginViewModel = new LoginViewModel(adminService, doctorService, patientService,
                                                                nurseService, otherEmployeeService, procedureService, queueService,
                                                                operationService, receptionistService,
                                                                roomService, patientProcedureService,
                                                                jobService, positionService, loginPage);
            loginPage.DataContext = loginViewModel;
            
            MainWindow = loginPage;
            MainWindow.Show();
        }
    }
}
