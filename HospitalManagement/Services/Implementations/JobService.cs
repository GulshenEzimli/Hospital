using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
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
    public class JobService : IJobService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJobMapper _jobMapper;
        public JobService(IUnitOfWork unitOfWork,IJobMapper jobMapper)
        {
            _unitOfWork = unitOfWork;
            _jobMapper = jobMapper;
        }
        public List<JobModel> GetAll()
        {
            List<Job> jobs = _unitOfWork.JobRepository.Get();
            List<JobModel> jobModels = new List<JobModel>();
            foreach (Job job in jobs)
            {
                var jobModel = _jobMapper.Map(job); 
                jobModels.Add(jobModel);
            }
            return jobModels;
        }
    }
}
