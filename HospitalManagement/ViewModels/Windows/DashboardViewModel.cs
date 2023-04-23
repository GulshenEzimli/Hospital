﻿using HospitalManagement.Commands.Dashboard;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Services.Interfaces;
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
        private readonly IOtherEmployeeMapper _otherEmployeeMapper;
        private readonly IPatientMapper _patientMapper;
        private readonly IProcedureMapper _procedureMapper;
        private readonly IPositionMapper _positionMapper;
        private readonly IPatientProcedureMapper _patientProcedureMapper;
        private readonly IOperationMapper _operationMapper;
        private readonly IOperationDoctorMapper _operationDoctorMapper;
        private readonly IOperationNurseMapper _operationNurseMapper;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;

        public DashboardViewModel(IServiceUnitOfWork serviceUnitOfWork,
            IOtherEmployeeMapper otherEmployeeMapper, IPatientMapper patientMapper, IProcedureMapper procedureMapper, 
            IPatientProcedureMapper patientProcedureMapper, IPositionMapper positionMapper, IOperationMapper operationMapper, 
            IOperationDoctorMapper operationDoctorMapper, IOperationNurseMapper operationNurseMapper) 
        {
            _otherEmployeeMapper = otherEmployeeMapper;
            _patientMapper = patientMapper;
            _procedureMapper = procedureMapper;
            _positionMapper = positionMapper;
            _patientProcedureMapper = patientProcedureMapper;
            _operationMapper = operationMapper;
            _operationDoctorMapper = operationDoctorMapper;
            _operationNurseMapper = operationNurseMapper;
            _serviceUnitOfWork = serviceUnitOfWork;
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

        public OpenDoctorsCommand OpenDoctors => new OpenDoctorsCommand(this, _serviceUnitOfWork);
        public OpenNursesCommand OpenNurses => new OpenNursesCommand(this, _serviceUnitOfWork.nurseService);
        public OpenOtherEmployeesCommand OpenOtherEmployees => new OpenOtherEmployeesCommand(this, _serviceUnitOfWork.otherEmployeeService);
        public OpenPatientProcedureCommand OpenPatientProcedures => new OpenPatientProcedureCommand(this, _serviceUnitOfWork.patientProcedureService);
        public OpenPatientsCommand OpenPatients => new OpenPatientsCommand(this,_patientMapper);
        public OpenProceduresCommand OpenProcedures => new OpenProceduresCommand(this,_procedureMapper);
        public OpenReceptionistCommand OpenReceptionists => new OpenReceptionistCommand(this);
        public OpenQueuesCommand OpenQueues => new OpenQueuesCommand(this);
        public OpenAdminsCommand OpenAdmins => new OpenAdminsCommand(this);
        public OpenRoomsCommand OpenRooms => new OpenRoomsCommand(this);
        public OpenOperationsCommand OpenOperations => new OpenOperationsCommand(this, _operationMapper, _operationDoctorMapper, _operationNurseMapper);

    }
}
