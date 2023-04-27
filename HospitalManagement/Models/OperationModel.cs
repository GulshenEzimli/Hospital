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
        public int Id { get; set; }
        public int No { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal OperationCost { get; set; }
        public string OperationReason { get; set; }
        public PatientModel Patient { get; set; }
        public RoomModel Room { get; set; }
        public string DisplayPatient => $"{Patient.Name} {Patient.Surname} {Patient.PIN} {Patient.PhoneNumber}";
        public string DisplayRoom => $"{Room.BlockFloor}. mərtəbə {Room.Number} nömrəli {Room.Type} otağı";

        private ObservableCollection<OperationDoctorModel> _operationDoctors;
        public ObservableCollection<OperationDoctorModel> OperationDoctors
        {
            get => _operationDoctors ?? (_operationDoctors = new ObservableCollection<OperationDoctorModel>());
            set { _operationDoctors = value; }
        }
                
        private ObservableCollection<OperationNurseModel> _operationNurses;
        public ObservableCollection<OperationNurseModel> OperationNurses
        {
            get => _operationNurses ?? (_operationNurses = new ObservableCollection<OperationNurseModel>());
            set { _operationNurses =value; }        
        }

        public OperationModel Clone()
        {
            return new OperationModel()
            {
                Id = Id,
                No = No,
                OperationCost = OperationCost,
                OperationDate = OperationDate,
                OperationDoctors = OperationDoctors,
                OperationNurses = OperationNurses,
                OperationReason = OperationReason,
                Patient = Patient,
                //Room = Room
            };
        }
    }
}
