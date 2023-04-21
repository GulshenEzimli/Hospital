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
        private readonly IPatientMapper _patientMapper;
        private readonly IDoctorMapper _doctorMapper;
        private readonly INurseMapper _nurseMapper;
        private readonly IProcedureMapper _procedureMapper;
        public OpenPatientProcedureCommand(DashboardViewModel viewModel, IPatientProcedureMapper patientProcedureMapper,
            IPatientMapper patientMapper,IDoctorMapper doctorMapper, INurseMapper nurseMapper, IProcedureMapper procedureMapper)
        {
            _viewModel = viewModel;
            _patientProcedureMapper = patientProcedureMapper;
            _patientMapper = patientMapper;
            _doctorMapper = doctorMapper;
            _nurseMapper = nurseMapper;
            _procedureMapper = procedureMapper;
        }
        public override void Execute(object parameter)
        {
            PatientProcedureControl patientProcedureControl = new PatientProcedureControl();

            PatientProcedureViewModel patientProcedureViewModel = new PatientProcedureViewModel(_viewModel.Db,patientProcedureControl.ErrorDialog, _patientProcedureMapper);

            List<PatientProcedure> patientProcedures = _viewModel.Db.PatientProcedureRepository.Get();
            int no = 1;
            foreach (var patientProcedure in patientProcedures)
            {
                var patientProcedureModel = _patientProcedureMapper.Map(patientProcedure);
                patientProcedureModel.No = no++;
                patientProcedureViewModel.PatientProcedureValues.Add(patientProcedureModel);
            }

            List<Patient> patients = _viewModel.Db.PatientRepository.Get();
            foreach (var patient in patients)
            {
                patientProcedureViewModel.Patients.Add(_patientMapper.Map(patient));
            }

            List<Doctor> doctors = _viewModel.Db.DoctorRepository.Get();
            foreach (var doctor in doctors)
            {
                patientProcedureViewModel.Doctors.Add(_doctorMapper.Map(doctor));
            }

            List<Nurse> nurses = _viewModel.Db.NurseRepository.Get();
            foreach(var nurse in nurses)
            {
                patientProcedureViewModel.Nurses.Add(_nurseMapper.Map(nurse));
            }

            List<Procedure> procedures = _viewModel.Db.ProcedureRepository.Get();
            foreach (var procedure in procedures)
            {
                patientProcedureViewModel.Procedures.Add(_procedureMapper.Map(procedure));
            }

            patientProcedureControl.DataContext = patientProcedureViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(patientProcedureControl);
        }
    }
}
