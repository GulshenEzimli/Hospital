using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Interfaces
{
    public interface IServiceUnitOfWork
    {
        INurseService NurseService { get; }
        IOtherEmployeeService OtherEmployeeService { get; }
        IPatientProcedureService PatientProcedureService { get; }
        IJobService JobService { get; }
        IDoctorService DoctorService { get; }
        IPositionService PositionService { get; }
        IPatientService PatientService { get; }
        IProcedureService ProcedureService { get; }
        IQueueService QueueService { get; }
        IOperationService OperationService { get; }
        IReceptionistService ReceptionistService { get; }
        IRoomService RoomService { get; }
    }
}
