using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Mappers.Implementations
{
    public class ProcedureMapper : IProcedureMapper
    {
        public ProcedureModel Map(Procedure procedure)
        {
            var procedureModel = new ProcedureModel();
            procedureModel.Id = procedure.Id;
            procedureModel.Name = procedure.Name;
            procedureModel.Cost = procedure.Cost;

            return procedureModel;
        }

        public Procedure Map(ProcedureModel procedureModel)
        {
            var procedure = new Procedure();
            procedure.Id = procedureModel.Id;
            procedure.Name = procedureModel.Name;
            procedure.Cost=procedureModel.Cost;

            return procedure;
        }
    }
}
