using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Implementations
{
    public class PositionService : IPositionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapperUnitOfWork _mapperUnitOfWork;
        public PositionService(IUnitOfWork unitOfWork, IMapperUnitOfWork mapperUnitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapperUnitOfWork = mapperUnitOfWork;
        }
        public List<string> GetAll()
        {
            List<string> positionModels = new List<string>();
            List<DoctorPosition> positions = _unitOfWork.PositionRepository.Get();
            foreach (DoctorPosition position in positions)
            {
                PositionModel positionModel = _mapperUnitOfWork.PositionMapper.Map(position);
                positionModels.Add(positionModel.Name);
            }
            return positionModels;
        }
    }
}
