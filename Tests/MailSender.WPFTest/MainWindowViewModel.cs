using MailSender.lib.MVVM;

namespace MailSender.WPFTest
{
    class MainWindowViewModel : ViewModel
    {
        private string _Title = "Заголовок окна";

        public string Title
        {
            get => _Title;
            set
            {
                if (_Title == value) return;
                _Title = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TitleLength));
            }
        }

        public int TitleLength => Title?.Length ?? 0;

        private int _OffsetX = 10;

        public int OffsetX
        {
            get => _OffsetX;
            set => Set(ref _OffsetX, value);
        }

        private int _OffsetY = 10;

        public int OffsetY
        {
            get => _OffsetY;
            set => Set(ref _OffsetY, value);
        }

        #region Angle : double - Угол поворота

        /// <summary>Угол поворота</summary>
        private double _Angle;

        /// <summary>Угол поворота</summary>
        public double Angle
        {
            get => _Angle;
            set => Set(ref _Angle, value);
        }

        #endregion
    }
}
