using HospitalManagement.Commands.Nurses;
using HospitalManagement.Commands.Rooms;
using HospitalManagement.Enums;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class RoomsViewModel:BaseViewModel
    {
        public RoomsViewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
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

        public AddRoomCommand Add => new AddRoomCommand(this);
        public DeleteRoomCommand Delete => new DeleteRoomCommand(this);
        public EditRoomCommand Edit => new EditRoomCommand(this);
        public RejectRoomCommand Reject => new RejectRoomCommand(this);
        public SaveRoomCommand Save => new SaveRoomCommand(this);

    }
}
