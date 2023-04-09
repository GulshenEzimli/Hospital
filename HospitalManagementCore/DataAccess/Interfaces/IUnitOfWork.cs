using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementCore.DataAccess.Interfaces
{
    internal interface IUnitOfWork
    {
        IDoctorRepository DoctorRepository { get; }
    }
}
