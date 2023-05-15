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
using System.Windows.Media.Imaging;
using System.Security.Policy;
using System.Windows.Controls;
using TMS.View.Pages;
using TMS.View;
using  MessageBoxForm = System.Windows.Forms;

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
        public ICommand SearchCommand { get; set; }
        public ICommand ChangeCommand { get; set; }
        public ICommand ExitCommand { get; set; }


        
        public static int PageId;
        private TaskPageViewModel selectedPage;
        private Page changingPage;
        private Style authButtonStyle;
        private string authContentButton;
        private string pageName;
        private string pageType;
        private string searchString;

        public TaskPageViewModel SelectedPage
        {
            get { return selectedPage; }
            set { selectedPage = value;
                if (selectedPage !=null)
                {
                    PageId = selectedPage.PageId;
                }
                OnPropertyChanged("SelectedPage");
            }
        }
        public Page ChangingPage
        {
            get { return changingPage; }
            set
            {
                changingPage = value;
                OnPropertyChanged("ChangingPage");
            }
        }
        public string SearchString
        {
            get { return searchString; }
            set { searchString = value;
                OnPropertyChanged("SearchString");

            }
        }

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
            get { return authButtonStyle;}
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
            if (AdminActivated == true)
            {
                new WindowService().HideMainWindow();
                new AdminWindow().ShowDialog();
            }
            else
            {
                if (AccountActivated == true)
                {
                    AuthContentButton = ActualAccount.Login.ToString();
                    ShowPages();
                    
                }
                else
                {
                    _windowService.OpenWindow();
                        OnOpenWindow();
                }
            }
        }

        private void ExitAccount()
        {
            if (AccountActivated == true)
            { 
                 MessageBoxForm.DialogResult dialogResult = MessageBoxForm.MessageBox.Show("Do you want to leave account", "Exit", MessageBoxForm.MessageBoxButtons.YesNo);
                if (dialogResult == MessageBoxForm.DialogResult.Yes)
                {
                    ViewModelBase.ActualAccount = null;
                    TaskPagesList = null;
                    ViewModelBase.AccountActivated = false;
                    AuthContentButton = "Authorize";
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("You dont authorize");
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

        public void SearchPage() {
            if (AccountActivated == true)
            {
                if (SearchString != null && SearchString != "")
                {
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        List<TaskPage> allPages = new List<TaskPage>();
                        var pages = uow.Tasks.GetAll().ToList();
                        if (pages != null)
                        {
                            foreach (var page in pages)
                            {
                                if (page.Name.Contains(SearchString))
                                {
                                    allPages.Add(page);
                                }

                            }
                            TaskPagesList = new ObservableCollection<TaskPageViewModel>(allPages.Select(b => new TaskPageViewModel(b)));
                            uow.Save();
                        }
                    }
                }
                else
                {
                    ShowPages();
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

        private void ChangePage()
        {
            if (SelectedPage != null) {
                if (SelectedPage.Type == "PomodoroPage")
                {
                    ChangingPage = new PomodoroPage();
                }
                if (SelectedPage.Type == "PlansForFuturePage")
                {
                    ChangingPage = new PlansForFuturePage();
                }
                if (SelectedPage.Type == "MeetingsPage")
                {
                    ChangingPage = new MeetingsPage();
                }
                if (SelectedPage.Type == "DayPlanPage")
                {
                    ChangingPage = new DayPlanPage();
                }
            }
            else
            {
                ChangingPage = null;
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
            SearchCommand = new RelayCommand(param => SearchPage());
            ChangeCommand = new RelayCommand(param => ChangePage());
            ExitCommand = new RelayCommand(param => ExitAccount());
        }

    }
}
