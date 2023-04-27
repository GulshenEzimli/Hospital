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
        public int Number { get; set; }
        public bool IsAvailable { get; set; }
        public byte Type { get; set; }
        public int BlockFloor { get; set; }
    }
}
