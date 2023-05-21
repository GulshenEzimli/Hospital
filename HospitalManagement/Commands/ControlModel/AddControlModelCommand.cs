using HospitalManagement.Enums;
using HospitalManagement.Models.Interfaces;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.ControlModel
{
    public class AddControlModelCommand<T> : BaseCommand where T : IControlModel, new()
    {
        private readonly BaseControlViewModel<T> _viewModel;
        public AddControlModelCommand(BaseControlViewModel<T> viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.CurrentSituation = Situations.ADD;
        }
    }
}
