using HospitalManagement.Commands.Nurses;
using HospitalManagement.Commands.Receptionists;
using HospitalManagement.Enums;
using HospitalManagement.Views.Components;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class ReceptionistViewModel: BaseControlViewModel
    {
        public ReceptionistViewModel(IUnitOfWork unitOfWork, ErrorDialog errorDialog) : base(errorDialog)
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

        public override string Header => throw new NotImplementedException();

        protected override void OnSearchTextChanged()
        {
            throw new NotImplementedException();
        }
    }
}
