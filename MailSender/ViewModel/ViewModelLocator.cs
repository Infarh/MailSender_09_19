using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Services.Interfaces;
using MailSender.lib.Services.Linq2SQL;

namespace MailSender.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            var services = SimpleIoc.Default;
            ServiceLocator.SetLocatorProvider(() => services);

            services.Register<MainWindowViewModel>();

            services.Register<IRecipientsDataProvider, Linq2SQLRecipientsDataProvider>();
            if (!services.IsRegistered<MailSenderDBDataContext>())
                services.Register(() => new MailSenderDBDataContext());

        }

        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
    }
}