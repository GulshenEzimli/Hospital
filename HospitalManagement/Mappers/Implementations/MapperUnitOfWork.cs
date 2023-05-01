using HospitalManagement.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Mappers.Implementations
{
    public class MapperUnitOfWork : IMapperUnitOfWork
    {
        public IDoctorMapper DoctorMapper => new DoctorMapper(this);

        public INurseMapper NurseMapper => new NurseMapper(this);
        public IOtherEmployeeMapper OtherEmployeeMapper => new OtherEmployeeMapper(this);
        public IPatientProcedureMapper PatientProcedureMapper => new PatientProcedureMapper(this);
        public IJobMapper JobMapper => new JobMapper();

        public IOperationMapper OperationMapper => new OperationMapper(this);

        public IPatientMapper PatientMapper => new PatientMapper();

        public IPositionMapper PositionMapper => new PositionMapper();

        public IProcedureMapper ProcedureMapper => new ProcedureMapper();

        public IQueueMapper QueueMapper => new QueueMapper(this);

        public IRoomMapper RoomMapper => new RoomMapper(this);

        public IReceptionistMapper ReceptionistMapper => new ReceptionistMapper();
    }
}
