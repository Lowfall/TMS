using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TMS.Commands;
using TMS.Model;
using TMS.UOW;
using TMS.View;

namespace TMS.ViewModel
{
    public class MeetingPageViewModel:ViewModelBase
    {

        public ICommand showTodaysMeetingsCommand { get; set; }
        public ICommand showMeetingsCommand { get; set; }
        public ICommand addMeetingCommand { get; set; }
        public ICommand deleteMeetingCommand { get; set; }
        private ObservableCollection<MeetingViewModel> meetingsList;

        public ObservableCollection<MeetingViewModel> MeetingsList
        {
            get { return meetingsList; }
            set { meetingsList = value;
                OnPropertyChanged("MeetingsList");
            }
        }

        private MeetingViewModel meeting;
        private string name;
        private string location;
        private string dateTime;
        private string note;
        private string currentTime;

        public string CurrentTime
        {
            get { return currentTime; }
            set
            {
                currentTime = value;
                OnPropertyChanged("CurrentTime");
            }
        }

        public MeetingViewModel SelectedMeeting
        {
            get { return meeting; }
            set
            {
                meeting = value;
                OnPropertyChanged("SelectedMeeting");
            }
        }

        public string Name {
            get { return name; }
            set { name = value; 
                OnPropertyChanged("Name"); 
            }
        }

        public string Location
        {
            get { return location; }
            set
            {
                location = value;
                OnPropertyChanged("Location");
            }
        }

        public string DateandTime
        {
            get { return dateTime; }
            set { dateTime = value;
                OnPropertyChanged("DateandTime");
            }
        }

        public string Note
        {
            get { return note; }
            set
            {
                note = value;
                OnPropertyChanged("Note");
            }
        }

        private void DeleteMeet()
        {
            if (SelectedMeeting != null)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.Meetings.Delete(SelectedMeeting.MeetingId);
                    uow.Save();
                    ShowMeets();

                }
            }
            else
            {
                MessageBox.Show("Choose card of meeting first");
            }
        }

        private void AddElem()
        {
            if (AccountActivated == true)
            {
                if (Name != null && Name != "" && DateandTime != null && DateandTime != "" && Location != null && Location != "" && Note != null && Note != "")
                {
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        uow.Meetings.Add(new Meeting(Name,Location,DateandTime,Note));
                        uow.Save();
                        ShowMeets();
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all boxes with info");
                }
            }
        }

        private void ShowMeets()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                List<Meeting> allMeets = new List<Meeting>();
                var meets = uow.Meetings.GetAll().ToList();
                if (meets != null)
                {
                    foreach (var meet in meets)
                    {
                        if (meet.PageId == MainViewModel.PageId)
                        {
                            allMeets.Add(meet);
                        }

                    }
                    MeetingsList = new ObservableCollection<MeetingViewModel>(allMeets.Select(b => new MeetingViewModel(b)));
                    uow.Save();
                }
            }
        }

        private void ShowTodaysMeets()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                List<Meeting> allMeets = new List<Meeting>();
                var meets = uow.Meetings.GetAll().ToList();
                if (meets != null)
                {
                    foreach (var meet in meets)
                    {
                        if (meet.PageId == MainViewModel.PageId && meet.NotificationDateTime.Date == DateTime.Now.Date) 
                        {
                            allMeets.Add(meet);
                        }

                    }
                    MeetingsList = new ObservableCollection<MeetingViewModel>(allMeets.Select(b => new MeetingViewModel(b)));
                    uow.Save();
                }
            }
        }


        private void Timer_Click(object sender, EventArgs e)
        {
            DateTime d;
            d = DateTime.Now;
            
            CurrentTime = string.Format("{0}:{1}", d.Hour.ToString("00"), d.Minute.ToString("00"));
        }
        private void NotificationTimer_Click(object sender, EventArgs e)
        {
            DateTime d;
            d = DateTime.Now;
            using (UnitOfWork uow = new UnitOfWork())
            {
                foreach(var item in uow.Meetings.GetAll().ToList())
                {
                    if(item.NotificationDateTime.Date == DateTime.Now.Date && item.NotificationDateTime.TimeOfDay > DateTime.Now.TimeOfDay && item.PageId ) //добавить проверку
                    {
                       var notification = new Notification(item);
                        notification.Show();
                        Thread.Sleep(9000);
                        notification.Close();
                    }
                }
            }
        }


        public MeetingPageViewModel()
        {
            ShowMeets();
            addMeetingCommand = new RelayCommand(param => AddElem());
            deleteMeetingCommand = new RelayCommand(param => DeleteMeet());
            showTodaysMeetingsCommand = new RelayCommand(param => ShowTodaysMeets());
            showMeetingsCommand = new RelayCommand(param => ShowMeets());
            System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
            System.Windows.Threading.DispatcherTimer NotificationTimer = new System.Windows.Threading.DispatcherTimer();
            NotificationTimer.Tick += new EventHandler(NotificationTimer_Click);
            NotificationTimer.Interval = new TimeSpan(0,0,20);
            NotificationTimer.Start();
        }
    }
}
