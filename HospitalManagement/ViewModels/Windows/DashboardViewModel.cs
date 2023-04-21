using HospitalManagement.Commands.Dashboard;
using HospitalManagement.Mappers.Interfaces;
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
        private readonly IDoctorMapper _doctorMapper;
        private readonly INurseMapper _nurseMapper;
        private readonly IOtherEmployeeMapper _otherEmployeeMapper;
        private readonly IPatientMapper _patientMapper;
        private readonly IProcedureMapper _procedureMapper;
        private readonly IPositionMapper _positionMapper;
        private readonly IPatientProcedureMapper _patientProcedureMapper;
        private readonly IOperationMapper _operationMapper;
        private readonly IOperationDoctorMapper _operationDoctorMapper;
        private readonly IOperationNurseMapper _operationNurseMapper;

        public DashboardViewModel(IUnitOfWork unitOfWork, IDoctorMapper doctorMapper,INurseMapper nurseMapper, 
            IOtherEmployeeMapper otherEmployeeMapper, IPatientMapper patientMapper, IProcedureMapper procedureMapper, 
            IPatientProcedureMapper patientProcedureMapper, IPositionMapper positionMapper, IOperationMapper operationMapper, 
            IOperationDoctorMapper operationDoctorMapper, IOperationNurseMapper operationNurseMapper) : base(unitOfWork)
        {
            _doctorMapper = doctorMapper;
            _nurseMapper = nurseMapper;
            _otherEmployeeMapper = otherEmployeeMapper;
            _patientMapper = patientMapper;
            _procedureMapper = procedureMapper;
            _positionMapper = positionMapper;
            _patientProcedureMapper = patientProcedureMapper;
            _operationMapper = operationMapper;
            _operationDoctorMapper = operationDoctorMapper;
            _operationNurseMapper = operationNurseMapper;
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

        public OpenDoctorsCommand OpenDoctors => new OpenDoctorsCommand(this, _doctorMapper, _positionMapper);
        public OpenNursesCommand OpenNurses => new OpenNursesCommand(this,_nurseMapper);
        public OpenOtherEmployeesCommand OpenOtherEmployees => new OpenOtherEmployeesCommand(this, _otherEmployeeMapper);
        public OpenPatientProcedureCommand OpenPatientProcedures => new OpenPatientProcedureCommand(this, _patientProcedureMapper,_patientMapper,_doctorMapper,_nurseMapper,_procedureMapper);
        public OpenPatientsCommand OpenPatients => new OpenPatientsCommand(this,_patientMapper);
        public OpenProceduresCommand OpenProcedures => new OpenProceduresCommand(this,_procedureMapper);
        public OpenReceptionistCommand OpenReceptionists => new OpenReceptionistCommand(this);
        public OpenQueuesCommand OpenQueues => new OpenQueuesCommand(this);
        public OpenAdminsCommand OpenAdmins => new OpenAdminsCommand(this);
        public OpenRoomsCommand OpenRooms => new OpenRoomsCommand(this);
        public OpenOperationsCommand OpenOperations => new OpenOperationsCommand(this, _operationMapper, _operationDoctorMapper, _operationNurseMapper);

    }
}
