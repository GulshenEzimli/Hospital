﻿using HospitalManagement.Enums;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.OtherEmployees
{
    public class RejectOtherEmployeeCommand : BaseCommand
    {
        private readonly OtherEmployeesViewModel _viewModel;
        public RejectOtherEmployeeCommand(OtherEmployeesViewModel viewModel)
        {
            this._viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.CurrentSituation = (int)Situations.NORMAL;
        }
    }
}