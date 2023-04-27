using HospitalManagement.Commands.Doctors;
using HospitalManagement.Commands.Operations;
using HospitalManagement.Enums;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Services.Implementations;
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
    public class OperationsViewModel : BaseControlViewModel
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public OperationsViewModel(IServiceUnitOfWork serviceUnitOfWork, ErrorDialog errorDialog) : base(errorDialog)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
            AllValues = new List<OperationModel>();
            SetDefaultValues();
        }
        public override string Header => "Operations";

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

        private OperationModel _currentValue;
        public OperationModel CurrentValue
        {
            get => _currentValue;
            set
            {
                _currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }

        private OperationModel _selectedValue;
        public OperationModel SelectedValue
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
                    CurrentValue = new OperationModel();
                    CurrentValue = SelectedValue.Clone();
                    CurrentSituation = Situations.SELECTED;
                }
            }
        }

        private ObservableCollection<OperationModel> _values;
        public ObservableCollection<OperationModel> Values
        {
            get => _values ?? (_values = new ObservableCollection<OperationModel>());
            set
            {
                _values = value;
                OnPropertyChanged(nameof(Values));
            }
        }

        public List<OperationModel> AllValues { get; set; }


        public AddOperationCommand Add => new AddOperationCommand(this);
        public DeleteOperationCommand Delete => new DeleteOperationCommand(this);
        public EditOperationCommand Edit => new EditOperationCommand(this);
        public RejectOperationCommand Reject => new RejectOperationCommand(this);
        public SaveOperationCommand Save => new SaveOperationCommand(this);
        
        public void SetDefaultValues()
        {
            CurrentSituation = Situations.NORMAL;
            CurrentValue = new OperationModel();

            SetSelectedValue(null);
        }

        private void SetSelectedValue(OperationModel operationModel)
        {
            _selectedValue = operationModel;
            OnPropertyChanged(nameof(SelectedValue));
        }
        protected override void OnSearchTextChanged()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Values = new ObservableCollection<OperationModel>(AllValues);
            }
            else
            {
                string lowerSearchText = SearchText.ToLower();

                var filteredResult = AllValues.Where(x => x.OperationCost.ToString().Contains(lowerSearchText) == true ||
                                                 x.OperationReason?.ToLower().Contains(lowerSearchText) == true ||                                                 
                                                 x.OperationDate.ToString(SystemConstants.DateDisplayFormat).Contains(lowerSearchText) == true ||
                                                 x.DisplayPatient.ToLower().Contains(lowerSearchText) == true ||
                                                 x.DisplayRoom.ToLower().Contains(lowerSearchText) == true ||
                                                 x.OperationDoctors.Where(y => y.DisplayValue.ToLower().Contains(lowerSearchText) == true).ToList().Any() ||
                                                 x.OperationNurses.Where(y => y.DisplayValue.ToLower().Contains(lowerSearchText) == true).ToList().Any()).ToList();

                Values = new ObservableCollection<OperationModel>(filteredResult);
            }
        }
    }
}
