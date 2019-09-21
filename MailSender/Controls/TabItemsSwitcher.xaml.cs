using System;
using System.Windows;
using System.Windows.Controls;

namespace MailSender.Controls
{
    public partial class TabItemsSwitcher
    {
        public event EventHandler LeftButtonClick;
        public event EventHandler RightButtonClick;

        public bool LeftButtonVisible
        {
            get => LeftButton.Visibility == Visibility;
            set => LeftButton.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        } 

        public bool RightButtonVisible
        {
            get => RightButton.Visibility == Visibility;
            set => RightButton.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }

        public TabItemsSwitcher() => InitializeComponent();

        private void ButtonBase_OnClick(object Sender, RoutedEventArgs E)
        {
            if(!(E.Source is Button button)) return;

            switch (button.Name)
            {
                case "LeftButton":
                    LeftButtonClick?.Invoke(this, EventArgs.Empty);
                    break; 
                case "RightButton":
                    RightButtonClick?.Invoke(this, EventArgs.Empty);
                    break;
            }
        }
    }
}
