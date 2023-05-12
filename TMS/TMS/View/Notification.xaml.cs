using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TMS.Model;
using TMS.ViewModel;

namespace TMS.View
{
    /// <summary>
    /// Interaction logic for Notification.xaml
    /// </summary>
    public partial class Notification : Window
    {
        private void Timer_Click(object sender, EventArgs e)
        {
            this.Close();          
        }
        public Notification(Meeting meeting)
        {
            DataContext = new NotificationViewModel(meeting);
            InitializeComponent();
        }
    }
}
