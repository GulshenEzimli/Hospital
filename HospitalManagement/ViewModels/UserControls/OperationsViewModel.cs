using HospitalManagement.Commands.Doctors;
using HospitalManagement.Commands.Operations;
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
    public class OperationsViewModel : BaseControlViewModel
    {
        public OperationsViewModel(IUnitOfWork unitOfWork, ErrorDialog errorDialog) : base(unitOfWork, errorDialog)
        {
            SetDefaultValues();
        }
        public override string Header => "Operations";

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

        private ObservableCollection<OperationModel> _values;
        public ObservableCollection<OperationModel> Values => _values ?? (_values = new ObservableCollection<OperationModel>());

        public AddOperationCommand Add => new AddOperationCommand(this);
        public DeleteOperationCommand Delete => new DeleteOperationCommand(this);
        public EditOperationCommand Edit => new EditOperationCommand(this);
        public RejectOperationCommand Reject => new RejectOperationCommand(this);
        public SaveOperationCommand Save => new SaveOperationCommand(this);
        public void SetDefaultValues()
        {
            CurrentSituation = Situations.NORMAL;
        }
    }
}
