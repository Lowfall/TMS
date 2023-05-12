using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.ViewModel;

namespace TMS.ViewModel
{
    public class NotificationViewModel : ViewModelBase
    {
        public Meeting meeting;

        public string Name { 
            get { 
                return meeting.PersonName; 
            } 
        }

        public DateTime DateAndTime
        {
            get { return   meeting.NotificationDateTime; }
        }
        public NotificationViewModel(Meeting meeting)
        {
            this.meeting = meeting;
        }
    }
}
