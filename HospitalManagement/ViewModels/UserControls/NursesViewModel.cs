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

        private int _currentSituation;
        public int CurrentSituation
        {
            get => _currentSituation;
            set
            {
                _currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }

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

        private ObservableCollection<NurseModel> _values;
        public ObservableCollection<NurseModel> Values => _values ?? (_values = new ObservableCollection<NurseModel> { });

        public AddNurseCommand Add => new AddNurseCommand(this);
        public DeleteNurseCommand Delete => new DeleteNurseCommand(this);
        public EditNurseCommand Edit => new EditNurseCommand(this);
        public RejectNurseCommand Reject => new RejectNurseCommand(this);
        public SaveNurseCommand Save => new SaveNurseCommand(this, _nurseMapper);

        public void SetDefaultValues()
        {
            CurrentSituation = (int)Situations.NORMAL;
            CurrentValue = new NurseModel();
        }
    }
}
