using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Services.Interfaces;
using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Implementations
{
    public class QueueService : IControlModelService<QueueModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IControlModelMapper<Queue,QueueModel> _queueMapper;
        public QueueService(IUnitOfWork unitOfWork, IControlModelMapper<Queue,QueueModel> queueMapper)
        {
            _unitOfWork = unitOfWork;
            _queueMapper = queueMapper;
        }

        public bool Delete(int id)
        {
            return _unitOfWork.QueueRepository.Delete(id);
        }

        public List<QueueModel> GetAll()
        {
            var queues = _unitOfWork.QueueRepository.Get();
            var queueModels=new List<QueueModel>();
            int no = 1;
            foreach(var queue in queues)
            {
                var model = _queueMapper.Map(queue);
                model.No= no++;
                queueModels.Add(model);
            }
            return queueModels;
        }

        public int Save(QueueModel queueModel)
        {
            var toBeSavedQueue = _queueMapper.Map(queueModel);
            toBeSavedQueue.UseDate = DateTime.Now;
            if(toBeSavedQueue.Id==0)
            {
                var lastEntity = _unitOfWork.QueueRepository.Get().Where(x=>x.DoctorId == toBeSavedQueue.DoctorId).LastOrDefault();
                toBeSavedQueue.QueueNumber = lastEntity?.QueueNumber + 1 ?? 1;
                return _unitOfWork.QueueRepository.Insert(toBeSavedQueue);
            }
            else
            {
                _unitOfWork.QueueRepository.Update(toBeSavedQueue);
                return toBeSavedQueue.Id;
            }
        }
    }
}
