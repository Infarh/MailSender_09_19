﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Navigation;
using MailSender.lib.Services.Interfaces;

namespace MailSender
{
    public partial class App
    {
        private List<IPlugin> _Pligins;

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _Pligins = await Task.Run(GetPlugins).ConfigureAwait(false);
            if (_Pligins.Count == 0) return;

            await InitializePluginsAsync(_Pligins).ConfigureAwait(false);
            await StartPluginsAsync(_Pligins).ConfigureAwait(false);
        }

        private List<IPlugin> GetPlugins()
        {
            const string plugins_dir = "Plugins";
            var directory = new DirectoryInfo(plugins_dir);

            var result = new List<IPlugin>();
            if (!directory.Exists) return result;

            foreach (var dll in directory.EnumerateFiles("*.dll"))
            {
                var plugin_dll = Assembly.LoadFile(dll.FullName);

                foreach (var plugin_type in plugin_dll.GetTypes().Where(t => t.GetInterfaces().Any(i => i == typeof(IPlugin))))
                {
                    var plugin = Activator.CreateInstance(plugin_type) as IPlugin;
                    if (plugin is null) continue;
                    result.Add(plugin);
                }
            }

            return result;
        }

        private static async Task InitializePluginsAsync(IEnumerable<IPlugin> Plugins)
        {
            foreach (var plugin in Plugins)
                try
                {
                    await plugin.InitializeAsync();
                }
                catch (Exception e)
                {
                    Trace.TraceError("Ошибка при инициализации плагина {0}: {1}", plugin.GetType(), e);
                }

        }

        private static async Task StartPluginsAsync(IEnumerable<IPlugin> Plugins)
        {
            foreach (var plugin in Plugins)
                try
                {
                    await plugin.StartAsync();
                }
                catch (Exception e)
                {
                    Trace.TraceError("Ошибка при запуске плагина {0}: {1}", plugin.GetType(), e);
                }
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            if (_Pligins.Count == 0) return;
            await StopPluginsAsync(_Pligins).ConfigureAwait(false);
        }

        private static async Task StopPluginsAsync(IEnumerable<IPlugin> Plugins)
        {
            foreach (var plugin in Plugins)
                try
                {
                    await plugin.StopAsync();
                }
                catch (Exception e)
                {
                    Trace.TraceError("Ошибка при остановке плагина {0}: {1}", plugin.GetType(), e);
                }
        }
    }
}