using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            DoctorPosition doctorPosition = new DoctorPosition();
            doctorPosition.Name = positionModel.Name;
            doctorPosition.Id = positionModel.Id;
            doctorPosition.Department = new Department()
            {
                Name = positionModel.DepartmentName
            };
            return doctorPosition;
        }
    }
}
