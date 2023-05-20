using HospitalManagement.Models.Interfaces;
using HospitalManagement.Validations.Utils;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models.Implementations
{
    public class PositionModel : IControlModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }

        public IControlModel Clone()
        {
            return new PositionModel
            {
                Id = Id,
                Name = Name,
                DepartmentName = DepartmentName
            };
        }
        public bool IsCompatibleWithFilter(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return true;

            string lowerSearchText = searchText.ToLower();

            if (Name?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (DepartmentName?.ToLower().Contains(lowerSearchText) == true)
                return true;

            return false;
        }
    }
}
