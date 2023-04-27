using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Interfaces
{
    public interface IQueueService
    {
        List<QueueModel> GetAll();
        int Save(QueueModel queueModel);
        bool Delete(int id);
    }
}
