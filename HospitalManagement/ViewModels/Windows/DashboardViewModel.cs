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
        #region update olunacaq
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDoctorMapper _doctorMapper;
        public DashboardViewModel(IUnitOfWork unitOfWork, IDoctorMapper doctorMapper)
        {
            _unitOfWork = unitOfWork;
            _doctorMapper = doctorMapper;
        }
        public IUnitOfWork Db => _unitOfWork;
        #endregion

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
        public OpenNursesCommand OpenNurses => new OpenNursesCommand(this);
        public OpenOtherEmployeesCommand OpenOtherEmployees => new OpenOtherEmployeesCommand(this);
        public OpenPatientProcedureCommand OpenPatientProcedures => new OpenPatientProcedureCommand(this);
        public OpenPatientsCommand OpenPatients => new OpenPatientsCommand(this);
        public OpenProceduresCommand OpenProcedures => new OpenProceduresCommand(this);
        public OpenReceptionistCommand OpenReceptionists => new OpenReceptionistCommand(this);
        public OpenQueuesCommand OpenQueues => new OpenQueuesCommand(this);
        public OpenAdminsCommand OpenAdmins => new OpenAdminsCommand(this);
        public OpenRoomsCommand OpenRooms => new OpenRoomsCommand(this);


    }
}
