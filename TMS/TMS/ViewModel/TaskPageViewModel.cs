using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TMS.Commands;
using TMS.Model;
using TMS.View.Pages;

namespace TMS.ViewModel
{
    public class TaskPageViewModel : ViewModelBase
    {
        private TaskPage TaskPage;
        public TaskPageViewModel(TaskPage taskPage)
        {
            TaskPage = taskPage;
        }

        public int PageId
        {
            get { return TaskPage.PageId; }
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
