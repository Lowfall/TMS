using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.UOW;
using TMS.ViewModel;

namespace TMS.Model
{
    public class TaskPage
    {
        [Key]
        public int PageId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int ClientId { get; set; }
        public TaskPage()
        {

        }
        public TaskPage(string name , string type)
        {
            Name = name; 
            Type = type;
            ClientId = ViewModelBase.ActualAccount.ClientId;
        }
    }
}
