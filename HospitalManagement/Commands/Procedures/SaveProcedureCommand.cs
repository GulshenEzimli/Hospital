using HospitalManagement.Enums;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Procedures
{
    public class SaveProcedureCommand : BaseCommand
    {
        private readonly ProceduresViewModel _procedureViewModel;
        public SaveProcedureCommand(ProceduresViewModel procedureViewModel)
        {
            _procedureViewModel = procedureViewModel;
        }

        public override void Execute(object parameter)
        {
            //TO DO:IMPLEMENT SAVE
            _procedureViewModel.CurrentSituation = Situations.NORMAL;
        }
    }
}
