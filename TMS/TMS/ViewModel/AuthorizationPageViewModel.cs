using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TMS.Commands;
using TMS.Model;
using TMS.UOW;
using TMS.Services;

namespace TMS.ViewModel
{
    public class AuthorizationPageViewModel : ViewModelBase
    {
        public ICommand ShowAllClientsCommand { get; set; }

        private string clientLogin;
        public string ClientLogin
        {
            get { return clientLogin; }
            set
            {
                clientLogin = value;
                OnPropertyChanged("ClientLogin");
            }
        }
        private string clientPassword;
        public string ClientPassword
        {
            get { return clientPassword; }
            set
            {
                clientPassword = value;
                OnPropertyChanged("ClientPassword");
            }
        }

        private void ShowClients()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var clients = uow.Clients.GetAll().ToList<Client>();
                bool state = false;
                foreach (var client in clients)
                {
                    if (client.Login == ClientLogin && client.Password == ClientPassword.GetHashCode().ToString())
                    {
                        if (client.State == true)
                        {
                            state = true;
                            ActualAccount = client;
                        }
                        else
                        {
                            MessageBox.Show("This account was banned");
                            return;
                        }
                    }
                }
                if (state == true)
                {
                    MessageBox.Show("You are enter account");
                    AccountActivated = true;
                    new WindowService().CloseWindow();
                }
                else
                {
                    MessageBox.Show("There is no such user");
                }
            }
        }

        public AuthorizationPageViewModel()
        {
            ShowAllClientsCommand = new RelayCommand(param => { ShowClients(); });
        }
    }
}
