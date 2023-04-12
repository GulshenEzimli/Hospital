using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementCore.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IDoctorRepository DoctorRepository { get; }
        INurseRepository NurseRepository { get; }
        IOtherEmployeeRepository OtherEmployeeRepository { get; }
        IPatientProcedureRepository PatientProcedureRepository { get; }
        IReceptionistRepository ReceptionistRepository { get; }
        IPatientRepository PatientRepository { get; }
        IProcedureRepository ProcedureRepository { get; }
    }
}
