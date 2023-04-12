using HospitalManagement.Models;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Mappers.Interfaces
{
    public interface IPatientProcedureMapper
    {
        PatientProcedure Map(PatientProcedureModel model);
        PatientProcedureModel Map(PatientProcedure patientProcedure);
    }
}
