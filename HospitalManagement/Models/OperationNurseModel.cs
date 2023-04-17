using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class OperationNurseModel
    {
        public int Id { get; set; }
        public string NurseName { get; set; }
        public string NurseSurname { get; set; }
        public string NursePIN { get; set; }
    }
}
