using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using TMS.Commands;
using TMS.Model;
using TMS.UOW;

namespace TMS.ViewModel
{
    public class PomodoroPageViewModel: ViewModelBase
    {
        PomodoroViewModel Pomodoro { get; set; }

        public ICommand AddPomodoroCommand { get; set;}

        private bool State;
        private string workingTime;
        private string breakTime;
        private string runningTime;

        public string WorkingTime { 
            get { return workingTime;} 
            set { 
                workingTime = value;
                OnPropertyChanged("WorkingTime");
            }
        }
        public string BreakTime
        {
            get { return breakTime; }
            set
            {
                breakTime = value;
                OnPropertyChanged("BreakTime");
            }
        }

        public string RunningTime
        {
            get { return runningTime; }
            set { runningTime = value;
                OnPropertyChanged("RunningTime");
            }
        }

        private DateTime startCountdown;
        private TimeSpan timeToEnd;
        private TimeSpan startTimeSpan;
        private DateTime pauseTime;
        private DispatcherTimer timer;

        private void AddPomodoro()
        {
            if (WorkingTime != null && WorkingTime != "" && BreakTime != null && BreakTime != "")
            {
                if(State == true)
                {
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        foreach (var pomodoro in uow.Pomodoros.GetAll().ToList())
                        {
                            if (pomodoro.PageId == MainViewModel.PageId)
                            {
                                pomodoro.WorkTime = WorkingTime;
                                pomodoro.BreakTime = BreakTime;
                            }
                        }
                        uow.Save();
                    }
                }
                else
                {
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        var pomodoro = new Pomodoro(WorkingTime, BreakTime);
                        uow.Pomodoros.Add(pomodoro);
                        Pomodoro = new PomodoroViewModel(pomodoro);
                        uow.Save();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill boxes");
            }
        }

        private void StartTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(15);
            timer.Tick += delegate {
                var now = DateTime.Now;
                var elapsed = now.Subtract(startCountdown);
                timeToEnd = startTimeSpan.Subtract(elapsed);
            };
        }

        private void LaunchPomodoro()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                foreach (var pomodoro in uow.Pomodoros.GetAll().ToList())
                {
                    if (pomodoro.PageId == MainViewModel.PageId)
                    {
                        Pomodoro = new PomodoroViewModel(pomodoro);
                        BreakTime = Pomodoro.BreakTime;
                        WorkingTime = Pomodoro.WorkTime;
                        State = true;
                    }
                }
                uow.Save();
            }
        }
        public PomodoroPageViewModel()
        {
            LaunchPomodoro();
            AddPomodoroCommand = new RelayCommand(param => AddPomodoro());
        }
    }
}
