using HospitalManagementCore.Domain.Enums;
using HospitalManagementCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementCore.Domain.Entities
{
    public class Room : IEntity
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool IsAvailable { get; set; }
        public RoomTypes Type { get; set; }
        public int BlockFloor { get; set; }
        public bool IsDelete { get; set; }
    }
}
