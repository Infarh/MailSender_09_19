using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                //OnPropertyChanged(nameof(Title));
                //OnPropertyChanged("Title"); 
                OnPropertyChanged();
                OnPropertyChanged(nameof(TitleLength));
                //OnPropertyChanged("TitleLength");


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
