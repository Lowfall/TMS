using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;

namespace TMS.ViewModel
{
    public class TaskPageViewModel : ViewModelBase
    {
        private TaskPage TaskPage;

        public TaskPageViewModel(TaskPage taskPage)
        {
            TaskPage = taskPage;
        }

        public string Name
        {
            get { return TaskPage.Name; }
            set { TaskPage.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Type { 
        get { return TaskPage.Type; }
            set { TaskPage.Type = value;
                OnPropertyChanged("Type");
            }
        }
    }
}
