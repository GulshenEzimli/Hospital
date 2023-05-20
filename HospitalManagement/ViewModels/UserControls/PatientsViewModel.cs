using HospitalManagement.Commands.Nurses;
using HospitalManagement.Commands.Patients;
using HospitalManagement.Enums;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Views.Components;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace HospitalManagement.ViewModels.UserControls
{
    public class PatientsViewModel : BaseControlViewModel<PatientModel>
    {
        public PatientsViewModel(IControlModelService<PatientModel> patientService,ErrorDialog errorDialog) : base(patientService, errorDialog)
        {
            
        }

        public override string Header => "Patients";
    }
}
