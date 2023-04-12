using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Mappers.Implementations
{
    public class PositionMapper : IPositionMapper
    {
        public PositionModel Map(DoctorPosition position)
        {
            PositionModel positionModel = new PositionModel();
            positionModel.Id = position.Id;
            positionModel.Name = position.Name;
            positionModel.DepartmentName = position.Department.Name;

            return positionModel;
        }

        public DoctorPosition Map(PositionModel positionModel)
        {
            throw new NotImplementedException();
        }
    }
}
