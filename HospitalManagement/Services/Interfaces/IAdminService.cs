using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Interfaces
{
    public interface IAdminService
    {
        // TODO : add this service to IControlModelService
        bool Authorize(string username, string password);   
    }
}
