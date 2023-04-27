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
        IOtherEmployeeMapper OtherEmployeeMapper { get; }
        IPatientProcedureMapper PatientProcedureMapper { get; }
        IJobMapper JobMapper { get; }
        IOperationDoctorMapper OperationDoctorMapper { get; }   
        IOperationMapper OperationMapper { get; }
        IOperationNurseMapper OperationNurseMapper { get; }
        IPatientMapper PatientMapper { get; }
        IPositionMapper PositionMapper { get; }
        IProcedureMapper ProcedureMapper { get; }
        IQueueMapper QueueMapper { get; }
        IRoomMapper RoomMapper { get; }
    }
}
