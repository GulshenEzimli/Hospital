using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Interfaces
{
    public interface IServiceUnitOfWork
    {
        INurseService nurseService { get; }
        IOtherEmployeeService otherEmployeeService { get; }
        IPatientProcedureService patientProcedureService { get; }
        IDoctorService doctorService { get; }
        IPositionService positionService { get; }
        IPatientService patientService { get; }
        IProcedureService procedureService { get; }
    }
}
