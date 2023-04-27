using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Implementations
{
    public class QueueService : IQueueService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQueueMapper _queueMapper;
        public QueueService(IUnitOfWork unitOfWork, IQueueMapper queueMapper)
        {
            _queueMapper = queueMapper;
            _unitOfWork = unitOfWork;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<QueueModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Save(QueueModel queueModel)
        {
            throw new NotImplementedException();
        }
    }
}
