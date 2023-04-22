using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Interfaces
{
    public interface IPatientProcedureService
    {
        List<PatientProcedureModel> GetAll();
        int Save(PatientProcedureModel patientProcedureModel);
        bool Delete(int id);
        bool IsValid(PatientProcedureModel patientProcedureModel, out string message);
    }
}
