using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.ViewModel;

namespace TMS.Model
{
    public class Meeting
    {
        [Key]
        public int MeetingId { get; set; }
        public string PersonName { get; set; }
        public string Location { get; set; }
        public string DateTime { get; set; }
        public DateTime NotificationDateTime { get; set; }
        public string Note { get; set; }
        public int PageId { get; set; }

        public Meeting()
        {

        }

        public Meeting(string personName, string location, string timeOfMeeting, string note)
        {
            PersonName = personName;
            Location = location;
            DateTime = timeOfMeeting;
            Note = note;
            NotificationDateTime = Convert.ToDateTime(timeOfMeeting);
            PageId = MainViewModel.PageId;
        }
    }
}
