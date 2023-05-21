using HospitalManagement.Enums;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Utils;
using HospitalManagement.Views.Components;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class ReceptionistViewModel : BaseControlViewModel<ReceptionistModel>
    {
        private readonly IControlModelService<JobModel> _jobService;
        public ReceptionistViewModel(IControlModelService<JobModel> jobService,
                                     IControlModelService<ReceptionistModel> receptionistService,
                                     ErrorDialog errorDialog) : base(receptionistService, errorDialog)
        {
            _jobService = jobService;
        }

        public override string Header => "Receptionists";

        private List<JobModel> _jobs;
        public List<JobModel> Jobs
        {
            get => _jobs ?? (_jobs = new List<JobModel>());
            set { _jobs = value; }
        }

        public override void Load()
        {
            Jobs = _jobService.GetAll();
        }
    }
}
