using DocumentFormat.OpenXml.Wordprocessing;
using HospitalManagement.Attributes;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Models.Interfaces;
using HospitalManagement.Validations.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models.Implementations
{
    public class QueueModel : IControlModel
    {
        [ExcelIgnore]
        public int Id { get; set; }
        public int No { get; set; }
        public PatientModel Patient { get; set; }
        public DoctorModel Doctor { get; set; }
        public ProcedureModel Procedure { get; set; }
        public DateTime UseDate { get; set; }
        public int QueueNumber { get; set; }
        public IControlModel Clone()
        {
            return new QueueModel
            {
                Id = Id,
                No = No,
                Patient = (PatientModel)Patient.Clone(),
                Doctor = (DoctorModel)Doctor.Clone(),
                Procedure = (ProcedureModel)Procedure.Clone(),
                UseDate = UseDate,
                QueueNumber = QueueNumber
            };
        }
        public bool IsCompatibleWithFilter(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return true;

            string lowerSearchText = searchText.ToLower();

            if (Procedure.Name?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (Doctor.DisplayDoctor?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (Patient.DisplayPatient?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (UseDate.ToString(SystemConstants.DateDisplayFormat).ToLower().Contains(lowerSearchText))
                return true;

            if (QueueNumber.ToString().Contains(lowerSearchText))
                return true;

            return false;            
        }
    }
}
