using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace HospitalManagement.Mappers.Implementations
{
    public class QueueMapper : IControlModelMapper<Queue, QueueModel>
    {
        private readonly IControlModelMapper<Patient, PatientModel> _patientMapper;
        private readonly IControlModelMapper<Doctor, DoctorModel> _doctorMapper;
        private readonly IControlModelMapper<Procedure, ProcedureModel> _procedureMapper;
        public QueueMapper(IControlModelMapper<Patient, PatientModel> patientMapper,
                                        IControlModelMapper<Doctor, DoctorModel> doctorMapper,
                                         IControlModelMapper<Procedure, ProcedureModel> procedureMapper)
        {
            _patientMapper = patientMapper;
            _procedureMapper = procedureMapper;
            _doctorMapper = doctorMapper;
        }

        public QueueModel Map(Queue queue)
        {
            var queueModel = new QueueModel();
            queueModel.Id = queue.Id;

            queueModel.Patient = new PatientModel();
            queueModel.Patient =_patientMapper.Map(queue.Patient);

            queueModel.Doctor = new DoctorModel();
            queueModel.Doctor = _doctorMapper.Map(queue.Doctor);

            queueModel.Procedure = new ProcedureModel();
            queueModel.Procedure = _procedureMapper.Map(queue.Procedure);
            queueModel.QueueNumber = queue.QueueNumber;
            queueModel.UseDate = queue.UseDate;
            return queueModel;

        }

        public Queue Map(QueueModel queueModel)
        {
            var queue = new Queue();
            queue.Id = queueModel.Id;
            queue.Patient =_patientMapper.Map(queueModel.Patient);
            queue.Doctor = _doctorMapper.Map(queueModel.Doctor);
            queue.Procedure = _procedureMapper.Map(queueModel.Procedure);
            queue.QueueNumber = queueModel.QueueNumber;
            queue.UseDate = queueModel.UseDate;
            return queue;
        }
    }
}
