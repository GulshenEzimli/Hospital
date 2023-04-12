using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace HospitalManagement.Models
    {
        public class PatientProcedureModel
        {
            public int Id { get; set; }
            public string PatientName { get; set; }
            public string PatientSurname { get; set; }
            public string PatientPIN { get; set; }
            public string DoctorName { get; set; }
            public string DoctorSurname { get; set; }
            public string DoctorPIN { get; set; }
            public string NurseName { get; set; }
            public string NurseSurname { get; set; }
            public string NursePIN { get; set; }
            public string ProcedureName { get; set; }
            public decimal Cost { get; set; }
            public DateTime UseDate { get; set; }

        }
    }

}
