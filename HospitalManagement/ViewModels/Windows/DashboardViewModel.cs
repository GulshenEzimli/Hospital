using HospitalManagement.Commands.Dashboard;
using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.Views.UserControls;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HospitalManagement.ViewModels.Windows
{
    public class DashboardViewModel : BaseViewModel
    {
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

        public DashboardViewModel( IAdminService adminService,
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
            _adminService = adminService;
            _doctorService = doctorService;
            _patientService = patientService;
            _jobService = jobService;
            _positionService = positionService;
            _patientProcedureService = patientProcedureService;
            _nurseService=nurseService;
            _otherEmployeeService=otherEmployeeService;
            _procedureService=procedureService;
            _queueService=queueService;
            _roomService = roomService;
            _receptionistService=receptionistService;
            _operationService = operationService;
        }

        private bool _employeeSituation = false;
        public bool EmployeeSituation
        {
            get { return _employeeSituation; }
            set
            {
                _employeeSituation = value;
                OnPropertyChanged(nameof(EmployeeSituation));
            }
        }

        public Grid CenterGrid { get; set; }

        public DropDownEmloyeesCommand DropDown => new DropDownEmloyeesCommand(this);
        public OpenAdminsCommand OpenAdmins => new OpenAdminsCommand(this, _adminService);

        public OpenControlModelCommand<DoctorModel> OpenDoctors
        {
            get
            {
                Func<DoctorControl> controlCreator = () => new DoctorControl();

                Func<UserControl, DoctorsViewModel> controlViewModelCreator = (control) =>
                {
                    DoctorControl concreteControl = (DoctorControl)control;

                    return new DoctorsViewModel(_positionService, _doctorService, concreteControl.ErrorDialog);
                };

                return new OpenControlModelCommand<DoctorModel>(this, _doctorService, controlCreator, controlViewModelCreator);
            }
        }

        public OpenControlModelCommand<NurseModel> OpenNurses
        {
            get
            {
                Func<NurseControl> controlCreator = () => new NurseControl();

                Func<UserControl, NursesViewModel> controlViewModelCreator = (control) =>
                {
                    NurseControl concreteControl = (NurseControl)control;

                    return new NursesViewModel(_positionService, _nurseService, concreteControl.ErrorDialog);
                };

                return new OpenControlModelCommand<NurseModel>(this, _nurseService, controlCreator, controlViewModelCreator);
            }
        }

        public OpenControlModelCommand<OtherEmployeeModel> OpenOtherEmployees
        {
            get
            {
                Func<OtherEmployeesControl> controlCreator = () => new OtherEmployeesControl();

                Func<UserControl, OtherEmployeesViewModel> controlViewModelCreator = (control) =>
                {
                    OtherEmployeesControl concreteControl = (OtherEmployeesControl)control;

                    return new OtherEmployeesViewModel(_jobService, _otherEmployeeService, concreteControl.ErrorDialog);
                };

                return new OpenControlModelCommand<OtherEmployeeModel>(this, _otherEmployeeService, controlCreator, controlViewModelCreator);
            }
        }

        public OpenControlModelCommand<PatientProcedureModel> OpenPatientProcedures
        {
            get
            {
                Func<PatientProcedureControl> controlCreator = () => new PatientProcedureControl();

                Func<UserControl, PatientProcedureViewModel> controlViewModelCreator = (control) =>
                {
                    PatientProcedureControl concreteControl = (PatientProcedureControl)control;

                    return new PatientProcedureViewModel(_patientService, _doctorService, _nurseService, _procedureService, _patientProcedureService, concreteControl.ErrorDialog);
                };

                return new OpenControlModelCommand<PatientProcedureModel>(this, _patientProcedureService, controlCreator, controlViewModelCreator);
            }
        }

        public OpenControlModelCommand<PatientModel> OpenPatients
        {
            get
            {
                Func<PatientControls> controlCreator = () => new PatientControls();

                Func<UserControl, PatientsViewModel> controlViewModelCreator = (control) =>
                {
                    PatientControls concreteControl = (PatientControls)control;

                    return new PatientsViewModel(_patientService, concreteControl.ErrorDialog);
                };

                return new OpenControlModelCommand<PatientModel>(this, _patientService, controlCreator, controlViewModelCreator);
            }
        }

        public OpenControlModelCommand<ProcedureModel> OpenProcedures
        {
            get
            {
                Func<ProceduresControl> controlCreator = () => new ProceduresControl();

                Func<UserControl, ProceduresViewModel> controlViewModelCreator = (control) =>
                {
                    ProceduresControl concreteControl = (ProceduresControl)control;

                    return new ProceduresViewModel(_procedureService, concreteControl.ErrorDialog);
                };

                return new OpenControlModelCommand<ProcedureModel>(this, _procedureService, controlCreator, controlViewModelCreator);
            }
        }

        public OpenControlModelCommand<ReceptionistModel> OpenReceptionists
        {
            get
            {
                Func<ReceptionistControl> controlCreator = () => new ReceptionistControl();

                Func<UserControl, ReceptionistViewModel> controlViewModelCreator = (control) =>
                {
                    ReceptionistControl concreteControl = (ReceptionistControl)control;

                    return new ReceptionistViewModel(_jobService,_receptionistService, concreteControl.ErrorDialog);
                };

                return new OpenControlModelCommand<ReceptionistModel>(this, _receptionistService, controlCreator, controlViewModelCreator);
            }
        }

        public OpenControlModelCommand<QueueModel> OpenQueues
        {
            get
            {
                Func<QueuesControl> controlCreator = () => new QueuesControl();

                Func<UserControl, QueuesViewModel> controlViewModelCreator = (control) =>
                {
                    QueuesControl concreteControl = (QueuesControl)control;

                    return new QueuesViewModel(_patientService, _doctorService, _procedureService, _queueService, concreteControl.ErrorDialog);
                };

                return new OpenControlModelCommand<QueueModel>(this, _queueService, controlCreator, controlViewModelCreator);
            }
        }

        public OpenControlModelCommand<RoomModel> OpenRooms
        {
            get
            {
                Func<RoomControl> controlCreator = () => new RoomControl();

                Func<UserControl, RoomsViewModel> controlViewModelCreator = (control) =>
                {
                    RoomControl concreteControl = (RoomControl)control;

                    return new RoomsViewModel(_roomService, concreteControl.ErrorDialog);
                };

                return new OpenControlModelCommand<RoomModel>(this, _roomService, controlCreator, controlViewModelCreator);
            }
        }

        public OpenControlModelCommand<OperationModel> OpenOperations
        {
            get
            {
                Func<OperationControl> controlCreator = () => new OperationControl();

                Func<UserControl, OperationsViewModel> controlViewModelCreator = (control) =>
                {
                    OperationControl concreteControl = (OperationControl)control;

                    return new OperationsViewModel(_patientService, _roomService, _doctorService, _nurseService, _operationService,concreteControl.ErrorDialog);
                };

                return new OpenControlModelCommand<OperationModel>(this, _operationService, controlCreator, controlViewModelCreator);
            }
        }

    }
}
