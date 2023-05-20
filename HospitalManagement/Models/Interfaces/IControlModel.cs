using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models.Interfaces
{
    public interface IControlModel
    {
        int Id { get; set; }

        IControlModel Clone();

        bool ICompatibleWithFilter(string searchText);
    }
}
