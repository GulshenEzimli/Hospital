using HospitalManagement.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class ProcedureModel
    {
        [ExcelIgnore]
        public int Id { get; set; }

        public int No { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        [ExcelIgnore]
        public string DisplayProcedure => $"{Name}  {Cost}";

        [ExcelIgnore]
        public bool IsDelete { get; set; }
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
