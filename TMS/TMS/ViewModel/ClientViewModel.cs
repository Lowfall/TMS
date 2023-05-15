using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TMS.Model;

namespace TMS.ViewModel
{
    public class ClientViewModel : ViewModelBase
    {
        public Client Client;
        private SolidColorBrush color;

        public SolidColorBrush Color
        {
            get { return color; }
            set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }

        private void SetColor()
        {
            if (Client.State == true)
            {
                Color = Brushes.Green;
            }
            else
            {
                Color = Brushes.Red;
            }
        }

        public ClientViewModel(Client client)
        {
            this.Client = client;
            SetColor();

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

        public bool State
        {
            get { return Client.State; }
            set { Client.State = value;
                OnPropertyChanged("State");
            }
        }

        public string Reason
        {
            get { return Client.Reason; }
            set { Client.Reason = value;
                OnPropertyChanged("Reason");
            }
        }
    }
}
