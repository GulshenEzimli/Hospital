using HospitalManagement.Commands.OtherEmployees;
using HospitalManagement.Enums;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Views.Components;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class OtherEmployeesViewModel : BaseControlViewModel
    {
        private readonly IOtherEmployeeService _otherEmployeeService;
        public OtherEmployeesViewModel(IOtherEmployeeService otherEmployeeService, ErrorDialog errorDialog) : base( errorDialog)
        {
            _otherEmployeeService = otherEmployeeService;
            AllValues = new List<OtherEmployeeModel>();
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

        private OtherEmployeeModel _currentValue; 
        public OtherEmployeeModel CurrentValue
        {
            get => _currentValue;
            set
            {
                _currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }

        private OtherEmployeeModel _selectedValue;
        public OtherEmployeeModel SelectedValue
        {
            get => _selectedValue;
            set
            {
                SetSelectedValue(value);
                if(value == null)
                {
                    SetDefaultValues();
                }
                else
                {
                    CurrentValue = SelectedValue.Clone();
                    CurrentSituation = Situations.SELECTED;
                }
                OnPropertyChanged(nameof(SelectedValue));
            }
        }

        private ObservableCollection<OtherEmployeeModel> _values;
        public ObservableCollection<OtherEmployeeModel> Values
        {
            get => _values ?? (_values = new ObservableCollection<OtherEmployeeModel>());
            set
            {
                _values = value;
                OnPropertyChanged(nameof(Values));
            }
        }

        private List<JobModel> _jobNames;
        public List<JobModel> JobNames
        {
            get => _jobNames ?? (_jobNames = new List<JobModel>());
            set
            {
                _jobNames = value;
            }
        }

        public List<OtherEmployeeModel> AllValues { get; set; }

        public AddOtherEmployeeCommand Add => new AddOtherEmployeeCommand(this);
        public DeleteOtherEmployeeCommand Delete => new DeleteOtherEmployeeCommand(this, _otherEmployeeService);
        public EditOtherEmployeeCommand Edit => new EditOtherEmployeeCommand(this); 
        public RejectOtherEmployeeCommand Reject => new RejectOtherEmployeeCommand(this);
        public SaveOtherEmployeeCommand Save => new SaveOtherEmployeeCommand(this, _otherEmployeeService);

        public void SetDefaultValues()
        {
            CurrentSituation = Situations.NORMAL;
            CurrentValue = new OtherEmployeeModel();

            SetSelectedValue(null);
        }

        private void SetSelectedValue(OtherEmployeeModel otherEmployeeModel)
        {
            _selectedValue = otherEmployeeModel;
            OnPropertyChanged(nameof(SelectedValue));
        }

        protected override void OnSearchTextChanged()
        {
            throw new NotImplementedException();
        }
    }
}
