using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;

namespace TMS.ViewModel
{
    public class AdminViewModel :ViewModelBase
    {
        public Admin admin;

        public AdminViewModel(Admin admin)
        {
            this.admin = admin;
        }

        public int AdminId
        {
            get { return admin.Id; }
        }

        public string AdminName
        {
            get
            {
                return admin.Login;
            }
            set
            {
                admin.Login = value;
                OnPropertyChanged("AdminName");
            }
        }

        public string AdminPassword
        {
            get
            {
                return admin.Password;
            }
            set
            {
                admin.Password = value;
                OnPropertyChanged("AdminPassword");
            }
        }
    }
}
