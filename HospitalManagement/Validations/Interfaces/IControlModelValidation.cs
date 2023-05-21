using HospitalManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Validations.Interfaces
{
    public interface IControlModelValidation<T> where T : IControlModel,new()
    {
        bool IsValid(T model,out string message);   
    }
}
