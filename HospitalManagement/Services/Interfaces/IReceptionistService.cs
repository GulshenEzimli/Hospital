using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Interfaces
{
    public interface IReceptionistService
    {
        List<ReceptionistModel> GetAll();
        int Save(ReceptionistModel receptionistModel);
        bool Delete(int id);

    }
}
