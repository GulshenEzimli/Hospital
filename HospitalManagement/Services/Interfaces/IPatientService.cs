using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Interfaces
{
    public interface IPatientService
    {
        List<PatientModel> GetAll();
        int Save(PatientModel patientModel);
        bool Delete(int id);
    }
}
