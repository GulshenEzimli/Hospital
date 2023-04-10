using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Admins
{
    public class DeleteAdminCommand : BaseCommand
    {
        private readonly AdminsViewModel _adminsViewModel;
         public DeleteAdminCommand(AdminsViewModel adminsViewModel)
        {
            _adminsViewModel = adminsViewModel;
        }

        public override void Execute(object parameter)
        {
           
        }

    }
}
