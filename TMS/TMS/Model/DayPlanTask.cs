using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TMS.ViewModel;

namespace TMS.Model
{
    public class DayPlanTask
    {
        [Key]
        public int TaskId { get; set; }
        public string Name { get; set; }   
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string State { get; set; }
        public int PageId { get; set; }

        public DayPlanTask()
        {

        }
        public DayPlanTask(string name, string fromTime, string toTime, string state)
        {
            Name = name;
            FromTime = fromTime;
            ToTime = toTime;
            State = state;
            PageId = MainViewModel.PageId;
        }
    }
}
