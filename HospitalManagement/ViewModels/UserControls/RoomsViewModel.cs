using HospitalManagement.Enums;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Views.Components;
using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class RoomsViewModel : BaseControlViewModel<RoomModel>
    {       
        public RoomsViewModel(IControlModelService<RoomModel> roomService,
                              ErrorDialog errorDialog) : base(roomService, errorDialog)
        {
            
        }

        public override string Header => "Rooms";

        private List<RoomTypes> _roomTypes;
        public List<RoomTypes> RoomTypes
        {
            get { return _roomTypes; }
            set { _roomTypes = value; }
        }

        public override void Load()
        {
            RoomTypes = Enum.GetValues(typeof(RoomTypes)).Cast<RoomTypes>().ToList();
        }
    }
}
