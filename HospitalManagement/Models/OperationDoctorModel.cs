using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class OperationDoctorModel
    {
        public int Id { get; set; }
        public OperationModel Model { get; set; }
        public DoctorModel Doctor { get; set; }

        public string DisplayValue => $"{Doctor.FirstName} {Doctor.LastName} {Doctor.PIN}";
    }
}
