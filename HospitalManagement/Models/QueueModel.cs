﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class QueueModel
    {
        public int Id { get; set; }
        public int No { get; set; }
        public PatientModel Patient { get; set; }
        public DoctorModel Doctor { get; set; }
        public ProcedureModel Procedure { get; set; }
        
        public DateTime UseDate { get; set; }
        public int QueueNumber { get; set; }
        //public int LastQueueNumber { get; set; }
        public QueueModel Clone()
        {
            return new QueueModel
            {
                Id = Id,
                No = No,
                Patient = Patient,
                Doctor = Doctor,
                Procedure = Procedure,
                UseDate = UseDate,
                QueueNumber = QueueNumber
            };
        }
    }
}
