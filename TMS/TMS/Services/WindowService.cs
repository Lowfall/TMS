using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TMS.View;

namespace TMS.Services
{
    public class WindowService : IWindowService
    {
        public void OpenWindow()
        {
            var window = new AuthorizationWindow();
            window.ShowDialog();
        }

        public void CloseWindow()
        {
            var window = Application.Current.Windows.OfType<AuthorizationWindow>().SingleOrDefault(x => x.IsActive);

            if(window != null)
            {
                window.Close();
            }
        }

        public void CloseAdmin()
        {
            var window = Application.Current.Windows.OfType<AdminWindow>().SingleOrDefault(x => x.IsActive);

            if (window != null)
            {
                window.Close();
            }
        }

        public void HideMainWindow()
        {
            var window = Application.Current.Windows.OfType<MainWindow>().SingleOrDefault(x => x.IsActive);

            if (window != null)
            {
                window.Visibility = Visibility.Hidden;
            }
        }

        public void ShowMainWindow()
        {
            var window = Application.Current.Windows.OfType<MainWindow>().SingleOrDefault(x => x.IsActive);

            if (window != null)
            {
                window.Visibility = Visibility.Visible;
            }
        }

    }
}
