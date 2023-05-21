using HospitalManagement.Enums;
using HospitalManagement.Mappers.Interfaces;
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
    public class OtherEmployeesViewModel : BaseControlViewModel<OtherEmployeeModel>
    {
        private readonly IControlModelService<JobModel> _jobService;
        public OtherEmployeesViewModel(IControlModelService<JobModel> jobService,
                                       IControlModelService<OtherEmployeeModel> otherEmployeeService,
                                       ErrorDialog errorDialog) : base(otherEmployeeService, errorDialog)
        {
            _jobService = jobService;
        }
        public override string Header => "Other Employees";

        private List<JobModel> _jobNames;
        public List<JobModel> JobNames
        {
            get => _jobNames ?? (_jobNames = new List<JobModel>());
            set
            {
                _jobNames = value;
            }
        }

        public override void Load()
        {
            JobNames = _jobService.GetAll();
        }
    }
}
