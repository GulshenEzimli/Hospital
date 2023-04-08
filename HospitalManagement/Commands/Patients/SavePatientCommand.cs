using HospitalManagement.Enums;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Patients
{
    public class SavePatientCommand : BaseCommand
    {
        private readonly PatientsViewModel _patientViewModel;
        public SavePatientCommand(PatientsViewModel patientViewModel)
        {
            _patientViewModel = patientViewModel;
        }

        public override void Execute(object parameter)
        {
            //TO DO:IMPLEMENT SAVE
            _patientViewModel.CurrentSituation = (int)Situations.NORMAL;
        }
    }
}
