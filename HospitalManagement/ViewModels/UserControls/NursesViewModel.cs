using HospitalManagement.Enums;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Utils;
using HospitalManagement.Views.Components;
using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class NursesViewModel : BaseControlViewModel<NurseModel>
    {
        private readonly IControlModelService<PositionModel> _positionService;
        public NursesViewModel(IControlModelService<PositionModel> positionService, IControlModelService<NurseModel> nurseService, ErrorDialog errorDialog) : base(nurseService, errorDialog)
        {
            _positionService = positionService;            
        }
        public override string Header => "Nurses";

        private List<PositionModel> _positions;
        public List<PositionModel> Positions
        {
            get => _positions ?? (_positions = new List<PositionModel>());
            set
            {
                _positions = value; 
            }
        }

        public override void Load()
        {
            List<PositionModel> positions = _positionService.GetAll();
            Positions = new List<PositionModel>(positions);
        }
    }
}
