using HospitalManagement.Attributes;
using HospitalManagement.Models.Interfaces;
using HospitalManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models.Implementations
{
    public class ProcedureModel : IControlModel
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
        public IControlModel Clone()
        {
            return new ProcedureModel()
            {
                No = No,
                Id = Id,
                Name = Name,
                Cost = Cost
            };
        }
        public bool IsCompatibleWithFilter(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return true;

            string lowerSearchText = searchText.ToLower();

            if (Name?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (Cost.ToString().Contains(lowerSearchText))
                return true;
                       
            return false;
        }
    }
}
