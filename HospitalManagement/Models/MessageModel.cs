using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class MessageModel
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public Brush TextColor => IsSuccess ? Brushes.Red : Brushes.Blue;
    }
}
