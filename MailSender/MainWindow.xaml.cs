using System;
using MailSender.Controls;

namespace MailSender
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        private void TabItemsSwitcher_OnLeftButtonClick(object Sender, EventArgs E)
        {
            if (!(Sender is TabItemsSwitcher switcher)) return;

            if (MainTabCantrol.SelectedIndex == 0) return;

            MainTabCantrol.SelectedIndex--;
            if (MainTabCantrol.SelectedIndex == 0)
            {
                switcher.LeftButtonVisible = false;
            }
        }

        private void TabItemsSwitcher_OnRightButtonClick(object Sender, EventArgs E)
        {
            if (!(Sender is TabItemsSwitcher switcher)) return;

            var tab_count = MainTabCantrol.Items.Count;

            if(MainTabCantrol.SelectedIndex == tab_count - 1) return;

            MainTabCantrol.SelectedIndex++;

            if (MainTabCantrol.SelectedIndex == MainTabCantrol.Items.Count - 1)
            {
                switcher.RightButtonVisible = false;
            }
        }
    }
}
