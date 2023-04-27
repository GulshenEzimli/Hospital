using HospitalManagement.Enums;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Patients
{
    public class AddPatientCommand : BaseCommand
    {
        private readonly PatientsViewModel _patientViewModel;

        public AddPatientCommand(PatientsViewModel patientViewModel)
        {
            _patientViewModel = patientViewModel;
        }
        public override void Execute(object parameter)
        {
            _patientViewModel.CurrentSituation = Situations.ADD;
        }
    }
}
