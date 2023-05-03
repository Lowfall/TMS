using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;

namespace TMS.ViewModel
{
    class ClientViewModel : ViewModelBase
    {
        public Client Client;

        public ClientViewModel(Client client)
        {
            this.Client = client;
        }   

        public int ClientId {
            get { return Client.ClientId; }
            set { 
                Client.ClientId = value;
                OnPropertyChanged("Id");
            }
        }

        public string Login
        {
            get { return Client.Login; }
            set
            {
                Client.Login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get { return Client.Password; }
            set
            {
                Client.Password = value;
                OnPropertyChanged("Password");
            }
        }
    }
}
