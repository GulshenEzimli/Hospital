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
        public byte Type { get; set; }
        public int BlockFloor { get; set; }
    }
}
