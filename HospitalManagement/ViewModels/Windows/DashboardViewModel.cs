using HospitalManagement.Commands.Dashboard;
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
        public DashboardViewModel()
        {
            
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
        public OpenDoctorsCommand OpenDoctors => new OpenDoctorsCommand(this);
        public OpenNursesCommand OpenNurses => new OpenNursesCommand(this);

        public OpenOtherEmployeesCommand OpenOtherEmployees => new OpenOtherEmployeesCommand(this);
        public OpenPatientsCommand OpenPatients => new OpenPatientsCommand(this);
        public OpenProceduresCommand OpenProcedures=> new OpenProceduresCommand(this);
        public OpenReceptionistCommand OpenReceptionists => new OpenReceptionistCommand(this);
        public OpenRoomsCommand OpenRooms => new OpenRoomsCommand(this);

    }
}
