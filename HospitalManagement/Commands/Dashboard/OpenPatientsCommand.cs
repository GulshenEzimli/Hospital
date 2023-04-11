using HospitalManagement.Models;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.ViewModels.Windows;
using HospitalManagement.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Dashboard
{
    public class OpenPatientsCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        public OpenPatientsCommand(DashboardViewModel viewModel)
        {
            _viewModel = viewModel;
        }   

        public override void Execute(object parameter)
        {
            var controlViewModel = new PatientsViewModel(_viewModel.Db);
            var patientControl = new PatientControls();
            int no = 1;
            var patients = _viewModel.Db.PatientRepository.Get();
            foreach( var patient in patients)
            {
                var patientModel = new PatientModel();
                patientModel.Id = patient.Id;
                patientModel.FirstName = patient.Name;
                patientModel.LastName = patient.Surname;
                patientModel.PhoneNumber = patient.PhoneNumber;
                patientModel.Gender = patient.Gender;
                patientModel.BirthDate = patient.BirthDate;
                patientModel.No = no++;

                controlViewModel.Values.Add(patientModel);

            }
            patientControl.DataContext = controlViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(patientControl);
        }
    }
}
