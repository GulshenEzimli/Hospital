using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Interfaces
{
    public interface IDoctorService
    {
        List<DoctorModel> GetAll();
        int SaveDoctor(DoctorModel doctorModel);
        bool DeleteDoctor(int id);
    }
}
