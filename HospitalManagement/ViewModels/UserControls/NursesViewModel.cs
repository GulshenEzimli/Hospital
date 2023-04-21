using HospitalManagement.Commands.Nurses;
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
    public class NursesViewModel : BaseControlViewModel
    {
        private readonly INurseMapper _nurseMapper;
        public NursesViewModel(IUnitOfWork unitOfWork, INurseMapper nurseMapper,ErrorDialog errorDialog) : base(unitOfWork,errorDialog)
        {
            _nurseMapper = nurseMapper;
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

        private List<string> _positionNames;
        public List<string> PositionNames => _positionNames ?? (_positionNames = new List<string>());

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

        public AddNurseCommand Add => new AddNurseCommand(this);
        public DeleteNurseCommand Delete => new DeleteNurseCommand(this);
        public EditNurseCommand Edit => new EditNurseCommand(this);
        public RejectNurseCommand Reject => new RejectNurseCommand(this);
        public SaveNurseCommand Save => new SaveNurseCommand(this, _nurseMapper);

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
