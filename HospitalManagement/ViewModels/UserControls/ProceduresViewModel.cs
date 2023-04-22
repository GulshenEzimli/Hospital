using HospitalManagement.Commands.Patients;
using HospitalManagement.Commands.Procedures;
using HospitalManagement.Enums;
using HospitalManagement.Models;
using HospitalManagement.Views.Components;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class ProceduresViewModel:BaseControlViewModel
    {
        public ProceduresViewModel(IUnitOfWork unitOfWork,ErrorDialog errorDialog) : base(errorDialog)
        {
        }
        private Situations _currentSituation = Situations.NORMAL;
        public Situations CurrentSituation
        {
            get { return _currentSituation; }

            set
            {
                _currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }
        private List<ProcedureModel> _values;
        public List<ProcedureModel> Values=>_values ?? (_values=new List<ProcedureModel>());

        public AddProcedureCommand Add => new AddProcedureCommand(this);
        public DeleteProcedureCommand Delete=> new DeleteProcedureCommand(this);
        public EditProcedureCommand Edit => new EditProcedureCommand(this);
        public RejectProcedureCommand Reject => new RejectProcedureCommand(this);
        public SaveProcedureCommand Save=> new SaveProcedureCommand(this);

        public override string Header => throw new NotImplementedException();

        protected override void OnSearchTextChanged()
        {
            throw new NotImplementedException();
        }
    }
}
