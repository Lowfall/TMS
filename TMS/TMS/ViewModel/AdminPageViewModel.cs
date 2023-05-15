using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TMS.Commands;
using TMS.UOW;
using TMS.Services;

namespace TMS.ViewModel
{
    public class AdminPageViewModel : ViewModelBase
    {

        public ICommand DeleteClientCommand { get; set; }
        public ICommand BanClientCommand { get; set; }
        public ICommand UnbanClientCommand { get; set; }
        public ICommand ChangeLoginCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        private ObservableCollection<ClientViewModel> clients;
        private ClientViewModel client;
        private string reason;
        private string login;
        private string password;

        public string Reason {
            get { return reason; }
            set { reason = value;
                OnPropertyChanged("Reason");
            }
        }

        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public ClientViewModel SelectedClient
        {
            get { return client; }
            set { client = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        public ObservableCollection<ClientViewModel> Clients
        {
            get { 
                return clients; 
            }
            set { 
                clients = value;
                OnPropertyChanged("Clients");
            }
        }

        private void ShowClients()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Clients = new ObservableCollection<ClientViewModel>(uow.Clients.GetAll().ToList().Select(b => new ClientViewModel(b)));
            }
        }

        private void DeleteClient()
        {
            if (SelectedClient != null)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.Clients.Delete(SelectedClient.ClientId);
                    uow.Save();
                }
                ShowClients();
            }
            else
            {
                MessageBox.Show("Choose client");
            }
        }

        private void BanClient()
        {
            if (SelectedClient != null && Reason != null && Reason != "")
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.Clients.Get(SelectedClient.ClientId).State = false;
                    uow.Clients.Get(SelectedClient.ClientId).Reason = Reason;
                    uow.Save();
                }
                ShowClients();
            }
            else
            {
                MessageBox.Show("Choose client and fill the reason of ban");
            }
        }

        private void ChangeLogin()
        {
            if (SelectedClient != null && Login != null && Login != "")
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.Clients.Get(SelectedClient.ClientId).Login = Login;
                    uow.Save();
                }
                ShowClients();
            }
            else
            {
                MessageBox.Show("Choose client and fill the box");
            }
        }
        private void ChangePassword()
        {
            if (SelectedClient != null && Password != null && Password != "")
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.Clients.Get(SelectedClient.ClientId).Password = Password.GetHashCode().ToString();
                    uow.Save();
                }
                ShowClients();
            }
            else
            {
                MessageBox.Show("Choose client and fill the box");
            }
        }

        private void UnbanClient()
        {
            if (SelectedClient != null)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.Clients.Get(SelectedClient.ClientId).State = true;
                    uow.Clients.Get(SelectedClient.ClientId).Reason = "-";
                    uow.Save();
                }
                ShowClients();
            }
            else
            {
                MessageBox.Show("Choose client");
            }
        }

        private void Exit()
        {
            var service = new WindowService();
            service.CloseAdmin();
            service.ShowMainWindow();
            MainViewModel.AdminActivated = false;
        }

        public AdminPageViewModel()
        {
            ShowClients();
            DeleteClientCommand = new RelayCommand(param => DeleteClient());
            BanClientCommand = new RelayCommand(param =>BanClient());
            UnbanClientCommand = new RelayCommand(param => UnbanClient());
            ChangeLoginCommand = new RelayCommand(param => ChangeLogin());
            ChangePasswordCommand = new RelayCommand(param => ChangePassword());
            ExitCommand = new RelayCommand(param => Exit());
        }
    }
}
