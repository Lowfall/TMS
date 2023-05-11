using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TMS.Commands;
using TMS.Model;
using TMS.UOW;

namespace TMS.ViewModel
{
    public class DayPlanTaskPageViewModel : ViewModelBase
    {
        private ObservableCollection<DayPlanTaskViewModel> dayPlanTasks;
        public ICommand AddDayPlanTaskCommand { get; set; }
        public ICommand DeleteDayPlanTaskCommand { get; set; }
        public ICommand SetStateLowCommand { get; set; }
        public ICommand SetStateMidCommand { get; set; }
        public ICommand SetStateHighCommand { get; set; }

        private string name;
        private string fromTime;
        private string toTime;
        private string state;
        private string currentTime;
        private DayPlanTaskViewModel selectedTask;

        public DayPlanTaskViewModel SelectedTask
        {
            get { return selectedTask; }
            set { selectedTask = value;
                OnPropertyChanged("SelectedTask");
            }   
        }
        public string CurrentTime
        {
            get { return currentTime; }
            set { currentTime = value;
                OnPropertyChanged("CurrentTime");
            }    
        }

        public string Name
        {
            get { return name; }
            set
            {
               name = value;
                OnPropertyChanged("Name");
            }
        }

        public string FromTime
        {
            get { return fromTime; }
            set
            {
                fromTime = value;
                OnPropertyChanged("FromTime");
            }
        }

        public string ToTime
        {
            get { return toTime; }
            set
            {
                toTime = value;
                OnPropertyChanged("ToTime");
            }
        }

        public string State
        {
            get { return state; }
            set
            {
               state = value;
                OnPropertyChanged("State");
            }
        }

        public ObservableCollection<DayPlanTaskViewModel> DayPlanTasksList
        {
            get { return dayPlanTasks; }
            set { dayPlanTasks = value;
                OnPropertyChanged("DayPlanTasksList");
            }
        }

        private void AddDayTask()
        {
            if (AccountActivated == true)
            {
                if (Name != null && Name !="" && FromTime!=null && FromTime !="" && ToTime!= null && ToTime !="" && State!=null && State !="")
                {
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        uow.DayPlanTasks.Add(new DayPlanTask(Name, FromTime, ToTime, State));
                        uow.Save();
                        ShowDayTasks();
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all boxes with info");
                }
            }
        }

        private void ShowDayTasks()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                List<DayPlanTask> allTasks = new List<DayPlanTask>();
                var tasks = uow.DayPlanTasks.GetAll().ToList();
                if (tasks != null)
                {
                    foreach (var task in tasks)
                    {
                        if (task.PageId == MainViewModel.PageId)
                        {
                            allTasks.Add(task);
                        }

                    }
                    DayPlanTasksList = new ObservableCollection<DayPlanTaskViewModel>(allTasks.Select(b => new DayPlanTaskViewModel(b)));
                    uow.Save();
                }
            }
        }

        private void DeleteDayTasks()
        {
            if (SelectedTask != null)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.DayPlanTasks.Delete(SelectedTask.Id);
                    uow.Save();
                    ShowDayTasks();
                }
            }
        }

        private void Timer_Click(object sender, EventArgs e)
        {
            DateTime d;
            d = DateTime.Now;
            CurrentTime = string.Format("{0}:{1}", d.Hour.ToString("00"), d.Minute.ToString("00"));
        }

        public DayPlanTaskPageViewModel()   
        {
            ShowDayTasks();
            AddDayPlanTaskCommand = new RelayCommand(param => AddDayTask());
            SetStateLowCommand = new RelayCommand(param => State = "Low");
            SetStateMidCommand = new RelayCommand(param => State = "Mid");
            SetStateHighCommand = new RelayCommand(param => State = "High");
            DeleteDayPlanTaskCommand = new RelayCommand(param => DeleteDayTasks());
            System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }
    }
}
