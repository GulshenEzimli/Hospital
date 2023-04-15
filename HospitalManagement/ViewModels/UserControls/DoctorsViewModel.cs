using HospitalManagement.Commands.Doctors;
using HospitalManagement.Commands.Nurses;
using HospitalManagement.Enums;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class DoctorsViewModel : BaseControlViewModel
    {
        private readonly IDoctorMapper _doctorMapper;
        public DoctorsViewModel(IUnitOfWork unitOfWork, IDoctorMapper doctorMapper) :base(unitOfWork)
        {
            _doctorMapper = doctorMapper;
        }
        public override string Header => "Doctors";


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

        private List<DoctorModel> _values;
        public List<DoctorModel> Values => _values ?? (_values = new List<DoctorModel>());


        private List<string> _positionValues;
        public List<string> PositionValues => _positionValues ?? (_positionValues = new List<string>());

        public AddDoctorCommand Add => new AddDoctorCommand(this);
        public DeleteDoctorCommand Delete => new DeleteDoctorCommand(this);
        public EditDoctorCommand Edit => new EditDoctorCommand(this);
        public RejectDoctorCommand Reject => new RejectDoctorCommand(this);
        public SaveDoctorCommand Save => new SaveDoctorCommand(this, _doctorMapper);

    }
}
