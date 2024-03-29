﻿using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using HospitalManagement.Attributes;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Models.Interfaces;
using HospitalManagement.Utils;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models.Implementations
{
    public class OperationModel : IControlModel
    {
        public OperationModel() 
        {
            Doctors = new ObservableCollection<DoctorModel>();
            Nurses = new ObservableCollection<NurseModel>();
        }

        [ExcelIgnore]
        public int Id { get; set; }
        public int No { get; set; }

        [ExcelColumn("Date of operation")]
        public DateTime OperationDate { get; set; }

        [ExcelColumn("Cost of operation")]
        public decimal OperationCost { get; set; }

        [ExcelColumn("Reason of operation")]
        public string OperationReason { get; set; }
        public PatientModel Patient { get; set; }
        public RoomModel Room { get; set; }
               
        public ObservableCollection<DoctorModel> Doctors { get; set; }
        public ObservableCollection<NurseModel> Nurses { get; set; }

        public IControlModel Clone()
        {
            OperationModel operationModel = new OperationModel()
            {
                Id = Id,
                No = No,
                OperationCost = OperationCost,
                OperationDate = OperationDate,
                OperationReason = OperationReason,
                Patient = (PatientModel)Patient.Clone(),
                Room = (RoomModel)Room.Clone()
            };
            var clonedDoctors = Doctors.Select(x=>x.Clone()).Cast<DoctorModel>();
            operationModel.Doctors = new ObservableCollection<DoctorModel>(clonedDoctors);

            var clonedNurses = Nurses.Select(x => x.Clone()).Cast<NurseModel>();
            operationModel.Nurses = new ObservableCollection<NurseModel>(clonedNurses);
            return operationModel;
        }
        public bool IsCompatibleWithFilter(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return true;

            string lowerSearchText = searchText.ToLower();

            if (OperationCost.ToString().Contains(lowerSearchText))
                return true;

            if (OperationReason?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (OperationDate.ToString(SystemConstants.DateDisplayFormat).Contains(lowerSearchText))
                return true;

            if (Patient.DisplayPatient?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (Room.DisplayRoom?.ToLower().Contains(lowerSearchText) == true)
                return true;

            if (Doctors.Any(x => x.IsCompatibleWithFilter(lowerSearchText)))
                return true;

            if (Nurses.Any(x => x.IsCompatibleWithFilter(lowerSearchText)))
                return true;

            return false;
        }
    }
}
