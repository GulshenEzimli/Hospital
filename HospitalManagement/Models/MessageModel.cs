﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HospitalManagement.Models
{
    public class MessageModel
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public Brush TextColor => IsSuccess ? Brushes.Blue : Brushes.Red;
    }
}
