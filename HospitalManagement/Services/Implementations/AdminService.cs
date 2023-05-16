using HospitalManagement.Services.Interfaces;
using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool Authorize(string username, string password)
        {
            var admin = _unitOfWork.AdminRepository.Get(username);

            if (admin == null)
                return false;

            var passwordHash = MySecurityHelper.ComputeSha256Hash(password);
            if (admin.Password!=passwordHash)
                return false;

            Kernel.Admin = admin;
            return true;

        }
    }
}
