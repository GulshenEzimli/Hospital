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
    public interface IPositionMapper
    {
        PositionModel Map(DoctorPosition position);
        DoctorPosition Map(PositionModel positionModel);
    }
}
