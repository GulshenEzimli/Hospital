using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
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
    public class PositionService : IControlModelService<PositionModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IControlModelMapper<DoctorPosition,PositionModel> _positionMapper;
        public PositionService(IUnitOfWork unitOfWork, IControlModelMapper<DoctorPosition, PositionModel> positionMapper)
        {
            _unitOfWork = unitOfWork;
            _positionMapper = positionMapper;
        }              

        public List<PositionModel> GetAll()
        {
            List<PositionModel> positionModels = new List<PositionModel>();
            List<DoctorPosition> positions = _unitOfWork.PositionRepository.Get();
            foreach (DoctorPosition position in positions)
            {
                PositionModel positionModel = _positionMapper.Map(position);
                positionModels.Add(positionModel);
            }
            return positionModels;
        }

        // TODO
        public int Save(PositionModel model)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
