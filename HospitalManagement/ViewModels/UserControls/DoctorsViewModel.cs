using HospitalManagement.Commands.Doctors;
using HospitalManagement.Enums;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
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
    public class DoctorsViewModel : BaseControlViewModel<DoctorModel>
    {
        private readonly IControlModelService<PositionModel> _positionService;
        public DoctorsViewModel(IControlModelService<PositionModel> positionService, IControlModelService<DoctorModel> doctorService, ErrorDialog errorDialog) : base(doctorService, errorDialog)
        {   
            _positionService = positionService;
        }
        public override string Header => "Doctors";
        
        private List<PositionModel> _positionValues;
        public List<PositionModel> PositionValues
        {
            get => _positionValues ?? (_positionValues = new List<PositionModel>());
            set
            {
                _positionValues = value;
            }
        }

        public override void Load()
        {
            List<PositionModel> positions = _positionService.GetAll();
            PositionValues = new List<PositionModel>(positions);
        }
    }
}
