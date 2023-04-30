﻿using HospitalManagement.Commands.Dashboard;
using HospitalManagement.Mappers.Implementations;
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
        private readonly IPatientMapper _patientMapper;
        private readonly IProcedureMapper _procedureMapper;
        private readonly IQueueMapper _queueMapper;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;

        public DashboardViewModel(IServiceUnitOfWork serviceUnitOfWork,
            IPatientMapper patientMapper, IProcedureMapper procedureMapper,
            IQueueMapper queueMapper)
        {
            _patientMapper = patientMapper;
            _procedureMapper = procedureMapper;
            _queueMapper = queueMapper;
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
        public OpenNursesCommand OpenNurses => new OpenNursesCommand(this,_serviceUnitOfWork);
        public OpenOtherEmployeesCommand OpenOtherEmployees => new OpenOtherEmployeesCommand(this, _serviceUnitOfWork);
        public OpenPatientProcedureCommand OpenPatientProcedures => new OpenPatientProcedureCommand(this, _serviceUnitOfWork);
        public OpenPatientsCommand OpenPatients => new OpenPatientsCommand(this,_serviceUnitOfWork.patientService);
        public OpenProceduresCommand OpenProcedures => new OpenProceduresCommand(this,_serviceUnitOfWork.procedureService);
        public OpenReceptionistCommand OpenReceptionists => new OpenReceptionistCommand(this, _serviceUnitOfWork);
        public OpenQueuesCommand OpenQueues => new OpenQueuesCommand(this, _serviceUnitOfWork);
        public OpenAdminsCommand OpenAdmins => new OpenAdminsCommand(this, _serviceUnitOfWork);
        public OpenRoomsCommand OpenRooms => new OpenRoomsCommand(this, _serviceUnitOfWork);
        public OpenOperationsCommand OpenOperations => new OpenOperationsCommand(this, _serviceUnitOfWork);

    }
}
