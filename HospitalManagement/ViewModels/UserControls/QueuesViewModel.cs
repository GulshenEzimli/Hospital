using HospitalManagement.Commands.Doctors;
using HospitalManagement.Commands.Queues;
using HospitalManagement.Enums;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Views.Components;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class QueuesViewModel:BaseControlViewModel
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public QueuesViewModel(IServiceUnitOfWork serviceUnitOfWork,ErrorDialog errorDialog) : base(errorDialog)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
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
        public AddQueueCommand Add => new AddQueueCommand(this);
        public DeleteQueueCommand Delete => new DeleteQueueCommand(this);
        public EditQueueCommand Edit => new EditQueueCommand(this);
        public RejectQueueCommand Reject => new RejectQueueCommand(this);
        public SaveQueueCommand Save => new SaveQueueCommand(this);

        public override string Header => "Queues";

        protected override void OnSearchTextChanged()
        {
            throw new NotImplementedException();
        }
    }
}
