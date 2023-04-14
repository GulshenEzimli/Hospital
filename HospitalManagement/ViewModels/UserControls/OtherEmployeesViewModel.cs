using HospitalManagement.Commands.OtherEmployees;
using HospitalManagement.Enums;
using HospitalManagement.Models;
using HospitalManagement.Views.Components;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class OtherEmployeesViewModel : BaseControlViewModel
    {
        public OtherEmployeesViewModel(IUnitOfWork unitOfWork, ErrorDialog errorDialog) : base(unitOfWork, errorDialog)
        {
            SetDefaultValues();
        }
        public override string Header => "Other Employees";

        private Situations _currentSituation;
        public Situations CurrentSituation
        {
            get { return _currentSituation; }
            set
            {
                _currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }

        private OtherEmployeeModel _currentOtherEmployeeValue; 
        public OtherEmployeeModel CurrentOtherEmployeeValue
        {
            get => _currentOtherEmployeeValue;
            set
            {
                _currentOtherEmployeeValue = value;
                OnPropertyChanged(nameof(CurrentOtherEmployeeValue));
            }
        }

        private List<OtherEmployeeModel> _otherEmployeeValues;
        public List<OtherEmployeeModel> OtherEmployeeValues => _otherEmployeeValues ?? (_otherEmployeeValues = new List<OtherEmployeeModel>());

        public AddOtherEmployeeCommand Add => new AddOtherEmployeeCommand(this);
        public DeleteOtherEmployeeCommand Delete => new DeleteOtherEmployeeCommand(this);
        public EditOtherEmployeeCommand Edit => new EditOtherEmployeeCommand(this); 
        public RejectOtherEmployeeCommand Reject => new RejectOtherEmployeeCommand(this);
        public SaveOtherEmployeeCommand Save => new SaveOtherEmployeeCommand(this);

        public void SetDefaultValues()
        {
            CurrentSituation = Situations.NORMAL;
            CurrentOtherEmployeeValue = new OtherEmployeeModel();
        }
    }
}
