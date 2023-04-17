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
        private readonly IOperationMapper _operationMapper;
        public OpenOperationsCommand(DashboardViewModel viewModel, IOperationMapper operationMapper)
        {
            _viewModel = viewModel;
            _operationMapper = operationMapper;
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
                OperationModel operationModel = _operationMapper.Map(operation);
                foreach (OperationDoctor operationDoctor in operationDoctors)
                {
                    if (operationDoctor.OperationId == operation.Id)
                    {
                        operationModel = _operationMapper.Map(operationDoctor, operationModel);
                    }
                }
                foreach (OperationNurse operationNurse in operationNurses)
                {
                    if (operationNurse.OperationId == operation.Id)
                    {
                        operationModel = _operationMapper.Map(operationNurse, operationModel);
                    }
                }
                operationModel.No = no++;
                operationsViewModel.Values.Add(operationModel);
            }

            operationControl.DataContext = operationsViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(operationControl);
        }
    }
}
