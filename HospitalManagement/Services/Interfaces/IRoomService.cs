using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Interfaces
{
    public interface IRoomService
    {
        List<RoomModel> GetAll();
        int Save(RoomModel roomModel);
        bool Delete(int Id);
    }
}
