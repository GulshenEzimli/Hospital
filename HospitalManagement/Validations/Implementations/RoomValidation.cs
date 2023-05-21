using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Validations.Interfaces;
using HospitalManagement.Validations.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Validations.Implementations
{
    public class RoomValidation : IControlModelValidation<RoomModel>
    {
        public bool IsValid(RoomModel roomModel, out string message)
        {
            if(roomModel.Number <= 0)
            {
                message = ValidationMessageProvider.GetGreaterThanMessage("Number", 0);
                return false;
            }

            if(roomModel.BlockFloor <= 0)
            {
                message = ValidationMessageProvider.GetGreaterThanMessage("Block floor", 0);
                return false;
            }

            message = null;
            return true;
        }
    }
}
