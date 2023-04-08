using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Procedures
{
    public class DeleteProcedureCommand : BaseCommand
    {
        private readonly ProceduresViewModel _procedureViewModel;
        public DeleteProcedureCommand(ProceduresViewModel procedureViewModel)
        {
            _procedureViewModel = procedureViewModel;
        }
        public override void Execute(object parameter)
        {

        }
    }
}
