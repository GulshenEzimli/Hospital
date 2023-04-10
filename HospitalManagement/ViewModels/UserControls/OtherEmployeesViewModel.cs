using HospitalManagement.Commands.OtherEmployees;
using HospitalManagement.Enums;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class OtherEmployeesViewModel : BaseViewModel
    {
        public OtherEmployeesViewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            CurrentSituation = 1;
        }

        private int _currentSituation = (int)Situations.NORMAL;
        public int CurrentSituation
        {
            get { return _currentSituation; }
            set
            {
                _currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }

        public AddOtherEmployeeCommand Add => new AddOtherEmployeeCommand(this);
        public DeleteOtherEmployeeCommand Delete => new DeleteOtherEmployeeCommand(this);
        public EditOtherEmployeeCommand Edit => new EditOtherEmployeeCommand(this); 
        public RejectOtherEmployeeCommand Reject => new RejectOtherEmployeeCommand(this);
        public SaveOtherEmployeeCommand Save => new SaveOtherEmployeeCommand(this);

    }
}
