using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.ViewModel;

namespace TMS.Model
{
    public class Pomodoro
    {
        [Key]
        public int PomodoroId { get; set; }
        public string BreakTime { get; set; }
        public string WorkTime { get; set; }
        public int PageId { get; set; }

        public Pomodoro()
        {

        }

        public Pomodoro(string workTime, string breakTime)
        {
            WorkTime = workTime;
            BreakTime = breakTime;
            PageId = MainViewModel.PageId;
        }
    }
}
