using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.ViewModels.Windows;
using HospitalManagement.Views.UserControls;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Dashboard
{
    public class OpenPatientProcedureCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        private readonly IPatientProcedureService _patientProcedureService;
        public OpenPatientProcedureCommand(DashboardViewModel viewModel, IPatientProcedureService patientProcedureService)
        {
            _viewModel = viewModel;
           _patientProcedureService = patientProcedureService;
        }
        public override void Execute(object parameter)
        {
            PatientProcedureControl patientProcedureControl = new PatientProcedureControl();
            PatientProcedureViewModel patientProcedureViewModel = new PatientProcedureViewModel(_patientProcedureService,patientProcedureControl.ErrorDialog);

            var patientProcedureModels = _patientProcedureService.GetAll();
            patientProcedureViewModel.AllValues = patientProcedureModels;
            patientProcedureViewModel.PatientProcedureValues = new ObservableCollection<PatientProcedureModel>(patientProcedureModels);

            //List<Patient> patients = _viewModel.Db.PatientRepository.Get();
            //foreach (var patient in patients)
            //{
            //    patientProcedureViewModel.Patients.Add(_patientMapper.Map(patient));
            //}

            //List<Doctor> doctors = _viewModel.Db.DoctorRepository.Get();
            //foreach (var doctor in doctors)
            //{
            //    patientProcedureViewModel.Doctors.Add(_doctorMapper.Map(doctor));
            //}

            //List<Nurse> nurses = _viewModel.Db.NurseRepository.Get();
            //foreach(var nurse in nurses)
            //{
            //    patientProcedureViewModel.Nurses.Add(_nurseMapper.Map(nurse));
            //}

            //List<Procedure> procedures = _viewModel.Db.ProcedureRepository.Get();
            //foreach (var procedure in procedures)
            //{
            //    patientProcedureViewModel.Procedures.Add(_procedureMapper.Map(procedure));
            //}

            patientProcedureControl.DataContext = patientProcedureViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(patientProcedureControl);
        }
    }
}
