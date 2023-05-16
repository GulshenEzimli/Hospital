using HospitalManagement.Commands.Patients;
using HospitalManagement.Commands.Procedures;
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
    public class ProceduresViewModel : BaseControlViewModel
    {
        private readonly IProcedureService _procedureService;

        public ProceduresViewModel(IProcedureService procedureService, ErrorDialog errorDialog) : base(errorDialog)
        {
            _procedureService = procedureService;
            AllValues = new List<ProcedureModel>();

            SetDefaultValues();
        }
        public override string Header => "Procedures";

        private Situations _currentSituation;
        public Situations CurrentSituation
        {
            get { return _currentSituation; }

            set
            {
                _currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }

        private ProcedureModel _currentValue;
        public ProcedureModel CurrentValue
        {
            get => _currentValue;
            set
            {
                _currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }
        private ProcedureModel _selectValue;
        public ProcedureModel SelectValue
        {
            get => _selectValue;
            set
            {
                _selectValue = value;

                if (value == null)
                {
                    SetSelectValue(value);
                    SetDefaultValues();
                }
                else
                {
                    CurrentValue = new ProcedureModel();
                    CurrentValue = SelectValue.Clone();
                    CurrentSituation = Situations.SELECTED;
                }

                OnPropertyChanged(nameof(SelectValue));
            }
        }

        private ObservableCollection<ProcedureModel> _values;
        public ObservableCollection<ProcedureModel> Values
        {
            get => _values ?? (_values = new ObservableCollection<ProcedureModel>());
            set
            {
                _values = value;
                OnPropertyChanged(nameof(Values));
            }
        }

        #region commands
        public List<ProcedureModel> AllValues { get; set; }
        public AddProcedureCommand Add => new AddProcedureCommand(this);
        public DeleteProcedureCommand Delete => new DeleteProcedureCommand(this, _procedureService);
        public EditProcedureCommand Edit => new EditProcedureCommand(this);
        public RejectProcedureCommand Reject => new RejectProcedureCommand(this);
        public SaveProcedureCommand Save => new SaveProcedureCommand(this, _procedureService);
        public ExportExcelProcedureCommand ExportExcel=>new ExportExcelProcedureCommand(this);
        #endregion

        public void SetDefaultValues()
        {
            CurrentSituation = Situations.NORMAL;
            CurrentValue = new ProcedureModel();
            SetSelectValue(null);
        }
        private void SetSelectValue(ProcedureModel procedureModel)
        {
            _selectValue = procedureModel;
            OnPropertyChanged(nameof(SelectValue));

        }

        protected override void OnSearchTextChanged()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Values = new ObservableCollection<ProcedureModel>(AllValues);
            }
            else
            {
                var lowerText = SearchText.ToLower();
                var filteredValues = AllValues.Where(x => x.Name?.ToLower().Contains(lowerText) == true ||
                                                 x.Cost.ToString().Contains(lowerText) == true).ToList();
                Values = new ObservableCollection<ProcedureModel>(filteredValues);
            }
        }
    }
}
