using HospitalManagement.Enums;
using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Validations;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.PatientProcedures
{
    public class SavePatientProcedureCommand : BaseCommand
    {
        private readonly PatientProcedureViewModel _patientProcedureViewModel;
        private readonly IPatientProcedureMapper _patientProcedureMapper;
        public SavePatientProcedureCommand(PatientProcedureViewModel patientProcedureViewModel, IPatientProcedureMapper patientProcedureMapper)
        {
            _patientProcedureViewModel = patientProcedureViewModel;
            _patientProcedureMapper = patientProcedureMapper;
        }
        public override void Execute(object parameter)
        {
            //TO DO...
            if(PatientProcedureValidation.IsValid(_patientProcedureViewModel.CurrentPatientProcedure,out string message) == false)
            {
                _patientProcedureViewModel.Message = new MessageModel()
                {
                    Message = message,
                    IsSuccess = false,
                };
                DoAnimation(_patientProcedureViewModel.ErrorDialog);
                return;
            }

            var patientProcedure = _patientProcedureMapper.Map(_patientProcedureViewModel.CurrentPatientProcedure);

            if (patientProcedure.Id == 0)
            {
                _patientProcedureViewModel.Db.PatientProcedureRepository.Insert(patientProcedure);
            }
            else
            {
                _patientProcedureViewModel.Db.PatientProcedureRepository.Update(patientProcedure);
            }
            _patientProcedureViewModel.CurrentPatientProcedure.No = _patientProcedureViewModel.PatientProcedureValues.LastOrDefault()?.No + 1 ?? 1;
            _patientProcedureViewModel.PatientProcedureValues.Add(_patientProcedureViewModel.CurrentPatientProcedure);

            _patientProcedureViewModel.SetDefaultValues();
        }
    }
}
