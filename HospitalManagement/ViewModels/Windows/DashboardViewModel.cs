using HospitalManagement.Commands.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public DropDownEmloyeesCommand DropDown => new DropDownEmloyeesCommand(this);
    }
}
