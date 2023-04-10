﻿using HospitalManagement.Commands.Admins;
using HospitalManagement.Commands.Nurses;
using HospitalManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class AdminsViewModel:BaseViewModel
    {
        public AdminsViewModel()
        {
            CurrentSituation = 1;
        }

        private int _currentSituation = (int)Situations.NORMAL;
        public int CurrentSituation
        {
            get => _currentSituation;
            set
            {
                _currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }

        public AddAdminCommand Add => new AddAdminCommand(this);
        public DeleteAdminCommand Delete => new DeleteAdminCommand(this);
        public EditAdminCommand Edit => new EditAdminCommand(this);
        public RejectAdminCommand Reject => new RejectAdminCommand(this);
        public SaveAdminCommand Save => new SaveAdminCommand(this);

    }
}