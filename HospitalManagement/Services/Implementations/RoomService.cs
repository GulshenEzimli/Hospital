using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HospitalManagement.Services.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoomMapper _roomMapper;

        public RoomService(IUnitOfWork unitOfWork, IRoomMapper roomMapper)
        {
            _unitOfWork = unitOfWork;
            _roomMapper = roomMapper;
        }
        public bool Delete(int id)
        {
            return _unitOfWork.RoomRepository.Delete(id);
        }

        public List<RoomModel> GetAll()
        {
            var rooms = _unitOfWork.RoomRepository.Get();
            var roomModels = new List<RoomModel>();
            int no = 1;

            foreach (var room in rooms)
            {
                var roomModel = _roomMapper.Map(room);
                roomModel.No = no++;
                roomModels.Add(roomModel);
            }

            return roomModels;
        }

        public int Save(RoomModel roomModel)
        {
            var toBeSavedRoom = _roomMapper.Map(roomModel);

            if(toBeSavedRoom.Id == 0)
            {
                toBeSavedRoom.IsDelete = false;
                return _unitOfWork.RoomRepository.Insert(toBeSavedRoom);
            }
            else
            {
                var existingRoom = _unitOfWork.RoomRepository.GetById(toBeSavedRoom.Id);
                toBeSavedRoom.IsDelete = existingRoom.IsDelete;
                _unitOfWork.RoomRepository.Update(toBeSavedRoom);
                return toBeSavedRoom.Id;
            }

        }
    }
}
