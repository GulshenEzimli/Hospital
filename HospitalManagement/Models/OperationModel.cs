using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class OperationModel
    {
        public OperationModel() 
        {
            Doctors = new ObservableCollection<DoctorModel>();
            Nurses = new ObservableCollection<NurseModel>();
        }
        public int Id { get; set; }
        public int No { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal OperationCost { get; set; }
        public string OperationReason { get; set; }
        public PatientModel Patient { get; set; }
        public RoomModel Room { get; set; }
        public string DisplayPatient => $"{Patient.Name} {Patient.Surname} {Patient.PIN} {Patient.PhoneNumber}";
        public string DisplayRoom => $"{Room.BlockFloor}. mərtəbə {Room.Number} nömrəli {Room.Type} otağı";
               
        public ObservableCollection<DoctorModel> Doctors { get; set; }
        public ObservableCollection<NurseModel> Nurses { get; set; }

        public OperationModel Clone()
        {
            OperationModel operationModel = new OperationModel()
            {
                Id = Id,
                No = No,
                OperationCost = OperationCost,
                OperationDate = OperationDate,
                OperationReason = OperationReason,
                Patient = Patient,
                Room = Room
            };
            var clonedDoctors = Doctors.Select(x=>x.Clone()).Cast<DoctorModel>();
            operationModel.Doctors = new ObservableCollection<DoctorModel>(clonedDoctors);

            var clonedNurses = Nurses.Select(x => x.Clone()).Cast<NurseModel>();
            operationModel.Nurses = new ObservableCollection<NurseModel>(clonedNurses);
            return operationModel;
        }
    }
}
