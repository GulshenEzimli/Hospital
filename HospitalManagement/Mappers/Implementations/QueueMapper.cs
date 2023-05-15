using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace HospitalManagement.Mappers.Implementations
{
    public class QueueMapper : IQueueMapper
    {
        private readonly IMapperUnitOfWork _mapperUnitOfWork;
        public QueueMapper(IMapperUnitOfWork mapperUnitOfWork)
        {
            _mapperUnitOfWork = mapperUnitOfWork;
        }
        
        public QueueModel Map(Queue queue)
        {
            var queueModel = new QueueModel();
            queueModel.Id = queue.Id;

            queueModel.Patient = new PatientModel();
            queueModel.Patient = _mapperUnitOfWork.PatientMapper.Map(queue.Patient);

            queueModel.Doctor = new DoctorModel();
            queueModel.Doctor = _mapperUnitOfWork.DoctorMapper.Map(queue.Doctor);

            queueModel.Procedure = new ProcedureModel();
            queueModel.Procedure = _mapperUnitOfWork.ProcedureMapper.Map(queue.Procedure);
            queueModel.QueueNumber = queue.QueueNumber;
            queueModel.UseDate = queue.UseDate;
            return queueModel;

        }

        public Queue Map(QueueModel queueModel)
        {
            var queue = new Queue();
            queue.Id = queueModel.Id;
            queue.Patient = _mapperUnitOfWork.PatientMapper.Map(queueModel.Patient);
            queue.Doctor = _mapperUnitOfWork.DoctorMapper.Map(queueModel.Doctor);
            queue.Procedure = _mapperUnitOfWork.ProcedureMapper.Map(queueModel.Procedure);
            queue.QueueNumber = queueModel.QueueNumber;
            queue.UseDate = queueModel.UseDate;
            return queue;
        }
    }
}
