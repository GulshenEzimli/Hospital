using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Interfaces
{
    public interface IProcedureService
    {
        List<ProcedureModel> GetAll();
        int Save(ProcedureModel procedureModel);
        bool Delete(int id);
    }
}
