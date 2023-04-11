using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class PatientModel
    {
        public int Id { get; set; }
        public int No { get;set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PIN { get; set; }
        public string PhoneNumber { get; set; }

    }
}
