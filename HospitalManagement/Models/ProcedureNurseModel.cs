using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class ProcedureNurseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set;}
        public string PhoneNumber { get; set; }
        public string PositionName { get; set; }
        public string PIN { get; set; }

    }
}
