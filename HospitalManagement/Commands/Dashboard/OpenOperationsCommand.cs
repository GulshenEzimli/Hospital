using HospitalManagement.Mappers.Implementations;
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
    public class OpenOperationsCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        public OpenOperationsCommand(DashboardViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            OperationControl operationControl = new OperationControl();
            OperationsViewModel operationsViewModel = new OperationsViewModel(_viewModel.Db, operationControl.ErrorDialog);

            List<Operation> operations = _viewModel.Db.OperationRepository.Get();
            List<OperationDoctor> operationDoctors = _viewModel.Db.OperationDoctorRepository.Get();
            List<OperationNurse> operationNurses = _viewModel.Db.OperationNurseRepository.Get();
            int no = 1;
            foreach (Operation operation in operations)
            {
                OperationModel operationModel = new OperationModel();
                operationModel.Id = operation.Id;
                operationModel.OperationDate = operation.OperationDate;
                operationModel.OperationCost = operation.OperationCost;
                operationModel.OperationReason = operation.OperationReason;
                operationModel.PatientName = operation.Patient.Name;
                operationModel.PatientSurname = operation.Patient.Surname;
                operationModel.PatientPIN = operation.Patient.PIN;
                operationModel.PatientPhoneNumber = operation.Patient.PhoneNumber;
                operationModel.RoomNumber = operation.Room.Number;
                operationModel.RoomFloor = operation.Room.BlockFloor;
                operationModel.RoomType = operation.Room.Type;
                operationModel.No = no++;
                foreach (OperationDoctor operationDoctor in operationDoctors)
                {
                    if(operationDoctor.OperationId == operation.Id) 
                    {
                        DoctorModel doctorModel = new DoctorModel();
                        doctorModel.FirstName = operationDoctor.Doctor.FirstName;
                        doctorModel.LastName = operationDoctor.Doctor.LastName;
                        doctorModel.PIN = operationDoctor.Doctor.PIN;
                        operationModel.OperationDoctors.Add(doctorModel);
                    }
                }
                foreach (OperationNurse operationNurse in operationNurses)
                {
                    if (operationNurse.OperationId == operation.Id)
                    {
                        NurseModel nurseModel = new NurseModel();
                        nurseModel.FirstName = operationNurse.Nurse.FirstName;
                        nurseModel.LastName = operationNurse.Nurse.LastName;
                        nurseModel.PIN = operationNurse.Nurse.PIN;
                        operationModel.OperationNurses.Add(nurseModel);
                    }
                }
                operationsViewModel.Values.Add(operationModel);
            }

            operationControl.DataContext = operationsViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(operationControl);
        }
    }
}
