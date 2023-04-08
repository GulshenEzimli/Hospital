﻿using HospitalManagement.Enums;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Procedures
{
    public class EditProcedureCommand : BaseCommand
    {
        private readonly ProceduresViewModel _procedureViewModel;
        public EditProcedureCommand(ProceduresViewModel procedureViewModel)
        {
            _procedureViewModel = procedureViewModel;
        }

        public override void Execute(object parameter)
        {
            _procedureViewModel.CurrentSituation = (int)Situations.EDIT;
        }
    }
}
