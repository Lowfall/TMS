using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;

namespace TMS.ViewModel
{
   public class MeetingViewModel : ViewModelBase
    {
        private Meeting meeting;

        public MeetingViewModel(Meeting meeting)
        {
            this.meeting = meeting;
        }   


        public int MeetingId
        {
            get { return meeting.MeetingId; }
        }

        public DateTime NotificationDateTime
        {
            get { return meeting.NotificationDateTime; }
            set { meeting.NotificationDateTime = value;
                OnPropertyChanged("NotificationDateTime");
            }
        }
        public string PersonName {
            get { return meeting.PersonName; }
            set { meeting.PersonName = value;
                OnPropertyChanged("PersonName");
            }
        }
        public string Location
        {
            get { return meeting.Location; }
            set
            {
                meeting.Location = value;
                OnPropertyChanged("Location");
            }
        }

        public string TimeOfMeeting
        {
            get { return meeting.DateTime; }
            set
            {
                meeting.DateTime = value;
                OnPropertyChanged("TimeOfMeeting");
            }
        }

        public string Note
        {
            get { return meeting.Note; }
            set
            {
                meeting.Note = value;
                OnPropertyChanged("Note");
            }
        }
    }
}
