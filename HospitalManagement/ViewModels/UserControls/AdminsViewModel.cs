using HospitalManagement.Commands.Admins;
using HospitalManagement.Commands.Nurses;
using HospitalManagement.Enums;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class AdminsViewModel:BaseViewModel
    {
        public AdminsViewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
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

        public AddAdminCommand Add => new AddAdminCommand(this);
        public DeleteAdminCommand Delete => new DeleteAdminCommand(this);
        public EditAdminCommand Edit => new EditAdminCommand(this);
        public RejectAdminCommand Reject => new RejectAdminCommand(this);
        public SaveAdminCommand Save => new SaveAdminCommand(this);

    }
}
