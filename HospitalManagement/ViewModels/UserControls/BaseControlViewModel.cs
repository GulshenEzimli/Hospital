using HospitalManagement.Commands.ControlModel;
using HospitalManagement.Enums;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Models.Interfaces;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Validations.Interfaces;
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
    public abstract class BaseControlViewModel<T> : BaseViewModel where T : IControlModel, new()
    {
        private readonly IControlModelService<T> _service;
        private readonly IControlModelValidation<T> _validation;
        protected BaseControlViewModel(IControlModelService<T> service, IControlModelValidation<T> validation, ErrorDialog errorDialog)
        {
            _service = service;
            _validation = validation;
            ErrorDialog = errorDialog;

            AllValues = new List<T>();
            SetDefaultValues();
        }
        public abstract string Header { get; }

        public virtual void Load()
        {

        }

        public virtual void OnSelectedValueChanged()
        {

        }

        #region commands
        public AddControlModelCommand<T> Add => new AddControlModelCommand<T>(this);
        public DeleteControlModelCommand<T> Delete => new DeleteControlModelCommand<T>(this, _service);
        public EditControlModelCommand<T> Edit => new EditControlModelCommand<T>(this);
        public RejectControlModelCommand<T> Reject => new RejectControlModelCommand<T>(this);
        public SaveControlModelCommand<T> Save => new SaveControlModelCommand<T>(this, _service,_validation);
        public ExportExcelControlModelCommand<T> ExportExcel => new ExportExcelControlModelCommand<T>(this);
        #endregion

        #region properties
        public ErrorDialog ErrorDialog { get; }

        private MessageModel _message = new MessageModel();

        public MessageModel Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));

                if (string.IsNullOrWhiteSpace(SearchText))
                {
                    Values = new ObservableCollection<T>(AllValues);
                }
                else
                {
                    var filteredResult = AllValues.Where(x => x.IsCompatibleWithFilter(SearchText));

                    Values = new ObservableCollection<T>(filteredResult);
                }
            }
        }

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

        private T _currentValue;
        public T CurrentValue
        {
            get => _currentValue;
            set
            {
                _currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }

        private T _selectedValue;
        public T SelectedValue
        {
            get => _selectedValue;
            set
            {
                SetSelectedValue(value);
                OnSelectedValueChanged();
                if (value == null)
                {
                    SetDefaultValues();
                }
                else
                {
                    CurrentValue = new T();
                    CurrentValue = (T)SelectedValue.Clone();
                    CurrentSituation = Situations.SELECTED;
                }
                OnPropertyChanged(nameof(_selectedValue));
            }
        }

        private ObservableCollection<T> _values;
        public ObservableCollection<T> Values
        {
            get => _values ?? (_values = new ObservableCollection<T>());
            set
            {
                _values = value;
                OnPropertyChanged(nameof(Values));
            }
        }

        public List<T> AllValues { get; set; }
        #endregion

        #region methods
        public void SetDefaultValues()
        {
            CurrentSituation = Situations.NORMAL;
            CurrentValue = new T();

            SetSelectedValue(default(T));
        }

        public void SetSelectedValue(T model)
        {
            _selectedValue = model;
            OnPropertyChanged(nameof(SelectedValue));
        }
        #endregion
    }
}
