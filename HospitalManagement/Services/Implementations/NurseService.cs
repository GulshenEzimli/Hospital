using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Implementations
{
    public class NurseService : INurseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INurseMapper _nurseMapper;
        public NurseService(IUnitOfWork unitOfWork,INurseMapper nurseMapper)
        {
            _unitOfWork = unitOfWork;
            _nurseMapper = nurseMapper;
        }
        public bool Delete(int id)
        {
            
            var nurse = _unitOfWork.NurseRepository.GetById(id);

            nurse.IsDelete = true;
            nurse.ModifiedDate = DateTime.Now;
            nurse.Modifier = new Admin() { Id = 3 };

            return _unitOfWork.NurseRepository.Update(nurse);
        }

        public List<NurseModel> GetAll()
        {
            var nurseModels = new List<NurseModel>();
            var nurses = _unitOfWork.NurseRepository.Get();
            int no = 1;

            foreach (var nurse in nurses)
            {
                var nurseModel = _nurseMapper.Map(nurse);
                nurseModel.No = no++;
                nurseModels.Add(nurseModel);
            }
            
            return nurseModels;
        }

        public int Save(NurseModel nurseModel)
        {
            var toBeSavedNurse = _nurseMapper.Map(nurseModel);
            toBeSavedNurse.ModifiedDate = DateTime.Now;
            toBeSavedNurse.Modifier = new Admin() { Id = 3 };

            if (toBeSavedNurse.Id == 0)
            {
                toBeSavedNurse.CreationDate = DateTime.Now;
                toBeSavedNurse.Creator = new Admin() { Id = 3 };
                toBeSavedNurse.IsDelete = false;
                return _unitOfWork.NurseRepository.Insert(toBeSavedNurse);
            }
            else
            {
                var existingNurse = _unitOfWork.NurseRepository.GetById(nurseModel.Id);
                toBeSavedNurse.Creator = existingNurse.Creator;
                toBeSavedNurse.CreationDate = existingNurse.CreationDate;
                toBeSavedNurse.IsDelete = existingNurse.IsDelete;
                _unitOfWork.NurseRepository.Update(toBeSavedNurse);
                return toBeSavedNurse.Id;
            }
        }
    }
}
