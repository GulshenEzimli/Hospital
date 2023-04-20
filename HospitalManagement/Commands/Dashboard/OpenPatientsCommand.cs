using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.ViewModels.Windows;
using HospitalManagement.Views.UserControls;
using HospitalManagementCore.Domain.Entities;
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
        private readonly IPatientMapper _patientMapper;

        public OpenPatientsCommand(DashboardViewModel viewModel,IPatientMapper patientMapper)
        {
            _viewModel = viewModel;
            _patientMapper=patientMapper;
        }   

        public override void Execute(object parameter)
        {
            var patientControl = new PatientControls();
            var controlViewModel = new PatientsViewModel(_viewModel.Db,_patientMapper, patientControl.ErrorDialog);
            
            int no = 1;
            var patients = _viewModel.Db.PatientRepository.Get();

            foreach( var patient in patients)
            {
                var patientModel=_patientMapper.Map(patient);
                patientModel.No = no++;
                controlViewModel.Values.Add(patientModel);
            }

            patientControl.DataContext = controlViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(patientControl);
        }
    }
}
