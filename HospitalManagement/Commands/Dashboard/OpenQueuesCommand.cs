﻿using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.ViewModels.Windows;
using HospitalManagement.Views.UserControls;
using HospitalManagement.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Dashboard
{
    public class OpenQueuesCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;

        public OpenQueuesCommand(DashboardViewModel viewModel,IServiceUnitOfWork serviceUnitOfWork)
        {
            _viewModel = viewModel;
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        public override void Execute(object parameter)
        {
            QueuesControl queueControl = new QueuesControl();
            QueuesViewModel queueViewModel = new QueuesViewModel(_serviceUnitOfWork.QueueService,queueControl.ErrorDialog);

            var queueModels = _serviceUnitOfWork.QueueService.GetAll();
            queueViewModel.AllValues = queueModels;
            queueViewModel.Values = new ObservableCollection<QueueModel>(queueModels);

            queueViewModel.Patients = _serviceUnitOfWork.PatientService.GetAll();
            queueViewModel.Doctors = _serviceUnitOfWork.DoctorService.GetAll();
            queueViewModel.Procedures = _serviceUnitOfWork.ProcedureService.GetAll();

            queueControl.DataContext= queueViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(queueControl);
        }
    }
}
