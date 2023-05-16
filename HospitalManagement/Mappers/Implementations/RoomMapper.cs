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
    internal class RoomMapper : IRoomMapper
    {
        private readonly IMapperUnitOfWork _mapperUnitOfWork;
        public RoomMapper(IMapperUnitOfWork mapperUnitOfWork) 
        {
            _mapperUnitOfWork = mapperUnitOfWork;
        }
        public RoomModel Map(Room room)
        {
            RoomModel roomModel = new RoomModel();
            roomModel.Id = room.Id;
            roomModel.BlockFloor = room.BlockFloor;
            roomModel.Number = room.Number;
            roomModel.Type = room.Type;
            if (room.IsAvailable) roomModel.IsAvailable[0] = room.IsAvailable;
            else roomModel.IsAvailable[1] = !room.IsAvailable;
            return roomModel;
            
        }

        public Room Map(RoomModel roomModel)
        {
            Room room = new Room();
            room.Id = roomModel.Id;
            room.BlockFloor = roomModel.BlockFloor;
            room.Number = roomModel.Number;
            room.Type = roomModel.Type;
            room.IsAvailable = roomModel.IsAvailable[0] ? true : false;
            return room;
        }
    }
}
