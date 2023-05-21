using HospitalManagement.Models.Interfaces;
using HospitalManagementCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Mappers.Interfaces
{
    public interface IControlModelMapper<TEntity,TModel> where TEntity : IEntity
                                                    where TModel : IControlModel,new()
    {
        TEntity Map(TModel model);
        TModel Map(TEntity entity); 
    }
}
