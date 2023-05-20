using HospitalManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Interfaces
{
    public interface IControlModelService<T> where T : IControlModel, new()
    {
        List<T> GetAll();
        int Save(T model);
        bool Delete(int id);
    }
}
