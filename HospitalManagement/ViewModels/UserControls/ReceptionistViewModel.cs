using HospitalManagement.Commands.Nurses;
using HospitalManagement.Commands.Receptionists;
using HospitalManagement.Enums;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Validations.Utils;
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
    public class ReceptionistViewModel: BaseControlViewModel
    {
        private readonly IReceptionistService _receptionistService;
        public ReceptionistViewModel(IReceptionistService receptionistService, ErrorDialog errorDialog) : base(errorDialog)
        {
            _receptionistService = receptionistService;
            AllValues = new List<ReceptionistModel>();
            SetDefaultValues();
        }

        public override string Header => "Receptionists";

        private Situations _currentSituation = Situations.NORMAL;
        public Situations CurrentSituation
        {
            get => _currentSituation;
            set
            {
                _currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }

        private List<JobModel> _jobs;

        public List<JobModel> Jobs
        {
            get => _jobs ?? (_jobs = new List<JobModel>());
            set { _jobs = value; }
        }


        private ReceptionistModel _currentValue;

        public ReceptionistModel CurrentValue
        {
            get { return _currentValue; }
            set
            {
                _currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }

        private ReceptionistModel _selectedValue;

        public ReceptionistModel SelectedValue
        {
            get { return _selectedValue; }
            set 
            {
                SetSelectedValue(value);

                if(value == null)
                {
                    SetDefaultValues();
                }
                else
                {
                    CurrentValue = new ReceptionistModel();
                    CurrentValue = SelectedValue.Clone();
                    CurrentSituation = Situations.SELECTED;
                }
                OnPropertyChanged(nameof(SelectedValue));
            }
        }

        private ObservableCollection<ReceptionistModel> _values;
        public ObservableCollection<ReceptionistModel> Values
        {
            get => _values ?? (_values = new ObservableCollection<ReceptionistModel>());
            set
            {
                _values = value;
                OnPropertyChanged(nameof(Values));
            }
        }

        public List<ReceptionistModel> AllValues { get; set; }

        public AddReceptionistCommand Add => new AddReceptionistCommand(this);
        public AddReceptionistCommand Delete => new AddReceptionistCommand(this);
        public AddReceptionistCommand Edit => new AddReceptionistCommand(this);
        public AddReceptionistCommand Reject => new AddReceptionistCommand(this);
        public AddReceptionistCommand Save => new AddReceptionistCommand(this);

        public void SetDefaultValues()
        {
            CurrentSituation = Situations.NORMAL;
            CurrentValue = new ReceptionistModel();

            SetSelectedValue(null);
        }

        public void SetSelectedValue(ReceptionistModel receptionistModel)
        {
            _selectedValue = receptionistModel;
            OnPropertyChanged(nameof(SelectedValue));
        }

        protected override void OnSearchTextChanged()
        {
            if(string.IsNullOrWhiteSpace(SearchText))
                Values = new ObservableCollection<ReceptionistModel>(AllValues);
            else
            {
                var lowerText = SearchText.ToLower();   
                var filteredValues = AllValues.Where(x => x.FirstName?.ToLower().Contains(lowerText) == true ||
                                                     x.LastName?.ToLower().Contains(lowerText) == true ||
                                                     x.BirthDate.ToString(SystemConstants.DateDisplayFormat).Contains(lowerText) == true||
                                                     x.PhoneNumber?.Contains(lowerText) == true ||
                                                     x.Email?.ToLower().Contains(lowerText) == true || 
                                                     x.PIN?.ToLower().Contains(lowerText) == true ||
                                                     x.JobName?.ToLower().Contains(lowerText) == true ||
                                                     x.DepartmentName?.ToLower().Contains(lowerText) == true ||
                                                     x.Salary.ToString().Contains(lowerText) == true ||
                                                     x.GenderValue?.ToLower().Contains(lowerText) == true).ToList();
                Values = new ObservableCollection<ReceptionistModel>(filteredValues);
            }
        }
    }
}
