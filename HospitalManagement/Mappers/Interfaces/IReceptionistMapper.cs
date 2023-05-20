using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Mappers.Interfaces
{
    public interface IReceptionistMapper
    {
        ReceptionistModel Map(Receptionist receptionist);
        Receptionist Map(ReceptionistModel receptionistModel);
    }
}
