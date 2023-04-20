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
    public class OpenPatientProcedureCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        private readonly IPatientProcedureMapper _patientProcedureMapper;
        public OpenPatientProcedureCommand(DashboardViewModel viewModel, IPatientProcedureMapper patientProcedureMapper)
        {
            _viewModel = viewModel;
            _patientProcedureMapper = patientProcedureMapper;
        }
        public override void Execute(object parameter)
        {
            PatientProcedureControl patientProcedureControl = new PatientProcedureControl();

            PatientProcedureViewModel patientProcedureViewModel = new PatientProcedureViewModel(_viewModel.Db,patientProcedureControl.ErrorDialog);
            
           
            //List<PatientProcedure> patientProcedures = _viewModel.Db.PatientProcedureRepository.Get();
            //int no = 1;
            //foreach (var patientProcedure in patientProcedures)
            //{
            //    var patientProcedureModel = _patientProcedureMapper.Map(patientProcedure);
            //    patientProcedureModel.No = no++;
            //    patientProcedureViewModel.PatientProcedureValues.Add(patientProcedureModel);
            //}

            patientProcedureControl.DataContext = patientProcedureViewModel;
            patientProcedureViewModel.AddProcedureObjects = patientProcedureControl.grdPatientProcedureAdded;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(patientProcedureControl);
        }
    }
}
