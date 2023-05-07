using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementCore.DataAccess.Interfaces
{
    public interface IAdminRepository:IEntityRepository<Admin>
    {
        Admin Get(string username);
    }
}
