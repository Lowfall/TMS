using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TMS.Model;

namespace TMS.ViewModel
{
   public class DayPlanTaskViewModel :ViewModelBase
    {
        private DayPlanTask dayPlanTask;
        private SolidColorBrush color;

        public SolidColorBrush Color
        {
            get { return color; }
            set {
               color = value;
                OnPropertyChanged("Color");
            }
        }

        public DayPlanTaskViewModel(DayPlanTask dayPlanTask)
        {
            this.dayPlanTask = dayPlanTask;
            if (dayPlanTask.State == "Low")
            {
                color = Brushes.Red;
            }
            if (dayPlanTask.State == "Mid")
            {
                color = Brushes.Orange;
            }
            if (dayPlanTask.State == "High")
            {
                color = Brushes.Green;
            }
        }

        public int Id {
            get { return dayPlanTask.TaskId; }
            set { dayPlanTask.TaskId = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
            {
            get { return dayPlanTask.Name; }
            set
            {
                dayPlanTask.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string FromTime
        {
            get { return dayPlanTask.FromTime; }
            set
            {
                dayPlanTask.FromTime = value;
                OnPropertyChanged("FromTime");
            }
        }

        public string ToTime
        {
            get { return dayPlanTask.ToTime; }
            set
            {
                dayPlanTask.ToTime = value;
                OnPropertyChanged("ToTime");
            }
        }

        public string State
        {
            get { return dayPlanTask.State; }
            set
            {
                dayPlanTask.State = value;
                OnPropertyChanged("State");
            }
        }


    }
}
