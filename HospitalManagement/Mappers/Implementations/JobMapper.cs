using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Mappers.Implementations
{
    public class JobMapper : IJobMapper
    {
        public JobModel Map(Job job)
        {
            JobModel jobModel = new JobModel();
            jobModel.Id = job.Id;
            jobModel.Name = job.Name;

            return jobModel;
        }

        public Job Map(JobModel jobModel)
        {
            Job job = new Job();
            job.Id = jobModel.Id;
            job.Name = jobModel.Name;

            return job;
        }
    }
}
