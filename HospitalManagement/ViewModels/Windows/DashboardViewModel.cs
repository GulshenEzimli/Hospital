﻿using HospitalManagement.Commands.Dashboard;
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
        public DashboardViewModel(IUnitOfWork unitOfWork, IDoctorMapper doctorMapper,INurseMapper nurseMapper, IOtherEmployeeMapper otherEmployeeMapper) : base(unitOfWork)
        private readonly IPatientMapper _patientMapper;

        public DashboardViewModel(IUnitOfWork unitOfWork, IDoctorMapper doctorMapper,INurseMapper nurseMapper,IPatientMapper patientMapper) : base(unitOfWork)
        {
            _doctorMapper = doctorMapper;
            _nurseMapper = nurseMapper;
            _otherEmployeeMapper = otherEmployeeMapper;
            _patientMapper = patientMapper;
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

        public OpenDoctorsCommand OpenDoctors => new OpenDoctorsCommand(this, _doctorMapper);
        public OpenNursesCommand OpenNurses => new OpenNursesCommand(this,_nurseMapper);
        public OpenOtherEmployeesCommand OpenOtherEmployees => new OpenOtherEmployeesCommand(this, _otherEmployeeMapper);
        public OpenPatientProcedureCommand OpenPatientProcedures => new OpenPatientProcedureCommand(this);
        public OpenPatientsCommand OpenPatients => new OpenPatientsCommand(this,_patientMapper);
        public OpenProceduresCommand OpenProcedures => new OpenProceduresCommand(this);
        public OpenReceptionistCommand OpenReceptionists => new OpenReceptionistCommand(this);
        public OpenQueuesCommand OpenQueues => new OpenQueuesCommand(this);
        public OpenAdminsCommand OpenAdmins => new OpenAdminsCommand(this);
        public OpenRoomsCommand OpenRooms => new OpenRoomsCommand(this);


    }
}
