using HospitalManagement.Commands.Doctors;
using HospitalManagement.Commands.Nurses;
using HospitalManagement.Enums;
using HospitalManagement.Mappers.Interfaces;
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
    public class DoctorsViewModel : BaseControlViewModel
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public DoctorsViewModel(IServiceUnitOfWork serviceUnitOfWork, ErrorDialog errorDialog) : base(errorDialog)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
            AllValues = new List<DoctorModel>();
            SetDefaultValues();
        }
        public override string Header => "Doctors";


        private Situations _currentSituation;
        public Situations CurrentSituation
        {
            get => _currentSituation;
            set
            {
                _currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }

        private DoctorModel _currentValue;
        public DoctorModel CurrentValue
        {
            get => _currentValue;
            set
            {
                _currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }

        private DoctorModel _selectedValue;
        public DoctorModel SelectedValue
        {
            get => _selectedValue;
            set
            {
                SetSelectedValue(value);

                if (value == null)
                {
                    SetDefaultValues();
                }
                else
                {
                    CurrentValue = SelectedValue.Clone();
                    CurrentSituation = Situations.SELECTED;
                }
            }
        }

        private ObservableCollection<DoctorModel> _values;
        public ObservableCollection<DoctorModel> Values
        {
            get => _values ?? (_values = new ObservableCollection<DoctorModel>());
            set
            {
                _values = value;
                OnPropertyChanged(nameof(Values));
            }
        }

        public List<DoctorModel> AllValues { get; set; }

        private ObservableCollection<string> _positionValues;
        public ObservableCollection<string> PositionValues
        { 
            get => _positionValues ?? (_positionValues = new ObservableCollection<string>());
            set
            {
                _positionValues = value;
                OnPropertyChanged(nameof(PositionValues));
            }
        }
        public List<string> AllPositionValues { get; set; }


        public AddDoctorCommand Add => new AddDoctorCommand(this);
        public DeleteDoctorCommand Delete => new DeleteDoctorCommand(this, _serviceUnitOfWork);
        public EditDoctorCommand Edit => new EditDoctorCommand(this);
        public RejectDoctorCommand Reject => new RejectDoctorCommand(this);
        public SaveDoctorCommand Save => new SaveDoctorCommand(this, _serviceUnitOfWork);

        public void SetDefaultValues()
        {
            CurrentSituation = Situations.NORMAL;
            CurrentValue = new DoctorModel();

            SetSelectedValue(null);
        }

        private void SetSelectedValue(DoctorModel doctorModel)
        {
            _selectedValue = doctorModel;
            OnPropertyChanged(nameof(SelectedValue));
        } 

        protected override void OnSearchTextChanged()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Values = new ObservableCollection<DoctorModel>(AllValues);
            }
            else
            {
                string lowerSearchText = SearchText.ToLower();

                var filteredResult = AllValues.Where(x => x.FirstName?.ToLower().Contains(lowerSearchText) == true ||
                                                 x.LastName?.ToLower().Contains(lowerSearchText) == true ||
                                                 x.PIN?.ToLower().Contains(lowerSearchText) == true ||
                                                 x.GenderValue?.ToLower().Contains(lowerSearchText) == true ||
                                                 x.IsChiefDoctorValue?.ToLower().Contains(lowerSearchText) == true ||
                                                 x.Salary.ToString().Contains(lowerSearchText) == true ||
                                                 x.BirthDate.ToString(SystemConstants.DateDisplayFormat).Contains(lowerSearchText) == true ||
                                                 x.PositionName?.ToLower().Contains(lowerSearchText) == true ||
                                                 x.Phonenumber?.ToLower().Contains(lowerSearchText) == true ||
                                                 x.DepartmentName?.ToLower().Contains(lowerSearchText) == true ||
                                                 x.Email?.ToLower().Contains(lowerSearchText) == true).ToList();

                Values = new ObservableCollection<DoctorModel>(filteredResult);
            }
        }
    }
}
