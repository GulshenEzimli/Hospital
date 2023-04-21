using HospitalManagement.Commands.OtherEmployees;
using HospitalManagement.Enums;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
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
        private readonly IOtherEmployeeMapper _otherEmployeeMapper;
        public OtherEmployeesViewModel(IUnitOfWork unitOfWork, IOtherEmployeeMapper otherEmployeeMapper, ErrorDialog errorDialog) : base(unitOfWork, errorDialog)
        {
            _otherEmployeeMapper = otherEmployeeMapper;
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
        public ObservableCollection<OtherEmployeeModel> OtherEmployeeValues => _otherEmployeeValues ?? (_otherEmployeeValues = new ObservableCollection<OtherEmployeeModel>());

        private List<string> _jobNames;
        public List<string> JobNames => _jobNames ?? (_jobNames = new List<string>());

        public AddOtherEmployeeCommand Add => new AddOtherEmployeeCommand(this);
        public DeleteOtherEmployeeCommand Delete => new DeleteOtherEmployeeCommand(this);
        public EditOtherEmployeeCommand Edit => new EditOtherEmployeeCommand(this); 
        public RejectOtherEmployeeCommand Reject => new RejectOtherEmployeeCommand(this);
        public SaveOtherEmployeeCommand Save => new SaveOtherEmployeeCommand(this, _otherEmployeeMapper);

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
    }
}
