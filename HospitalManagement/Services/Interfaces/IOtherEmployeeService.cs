using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Interfaces
{
    public interface IOtherEmployeeService
    {
        List<OtherEmployeeModel> GetAll();
        int Save(OtherEmployeeModel otherEmployeeModel);
        bool Delete(int id);
    }
}
