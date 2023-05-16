using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Services.Interfaces;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Implementations
{
    public class ServiceUnitOfWork : IServiceUnitOfWork
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapperUnitOfWork _mapperUnitOfWork;
        public ServiceUnitOfWork(IUnitOfWork unitOfWork, IMapperUnitOfWork mapperUnitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapperUnitOfWork = mapperUnitOfWork;
        }
        public INurseService NurseService =>  new NurseService(_unitOfWork, _mapperUnitOfWork.NurseMapper);
        public IOtherEmployeeService OtherEmployeeService => new OtherEmployeeService(_unitOfWork, _mapperUnitOfWork.OtherEmployeeMapper);
        public IPatientProcedureService PatientProcedureService => new PatientProcedureService(_unitOfWork, _mapperUnitOfWork);
        public IJobService JobService => new JobService(_unitOfWork,_mapperUnitOfWork.JobMapper);
        public IDoctorService DoctorService => new DoctorService(_unitOfWork, _mapperUnitOfWork);
        public IPositionService PositionService => new PositionService(_unitOfWork, _mapperUnitOfWork);
        public IPatientService PatientService => new PatientService(_unitOfWork, _mapperUnitOfWork.PatientMapper);
        public IProcedureService ProcedureService => new ProcedureService(_unitOfWork,_mapperUnitOfWork.ProcedureMapper);
        public IQueueService QueueService => new QueueService(_unitOfWork,_mapperUnitOfWork);

        public IOperationService OperationService => new OperationService(_unitOfWork, _mapperUnitOfWork);

        public IReceptionistService ReceptionistService => new ReceptionistService(_unitOfWork, _mapperUnitOfWork.ReceptionistMapper);

        public IRoomService RoomService => new RoomService(_unitOfWork, _mapperUnitOfWork.RoomMapper);
    }
}
