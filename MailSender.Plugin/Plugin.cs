using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MailSender.lib.Services.Interfaces;

namespace MailSender.Plugin
{
    public class Plugin : IPlugin
    {
        public async Task InitializeAsync()
        {
            await Task.Run(() => MessageBox.Show("Плагин проиизиализирован"));
        }

        public async Task StartAsync()
        {
            await Task.Run(() => MessageBox.Show("Плагин запущен"));
        }

        public async Task StopAsync()
        {
            await Task.Run(() => MessageBox.Show("Плагин остановлен"));
        }
    }
}
