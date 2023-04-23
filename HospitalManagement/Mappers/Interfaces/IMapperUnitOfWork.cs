using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Mappers.Interfaces
{
    public interface IMapperUnitOfWork
    {
        IDoctorMapper DoctorMapper { get; }
        INurseMapper NurseMapper { get; }
        IOperationDoctorMapper OperationDoctorMapper { get; }   
        IOperationMapper OperationMapper { get; }
        IOperationNurseMapper OperationNurseMapper { get; }
        IOtherEmployeeMapper OtherEmployeeMapper { get; }
        IPatientMapper PatientMapper { get; }
        IPatientProcedureMapper PatientProcedureMapper { get; }
        IPositionMapper PositionMapper { get; }
        IProcedureMapper ProcedureMapper { get; }
    }
}
