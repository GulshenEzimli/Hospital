using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Interfaces
{
    public interface IOperationService
    {
        List<OperationModel> GetAll();
        int SaveOperation(OperationModel operationModel);
        bool DeleteOperation(int id);
    }
}
