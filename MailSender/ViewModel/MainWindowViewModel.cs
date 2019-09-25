using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.MVVM;
using MailSender.lib.Services;
using MailSender.lib.Services.Interfaces;
using MailSender.lib.Services.Linq2SQL;

namespace MailSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IRecipientsDataProvider _RecipientsProvider;

        private string _WindowTitle = "Рассыльщик почты v0.1";

        public string WindowTitle
        {
            get => _WindowTitle;
            set => Set(ref _WindowTitle, value);
        }

        private ObservableCollection<Recipient> _Recipients = new ObservableCollection<Recipient>();

        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            set => Set(ref _Recipients, value);
        }

        #region SelectedRecipient : Recipient - Выбранный получатель

        /// <summary>Выбранный получатель</summary>
        private Recipient _SelectedRecipient;

        /// <summary>Выбранный получатель</summary>
        public Recipient SelectedRecipient
        {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);
        }

        #endregion

        public ICommand RefreshDataCommand { get; }

        public ICommand SaveChangesCommand { get; }

        public MainWindowViewModel(IRecipientsDataProvider RecipientsProvider)
        {
            _RecipientsProvider = RecipientsProvider;

            RefreshDataCommand = new RelayCommand(OnRefreshDataCommandExecuted, CanRefreshDataCommandExecute);
            SaveChangesCommand = new RelayCommand(OnSaveChangesCommandExecuted);

            //RefreshData();
        }

        private void OnSaveChangesCommandExecuted()
        {
            _RecipientsProvider.SaveChanges();
        }

        private bool CanRefreshDataCommandExecute() => true;

        private void OnRefreshDataCommandExecuted()
        {
            RefreshData();
        }

        private void RefreshData()
        {
            var recipients = new ObservableCollection<Recipient>();
            foreach (var recipient in _RecipientsProvider.GetAll())
                recipients.Add(recipient);
            Recipients = null;
            Recipients = recipients;
        }
    }
}
