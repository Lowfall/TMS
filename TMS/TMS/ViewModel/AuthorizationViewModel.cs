using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TMS.Commands;
using TMS.Model;
using TMS.Services;
using TMS.View.Pages;

namespace TMS.ViewModel
{
    public class AuthorizationViewModel : ViewModelBase
    {

        private IWindowService _windowService;
        public ICommand CloseWindowCommand { get; set; }
        public ICommand ChangingPageCommand { get; set; }


        private string authText;
        private Page Authorization;
        private Page Registration;
        private Page _currentPage;


        public Page CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }
        public string AuthText
        {
            get { return authText; }
            set
            {
               authText = value;
                OnPropertyChanged("AuthText");
            }
        } 
        private void OnCloseWindow()
        {
            _windowService.CloseWindow();
        }
        private void ChangePage()
        {
            if(CurrentPage == Authorization)
            {
                CurrentPage = Registration;
                AuthText = "Log in";
            }
            else
            {
                CurrentPage = Authorization;
                AuthText = "Sign up";
            }
        }
        public AuthorizationViewModel(IWindowService windowService)
        { 
            _windowService = windowService;
            Authorization = new AuthorizationPage();
            Registration = new RegistrationPage();
            CloseWindowCommand = new RelayCommand(param => OnCloseWindow());
            ChangingPageCommand = new RelayCommand(param => ChangePage());
            CurrentPage = Authorization;
            AuthText = "Sign Up";
        }
    }
}
