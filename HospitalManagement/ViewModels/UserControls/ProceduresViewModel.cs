using HospitalManagement.Enums;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Services.Implementations;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Utils;
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
    public class ProceduresViewModel : BaseControlViewModel<ProcedureModel>
    {
        public ProceduresViewModel(IControlModelService<ProcedureModel> procedureService, ErrorDialog errorDialog) : base(procedureService, errorDialog)
        {
            
        }
        public override string Header => "Procedures";
    }
}
