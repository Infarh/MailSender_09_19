using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MailSender.lib.Data.EF;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Services.EF;
using MailSender.lib.Services.InMemory;
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

            services
               .TryRegister<IRecipientsDataProvider, Linq2SQLRecipientsDataProvider>()
               .TryRegister(() => new MailSenderDBDataContext())
               .TryRegister<MemoryDataContext>()
               .TryRegister<DataContextProvider>();
            //.TryRegister(() => new MailSenderDB());

            //services
            //   .TryRegister<IRecipientsDataProvider, InMemoryRecipientsDataProvider>()
            //   .TryRegister<ISendersDataProvider, InMemorySendersDataProvider>()
            //   .TryRegister<IServersDataProvider, InMemoryServersDataProvider>();

        }

        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
    }
}