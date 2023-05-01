using HospitalManagement.Commands.Nurses;
using HospitalManagement.Commands.Rooms;
using HospitalManagement.Enums;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
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
    public class RoomsViewModel : BaseControlViewModel
    {
        private readonly IRoomService _roomService;

        public RoomsViewModel(IRoomService roomService, ErrorDialog errorDialog) : base(errorDialog)
        {
            _roomService = roomService;
            AllValues = new List<RoomModel>();
            SetDefaultValues();
        }

        public override string Header => "Rooms";

        private Situations _currentSituation = Situations.NORMAL;
        public Situations CurrentSituation
        {
            get => _currentSituation;
            set
            {
                _currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }

        private RoomModel _currentValue;

        public RoomModel CurrentValue
        {
            get { return _currentValue; }
            set
            {
                _currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }

        private RoomModel _selectedValue;

        public RoomModel SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                SetSelectedValue(value);

                if (value == null)
                    SetDefaultValues();
                else
                {
                    CurrentValue = new RoomModel();
                    CurrentValue = SelectedValue.Clone();
                    CurrentSituation = Situations.SELECTED;
                }

                OnPropertyChanged(nameof(SelectedValue));
            }
        }

        private ObservableCollection<RoomModel> _values;
        public ObservableCollection<RoomModel> Values
        {
            get => _values ?? (_values = new ObservableCollection<RoomModel>());
            set
            {
                _values = value;
                OnPropertyChanged(nameof(Values));
            }
        }

        public List<RoomModel> AllValues { get; set; }
        public AddRoomCommand Add => new AddRoomCommand(this);
        public DeleteRoomCommand Delete => new DeleteRoomCommand(this, _roomService);
        public EditRoomCommand Edit => new EditRoomCommand(this);
        public RejectRoomCommand Reject => new RejectRoomCommand(this);
        public SaveRoomCommand Save => new SaveRoomCommand(this, _roomService);

        public void SetDefaultValues()
        {
            CurrentSituation = Situations.NORMAL;
            CurrentValue = new RoomModel();

            SetSelectedValue(null);
        }

        public void SetSelectedValue(RoomModel roomModel)
        {
            _selectedValue = roomModel;
            OnPropertyChanged(nameof(SelectedValue));
        }

        protected override void OnSearchTextChanged()
        {
            if(string.IsNullOrWhiteSpace(SearchText))
                Values = new ObservableCollection<RoomModel>(AllValues);
            else
            {
                var lowerText = SearchText.ToLower();
                var filteredValues = AllValues.Where(x => x.Number.ToString().Contains(lowerText) |
                                                     x.IsAvailable.ToString().Contains(lowerText) |
                                                     x.Type.ToString().Contains(lowerText) |
                                                     x.BlockFloor.ToString().Contains(lowerText));
                Values = new ObservableCollection<RoomModel>(filteredValues);
            }
        }
    }
}
