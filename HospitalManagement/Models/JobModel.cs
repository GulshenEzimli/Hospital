using HospitalManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class JobModel : IControlModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
