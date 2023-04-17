using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Validations;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Operations
{
    public class SaveOperationCommand : BaseCommand
    {
        private readonly OperationsViewModel _operationsViewModel;
        public SaveOperationCommand(OperationsViewModel operationsViewModel)
        {
            _operationsViewModel = operationsViewModel;
        }

        public override void Execute(object parameter)
        {
            _operationsViewModel.SetDefaultValues();
        }
    }
}
