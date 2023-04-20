using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class ProcedureDoctorViewModel : BaseViewModel
    {
        public ProcedureDoctorViewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        private List<string> _positionNames;
        public List<string> PositionNames => _positionNames ?? (_positionNames = new List<string>());
    }
}
