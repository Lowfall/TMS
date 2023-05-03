using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TMS.Services;
using TMS.Commands;
using System.Windows;
using System.Collections.ObjectModel;
using TMS.Model;
using TMS.UOW;

namespace TMS.ViewModel
{
    internal class MainViewModel : ViewModelBase 
    {
        private IWindowService _windowService;

        public ObservableCollection<TaskPageViewModel> taskPagesList;

        public ObservableCollection<TaskPageViewModel> TaskPagesList
        {
            get { return taskPagesList; }
            set { taskPagesList = value; 
                OnPropertyChanged("TaskPagesList"); }
        }

        public ICommand OpenWindowCommand { get; set; }
        public ICommand AddPageCommand { get; set; }

        private Style authButtonStyle;
        private string authContentButton;
        private string pageName;
        private string pageType;
        

        public string PageName
        {
            get { return pageName;}
            set { pageName = value;
                OnPropertyChanged("PageName"); }
        }
        public string PageType
        {
            get { return pageType; }
            set
            {
                pageType = value;
                OnPropertyChanged("PageType");
            }
        }
        public Style AuthButtonStyle
        {
            get { return authButtonStyle; }
            set
            {
                authButtonStyle = value;
                OnPropertyChanged("AuthButtonStyle");
            }
        }
        
        public string AuthContentButton {
            get { return authContentButton; }
            set { authContentButton = value;
                OnPropertyChanged("AuthContentButton");
            }
        }
        private void OnOpenWindow()
        {
            if(AccountActivated == true)
            {
                var dictionary = new ResourceDictionary();
                dictionary.Source = new Uri("Dictionaries/DarkTheme.xaml", UriKind.RelativeOrAbsolute);
                AuthButtonStyle = (Style)dictionary["accountButton"];
                AuthContentButton = ActualAccount.Login.ToString();
                ShowPages();
            }
            else
            {
                _windowService.OpenWindow();
            }
        }

        private void ShowPages()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                List<TaskPage> allPages = new List<TaskPage>();
                var pages = uow.Tasks.GetAll().ToList();
                if (pages != null)
                {
                    foreach (var page in pages)
                    {
                        if (page.ClientId == ActualAccount.ClientId)
                        {
                            allPages.Add(page);
                        }

                    }
                    TaskPagesList = new ObservableCollection<TaskPageViewModel>(allPages.Select(b => new TaskPageViewModel(b)));
                    uow.Save();
                }
            }
        }


        private void Add()
        {
            if (AccountActivated == true)
            {
                if (PageName != null && PageType != null && PageName != "" && PageName.Trim() != null)
                {
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        uow.Tasks.Add(new TaskPage(PageName, PageType));
                        uow.Save();
                        ShowPages();
                    }
                }
                else
                {
                    MessageBox.Show("Please fill the boxes");
                }
            }
            else
            {
                MessageBox.Show("Please Log In");
            }
        }

        public MainViewModel(IWindowService windowService) 
        {
            _windowService = windowService;
            AuthContentButton = "Authorization";
            OpenWindowCommand = new RelayCommand(param => OnOpenWindow());
            AddPageCommand = new RelayCommand(param => Add());
            var dictionary = new ResourceDictionary();
            dictionary.Source = new Uri("Dictionaries/DarkTheme.xaml", UriKind.RelativeOrAbsolute);
            AuthButtonStyle = (Style)dictionary["authButton"];
  
        }

    }
}
