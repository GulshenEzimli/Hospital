using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Implementations
{
    public class PatientProcedureService : IPatientProcedureService
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PatientProcedureModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool IsValid(PatientProcedureModel patientProcedureModel, out string message)
        {
            throw new NotImplementedException();
        }

        public int Save(PatientProcedureModel patientProcedureModel)
        {
            throw new NotImplementedException();
        }
    }
}
