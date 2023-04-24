using HospitalManagement.Commands.Nurses;
using HospitalManagement.Enums;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Views.Components;
using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class NursesViewModel : BaseControlViewModel
    {
        private readonly INurseService _nurseService;
        public NursesViewModel(INurseService nurseService, ErrorDialog errorDialog) : base(errorDialog)
        {
            _nurseService = nurseService;
            AllValues = new List<NurseModel>();
            SetDefaultValues();
        }
        public override string Header => "Nurses";

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

        private List<PositionModel> _positions;
        public List<PositionModel> Positions => _positions ?? (_positions = new List<PositionModel>());

        private NurseModel _currentValue;
        public NurseModel CurrentValue 
        { 
            get => _currentValue;
            set
            {
                _currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }

        private NurseModel _selectedValue;
        public NurseModel SelectedValue
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
        public DeleteNurseCommand Delete => new DeleteNurseCommand(this,_nurseService);
        public EditNurseCommand Edit => new EditNurseCommand(this);
        public RejectNurseCommand Reject => new RejectNurseCommand(this);
        public SaveNurseCommand Save => new SaveNurseCommand(this, _nurseService);

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

        protected override void OnSearchTextChanged()
        {
            throw new NotImplementedException();
        }
    }
}
