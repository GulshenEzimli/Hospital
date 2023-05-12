using HospitalManagement.Commands.Doctors;
using HospitalManagement.Commands.Queues;
using HospitalManagement.Enums;
using HospitalManagement.Models;
using HospitalManagement.Services.Implementations;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Validations.Utils;
using HospitalManagement.Views.Components;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class QueuesViewModel:BaseControlViewModel
    {
        private readonly IQueueService _queueService;
        public QueuesViewModel(IQueueService queueService, ErrorDialog errorDialog) : base(errorDialog)
        {
            _queueService = queueService;
            CurrentValue = new QueueModel();
        }
        private Situations _currentSituation = Situations.NORMAL;
        public Situations CurrentSituation
        {
            get => _currentSituation;
            set
            {
                _currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }
        private QueueModel _currentValue;
        public QueueModel CurrentValue
        {
            get => _currentValue;
            set
            {
                _currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }

        private QueueModel _selectedValue;
        public QueueModel SelectedValue
        {
            get => _selectedValue;
            set
            {
                SetSelectedValue(value);
                if (value == null)
                    SetDefaultValues();
                else
                {
                    CurrentValue = new QueueModel();
                    CurrentValue = SelectedValue.Clone();
                    CurrentSituation = Situations.SELECTED;
                }
                OnPropertyChanged(nameof(_selectedValue));
            }
        }

        public List<QueueModel> AllValues { get; set; }

        private ObservableCollection<QueueModel> _values;
        public ObservableCollection<QueueModel> Values
        {
            get => _values ?? (_values = new ObservableCollection<QueueModel>());
            set
            {
                _values = value;
                OnPropertyChanged(nameof(Values));
            }

        }

        private List<PatientModel> _patients;
        public List<PatientModel> Patients
        {
            get => _patients ?? (_patients = new List<PatientModel>());
            set
            {
                _patients = value;
            }
        }

        private List<DoctorModel> _doctors;
        public List<DoctorModel> Doctors
        {
            get => _doctors ?? (_doctors = new List<DoctorModel>());
            set
            {
                _doctors = value;
            }
        }

        private List<ProcedureModel> _procedures;
        public List<ProcedureModel> Procedures
        {
            get => _procedures ?? (_procedures = new List<ProcedureModel>());
            set
            {
                _procedures = value;
            }
        }
        public AddQueueCommand Add => new AddQueueCommand(this);
        public DeleteQueueCommand Delete => new DeleteQueueCommand(this,_queueService);
        public EditQueueCommand Edit => new EditQueueCommand(this);
        public RejectQueueCommand Reject => new RejectQueueCommand(this);
        public SaveQueueCommand Save => new SaveQueueCommand(this,_queueService);

        public void SetDefaultValues()
        {
            CurrentSituation = Situations.NORMAL;
            CurrentValue = new QueueModel();
            SetSelectedValue(null);
        }

        public void SetSelectedValue(QueueModel model)
        {
            _selectedValue = model;
            OnPropertyChanged(nameof(SelectedValue));
        }

        public override string Header => "Queues";

        protected override void OnSearchTextChanged()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Values = new ObservableCollection<QueueModel>(AllValues);
            }
            else
            {
                string lowerText = SearchText.ToLower();
                var filteredValues = AllValues.Where(x => x.Procedure.Name?.ToLower().Contains(lowerText) == true ||
                                                          x.Doctor.DisplayDoctor?.ToLower().Contains(lowerText) == true ||
                                                          x.Patient.DisplayPatient?.ToLower().Contains(lowerText) == true ||
                                                          x.UseDate.ToString(SystemConstants.DateDisplayFormat).ToLower().Contains(lowerText) == true||
                                                          x.QueueNumber.ToString().Contains(lowerText) == true );
                Values = new ObservableCollection<QueueModel>(filteredValues);
            }
        }
    }
}
