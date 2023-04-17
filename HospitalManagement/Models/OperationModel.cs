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
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string PatientPIN { get; set; }
        public string PatientPhoneNumber { get; set; }
        public int RoomNumber { get; set; }
        public int RoomFloor { get; set; }
        public byte RoomType { get; set; }

        private ObservableCollection<OperationDoctorModel> _operationDoctors;
        public ObservableCollection<OperationDoctorModel> OperationDoctors => _operationDoctors ?? (_operationDoctors = new ObservableCollection<OperationDoctorModel>());

        private ObservableCollection<OperationNurseModel> _operationNurses;
        public ObservableCollection<OperationNurseModel> OperationNurses => _operationNurses ?? (_operationNurses = new ObservableCollection<OperationNurseModel>());
    }
}
