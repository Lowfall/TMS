using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;

namespace TMS.ViewModel
{
    public class PomodoroViewModel:ViewModelBase
    {
        public Pomodoro pomodoro;
        public PomodoroViewModel(Pomodoro pomodoro)
        {
            this.pomodoro = pomodoro;
        }

        public int PomodoroId
        {
            get { return pomodoro.PomodoroId; }
        }

        public string BreakTime
        {
            get { return pomodoro.BreakTime; }
            set { pomodoro.BreakTime = value;
                OnPropertyChanged("BreakTime");
            }
        }

        public string WorkTime
        {
            get { return pomodoro.WorkTime; }
            set
            {
                pomodoro.WorkTime = value;
                OnPropertyChanged("WorkTime");
            }
        }

        public int PageId
        {
            get { return pomodoro.PageId; }
        }
    }
}
