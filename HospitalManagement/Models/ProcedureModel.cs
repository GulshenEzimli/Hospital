using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class ProcedureModel
    {
        public int No { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string DisplayProcedure
        {
            get => $"{Name}  {Cost}";
            set
            {
                DisplayProcedure = value;
            }
        }
        public ProcedureModel Clone()
        {
            return new ProcedureModel()
            {
                No = No,
                Id = Id,
                Name = Name,
                Cost = Cost
            };
        }
    }
}
