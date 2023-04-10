using HospitalManagement.Commands.Doctors;
using HospitalManagement.Commands.Queues;
using HospitalManagement.Enums;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class QueuesViewModel:BaseViewModel
    {
        public QueuesViewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
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
        public AddQueueCommand Add => new AddQueueCommand(this);
        public DeleteQueueCommand Delete => new DeleteQueueCommand(this);
        public EditQueueCommand Edit => new EditQueueCommand(this);
        public RejectQueueCommand Reject => new RejectQueueCommand(this);
        public SaveQueueCommand Save => new SaveQueueCommand(this);
    }
}
