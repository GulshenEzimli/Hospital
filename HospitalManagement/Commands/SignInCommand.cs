using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models.Implementations;
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
        private readonly IControlModelService<DoctorModel> _doctorService;
        private readonly IControlModelService<PatientModel> _patientService;
        private readonly IControlModelService<NurseModel> _nurseService;
        private readonly IControlModelService<OtherEmployeeModel> _otherEmployeeService;
        private readonly IControlModelService<ProcedureModel> _procedureService;
        private readonly IControlModelService<QueueModel> _queueService;
        private readonly IControlModelService<OperationModel> _operationService;
        private readonly IControlModelService<ReceptionistModel> _receptionistService;
        private readonly IControlModelService<RoomModel> _roomService;
        private readonly IControlModelService<PatientProcedureModel> _patientProcedureService;
        private readonly IControlModelService<JobModel> _jobService;
        private readonly IControlModelService<PositionModel> _positionService;
        public SignInCommand(LoginViewModel loginViewModel, IAdminService adminService,
                                   IControlModelService<DoctorModel> doctorService,
                                   IControlModelService<PatientModel> patientService,
                                   IControlModelService<NurseModel> nurseService,
                                   IControlModelService<OtherEmployeeModel> otherEmployeeService,
                                   IControlModelService<ProcedureModel> procedureService,
                                   IControlModelService<QueueModel> queueService,
                                   IControlModelService<OperationModel> operationService,
                                   IControlModelService<ReceptionistModel> receptionistService,
                                   IControlModelService<RoomModel> roomService,
                                   IControlModelService<PatientProcedureModel> patientProcedureService,
                                   IControlModelService<JobModel> jobService,
                                   IControlModelService<PositionModel> positionService)
        {
            _loginViewModel = loginViewModel;
            _adminService = adminService;
            _doctorService = doctorService;
            _patientService = patientService;
            _jobService = jobService;
            _positionService = positionService;
            _patientProcedureService = patientProcedureService;
            _nurseService = nurseService;
            _otherEmployeeService = otherEmployeeService;
            _procedureService = procedureService;
            _queueService = queueService;
            _roomService = roomService;
            _receptionistService = receptionistService;
            _operationService = operationService;
        }
        public override void Execute(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var passWord = passwordBox.Password;

            var authorizationSuccess = _adminService.Authorize(_loginViewModel.Username, passWord);
            if(authorizationSuccess)
            {
                DashboardWindow dashboardWindow = new DashboardWindow();
                DashboardViewModel dashboardViewModel = new DashboardViewModel(_adminService, _doctorService, _patientService,
                                                                                _nurseService, _otherEmployeeService, _procedureService, 
                                                                                _queueService, _operationService, _receptionistService,
                                                                                _roomService, _patientProcedureService,
                                                                                _jobService, _positionService);

                dashboardViewModel.CenterGrid = dashboardWindow.grdCenter;
                dashboardWindow.DataContext = dashboardViewModel;

                dashboardWindow.Show();
                _loginViewModel.LoginPage.Close();
            }
            else _loginViewModel.ErrorVisibility = System.Windows.Visibility.Visible;
        }
    }
}
