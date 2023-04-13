using HospitalManagement.Models;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public abstract class BaseControlViewModel : BaseViewModel
    {
        protected BaseControlViewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public abstract string Header { get; }
        private MessageModel _message = new MessageModel();
        public MessageModel Message {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message)); 
            }      
        }

    }
}
