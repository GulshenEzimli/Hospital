using HospitalManagementCore.Domain.Entities;
using HospitalManagementCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public int No { get; set; }
        public int Number { get; set; }
        private bool[] _isAvailable = {false, false};
        public bool[] IsAvailable 
        {
            get => _isAvailable;
            set => _isAvailable = value;
        }

        public string IsAvailableValue
        {
            get => IsAvailable[0] ? "Boş" : "Dolu";
        }

        public RoomTypes Type { get; set; }
        public int BlockFloor { get; set; }

        public string DisplayRoom => $"{BlockFloor}. mərtəbə {Number} nömrəli {Type} otaq";

        public RoomModel Clone()
        {
            return new RoomModel
            {
                Id = Id,
                No = No,
                Number = Number,
                Type = Type,
                BlockFloor = BlockFloor
            };
        }
    }
}
