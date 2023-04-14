using HospitalManagement.Commands.Nurses;
using HospitalManagement.Commands.Receptionists;
using HospitalManagement.Enums;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class ReceptionistViewModel:BaseViewModel
    {
        public ReceptionistViewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

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

        public AddReceptionistCommand Add => new AddReceptionistCommand(this);
        public AddReceptionistCommand Delete => new AddReceptionistCommand(this);
        public AddReceptionistCommand Edit => new AddReceptionistCommand(this);
        public AddReceptionistCommand Reject => new AddReceptionistCommand(this);
        public AddReceptionistCommand Save => new AddReceptionistCommand(this);

    }
}
