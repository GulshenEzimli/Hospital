using HospitalManagement.Commands.Doctors;
using HospitalManagement.Commands.Nurses;
using HospitalManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class DoctorsViewModel : BaseViewModel
    {
        public DoctorsViewModel()
        {
            CurrentSituation = 1;
        }
        private int _currentSituation = (int)Situations.NORMAL;
        public int CurrentSituation
        {
            get => _currentSituation;
            set
            {
                _currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }

        public AddDoctorCommand Add => new AddDoctorCommand(this);
        public DeleteDoctorCommand Delete => new DeleteDoctorCommand(this);
        public EditDoctorCommand Edit => new EditDoctorCommand(this);
        public RejectDoctorCommand Reject => new RejectDoctorCommand(this);
        public SaveDoctorCommand Save => new SaveDoctorCommand(this);
    }
}
