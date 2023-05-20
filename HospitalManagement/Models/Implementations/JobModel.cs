﻿using HospitalManagement.Models.Interfaces;
using HospitalManagement.Validations.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models.Implementations
{
    public class JobModel : IControlModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IControlModel Clone()
        {
            return new JobModel 
            { 
                Id = Id, 
                Name = Name 
            };
        }
        public bool IsCompatibleWithFilter(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return true;

            string lowerSearchText = searchText.ToLower();

            if (Name?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (Surname?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (BirthDate.ToString(SystemConstants.DateDisplayFormat).Contains(lowerSearchText))
                return true;

            if (Note?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (Motherland?.ToLower().Contains(lowerSearchText) == true)
                return true;

            return false;
        }
    }
}
