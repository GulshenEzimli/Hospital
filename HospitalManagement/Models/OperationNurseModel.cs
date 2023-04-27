using HospitalManagementCore.Domain.Entities;
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
        public OperationModel OperationModel { get; set; }
        public NurseModel Nurse { get; set; }
        public string DisplayValue => $"{Nurse.FirstName} {Nurse.LastName} {Nurse.PIN}";
    }
}
