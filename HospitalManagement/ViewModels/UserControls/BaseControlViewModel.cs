using HospitalManagement.Commands.Nurses;
using HospitalManagement.Enums;
using HospitalManagement.Models;
using HospitalManagement.Models.Interfaces;
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
        protected BaseControlViewModel(ErrorDialog errorDialog)
        {
            ErrorDialog = errorDialog;
        }
        public abstract string Header { get; }

        public ErrorDialog ErrorDialog { get; }

        private MessageModel _message = new MessageModel();

        public MessageModel Message {
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
                OnSearchTextChanged();
            }
        }

        protected abstract void OnSearchTextChanged();

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

        private ObservableCollection<NurseModel> _values;
        public ObservableCollection<NurseModel> Values
        {
            get => _values ?? (_values = new ObservableCollection<NurseModel>());
            set
            {
                _values = value;
                OnPropertyChanged(nameof(Values));
            }
        }

        public List<NurseModel> AllValues { get; set; }
        public AddNurseCommand Add => new AddNurseCommand(this);
        public DeleteNurseCommand Delete => new DeleteNurseCommand(this, _nurseService);
        public EditNurseCommand Edit => new EditNurseCommand(this);
        public RejectNurseCommand Reject => new RejectNurseCommand(this);
        public SaveNurseCommand Save => new SaveNurseCommand(this, _nurseService);
        public ExportExcelNurseCommand ExportExcel => new ExportExcelNurseCommand(this);

        public void SetDefaultValues()
        {
            CurrentSituation = Situations.NORMAL;
            CurrentValue = new NurseModel();

            SetSelectedValue(null);
        }

        public void SetSelectedValue(NurseModel nurseModel)
        {
            _selectedValue = nurseModel;
            OnPropertyChanged(nameof(SelectedValue));
        }
    }
}
