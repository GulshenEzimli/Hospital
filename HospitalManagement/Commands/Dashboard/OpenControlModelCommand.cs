using HospitalManagement.Models.Interfaces;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.ViewModels.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HospitalManagement.Commands.Dashboard
{
    public class OpenControlModelCommand<T> : BaseCommand where T : IControlModel, new()
    {
        private readonly DashboardViewModel _viewModel;
        private readonly IControlModelService<T> _service;
        private readonly Func<UserControl> _controlCreator;
        private readonly Func<UserControl, BaseControlViewModel<T>> _controlViewModelCreator;
        public OpenControlModelCommand(DashboardViewModel viewModel,
                                       IControlModelService<T> service,
                                       Func<UserControl> controlCreator,
                                       Func<UserControl, BaseControlViewModel<T>> controlViewModelCreator)
        {
            _viewModel = viewModel;
            _service = service;
            _controlViewModelCreator = controlViewModelCreator;
            _controlCreator = controlCreator;
        }

        public override void Execute(object parameter)
        {
            var control = _controlCreator.Invoke();
            var controlViewModel = _controlViewModelCreator.Invoke(control);

            controlViewModel.Load();

            var model = _service.GetAll();

            controlViewModel.AllValues = model;
            controlViewModel.Values = new ObservableCollection<T>(model);

            control.DataContext = controlViewModel;

            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(control);
        }
    }
}
