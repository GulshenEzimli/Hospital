using HospitalManagement.Commands.Doctors;
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
    public class DoctorsViewModel : BaseControlViewModel
    {
        private readonly IDoctorMapper _doctorMapper;
        public DoctorsViewModel(IUnitOfWork unitOfWork, IDoctorMapper doctorMapper, ErrorDialog errorDialog) :base(unitOfWork, errorDialog)
        {
            _doctorMapper = doctorMapper;
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

        private ObservableCollection<DoctorModel> _values;
        public ObservableCollection<DoctorModel> Values => _values ?? (_values = new ObservableCollection<DoctorModel>());


        private List<string> _positionValues;
        public List<string> PositionValues => _positionValues ?? (_positionValues = new List<string>());

        public AddDoctorCommand Add => new AddDoctorCommand(this);
        public DeleteDoctorCommand Delete => new DeleteDoctorCommand(this);
        public EditDoctorCommand Edit => new EditDoctorCommand(this);
        public RejectDoctorCommand Reject => new RejectDoctorCommand(this);
        public SaveDoctorCommand Save => new SaveDoctorCommand(this, _doctorMapper);

        public void SetDefaultValues()
        {
            CurrentSituation = Situations.NORMAL;
            CurrentValue = new DoctorModel();
        }

    }
}
