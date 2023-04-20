using HospitalManagement.Models;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.Views.UserControls;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.PatientProcedures
{
    public class FromPatientToDoctor : BaseCommand
    {
        private PatientProcedureViewModel _patientProcedureViewModel;
        public FromPatientToDoctor(PatientProcedureViewModel patientProcedureViewModel)
        {
            _patientProcedureViewModel = patientProcedureViewModel;
        }
        public override void Execute(object parameter)
        {
            ProcedureDoctorControl procedureDoctorControl = new ProcedureDoctorControl();
            ProcedureDoctorViewModel procedureDoctorViewModel = new ProcedureDoctorViewModel(_patientProcedureViewModel.Db);
            procedureDoctorControl.DataContext = procedureDoctorViewModel;
            List<DoctorPosition> positions = _patientProcedureViewModel.Db.PositionRepository.Get();
            foreach (DoctorPosition position in positions)
            {
                procedureDoctorViewModel.PositionNames.Add(position.Name);
            }

            _patientProcedureViewModel.AddProcedureObjects.Children.Clear();
            _patientProcedureViewModel.AddProcedureObjects.Children.Add(procedureDoctorControl);
        }
    }
}
