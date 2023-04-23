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
                    CurrentOtherEmployeeValue = SelectedValue.Clone();
                    CurrentSituation = Situations.SELECTED;
                }
                OnPropertyChanged(nameof(SelectedValue));
            }
        }

        private ObservableCollection<OtherEmployeeModel> _otherEmployeeValues;
        public ObservableCollection<OtherEmployeeModel> OtherEmployeeValues
        {
            get => _otherEmployeeValues ?? (_otherEmployeeValues = new ObservableCollection<OtherEmployeeModel>());
            set
            {
                _otherEmployeeValues = value;
                OnPropertyChanged(nameof(_otherEmployeeValues));
            }
        }

        private List<string> _jobNames;
        public List<string> JobNames => _jobNames ?? (_jobNames = new List<string>());

        public List<OtherEmployeeModel> AllValues { get; set; }

        public AddOtherEmployeeCommand Add => new AddOtherEmployeeCommand(this);
        public DeleteOtherEmployeeCommand Delete => new DeleteOtherEmployeeCommand(this, _otherEmployeeService);
        public EditOtherEmployeeCommand Edit => new EditOtherEmployeeCommand(this); 
        public RejectOtherEmployeeCommand Reject => new RejectOtherEmployeeCommand(this);
        public SaveOtherEmployeeCommand Save => new SaveOtherEmployeeCommand(this, _otherEmployeeService);

        public void SetDefaultValues()
        {
            CurrentSituation = Situations.NORMAL;
            CurrentOtherEmployeeValue = new OtherEmployeeModel();

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
