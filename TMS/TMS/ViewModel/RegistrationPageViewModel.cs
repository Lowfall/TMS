using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TMS.DataBase;
using TMS.UOW;
using TMS.Model;
using TMS.Commands;
using System.Windows;
using System.Text.RegularExpressions;
using System.Data.Entity.Validation;
using System.Windows.Media;

namespace TMS.ViewModel
{
    public class RegistrationPageViewModel : ViewModelBase
    {
        public ICommand AddClientCommand { get; set; }

        private string clientLogin;
        public string ClientLogin
        {
            get { return clientLogin; }
            set { clientLogin = value;
                OnPropertyChanged("ClientLogin");
            }
        }
        private string clientPassword;
        public string ClientPassword { 
            get { return clientPassword; }
            set
            {
                clientPassword = value;
                OnPropertyChanged("ClientPassword");
            }
        }

        public override int GetHashCode()
        {
            var symbols = ClientPassword.ToCharArray();
            int hash = 0;
            foreach(var character in symbols)
            {
                hash += character;
            }
            return hash * 13;
        }  

        private async void AddClient()
        {

            if (ClientLogin != "" && ClientPassword != "" && ClientLogin !=null && ClientPassword != null && ClientLogin.Trim()!=null && ClientPassword.Trim()!=null )
            {
                try
                {
                    await Task.Run(Add);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Some characters are not allowed");
                    ClientLogin = "";
                    ClientPassword = "";
                }
            }

            else
            {
                MessageBox.Show("Please fill the boxes");
            }
         }

        private async void Add()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                foreach(var item in uow.Clients.GetAll().ToList())
                {
                    if(item.Login == ClientLogin)
                    {
                        MessageBox.Show("This user is already registered");
                        return;
                    }
                }
                var client = new Client(ClientLogin, ClientPassword.GetHashCode().ToString());
                uow.Clients.Add(client);
                uow.Save();
                MessageBox.Show("You have made an account, now, please authorize");
            }
        }

        public RegistrationPageViewModel()
        {
            AddClientCommand = new RelayCommand(param => { AddClient(); });
        }
    }
}
