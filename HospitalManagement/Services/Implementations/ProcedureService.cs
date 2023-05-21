using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Utils;
using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Implementations
{
    public class ProcedureService : IControlModelService<ProcedureModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IControlModelMapper<Procedure,ProcedureModel> _procedureMapper;

        public ProcedureService(IUnitOfWork unitOfWork, IControlModelMapper<Procedure, ProcedureModel> procedureMapper)
        {
            _unitOfWork = unitOfWork;
            _procedureMapper = procedureMapper;
        }

        public bool Delete(int id)
        {
            var procedure = _unitOfWork.ProcedureRepository.GetById(id);
            procedure.IsDelete = true;
            return _unitOfWork.ProcedureRepository.Update(procedure);
        }

        public List<ProcedureModel> GetAll()
        {
            var procedureModels = new List<ProcedureModel>();
            var procedures = _unitOfWork.ProcedureRepository.Get();
            int no = 1;

            foreach (var procedure in procedures)
            {
                var procedureModel = _procedureMapper.Map(procedure);
                procedureModel.No = no++;
                procedureModels.Add(procedureModel);
            }

            return procedureModels;
        }

        public int Save(ProcedureModel procedureModel)
        {
            var saveProcedure = _procedureMapper.Map(procedureModel);
            if (saveProcedure.Id == 0)
            {
                return _unitOfWork.ProcedureRepository.Insert(saveProcedure);
            }
            else
            {
                var existingPatient = _unitOfWork.NurseRepository.GetById(procedureModel.Id);

                _unitOfWork.ProcedureRepository.Update(saveProcedure);
                return saveProcedure.Id;
            }
        }
        public bool IsValid(ProcedureModel procedureModel, out string message)
        {
            if (string.IsNullOrWhiteSpace(procedureModel.Name))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Procedure name");
                return false;
            }
            if (procedureModel.Cost == 0)
            {
                message = ValidationMessageProvider.GetRequiredMessage("Cost");
                return false;
            }
            message = null;
            return true;
        }


    }
}
