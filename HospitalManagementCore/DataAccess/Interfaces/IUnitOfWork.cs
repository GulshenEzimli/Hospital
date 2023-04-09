using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementCore.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IDoctorRepository DoctorRepository { get; }
    }
}
