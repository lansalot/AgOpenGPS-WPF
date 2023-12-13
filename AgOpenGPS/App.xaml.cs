// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using AgOpenGPS.Services;
using AgOpenGPS.ViewModels.Pages;
using AgOpenGPS.ViewModels.Pages.AgOpenIO_Settings_Pages;
using AgOpenGPS.ViewModels.Pages.NTRIP_Pages;
using AgOpenGPS.ViewModels.Pages.Simulator_Pages;
using AgOpenGPS.ViewModels.Windows;
using AgOpenGPS.Views.Pages;
using AgOpenGPS.Views.Pages.AgOPenIOSetting_Pages;
using AgOpenGPS.Views.Pages.NTRIP_Pages;
using AgOpenGPS.Views.Pages.Simulator_Pages;
using AgOpenGPS.Views.Pages.Simulator_Pages.Simulator_Setting_Pages;
using AgOpenGPS.Views.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Threading;
using Wpf.Ui;
using WPFLocalizeExtension.Engine;

namespace AgOpenGPS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        // The.NET Generic Host provides dependency injection, configuration, logging, and other services.
        // https://docs.microsoft.com/dotnet/core/extensions/generic-host
        // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
        // https://docs.microsoft.com/dotnet/core/extensions/configuration
        // https://docs.microsoft.com/dotnet/core/extensions/logging
        private static readonly IHost _host = Host
            .CreateDefaultBuilder()
            .ConfigureAppConfiguration(c => { c.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)); })
            .ConfigureServices((context, services) =>
            {
                services.AddHostedService<ApplicationHostService>();

                #region Gerneral Services
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainWindowViewModel>();
                services.AddSingleton<INavigationService, NavigationService>();
                services.AddSingleton<ISnackbarService, SnackbarService>();
                services.AddSingleton<IContentDialogService, ContentDialogService>();
                services.AddSingleton<DashboardPage>();
                services.AddSingleton<DashboardViewModel>();
                services.AddSingleton<DataPage>();
                services.AddSingleton<DataViewModel>();
                services.AddSingleton<SettingsPage>();
                services.AddSingleton<SettingsViewModel>();
                services.AddSingleton<CommGPSView>();
                services.AddSingleton<CommGPSViewModel>();
                services.AddSingleton<EthernetConfigurationView>();
                services.AddSingleton<EthernetConfigurationViewModel>();
                services.AddSingleton<IThemeService, ThemeService>(); 
                #endregion

                #region AGOpenIO Settings Services

                services.AddSingleton<SaveSettingView>();
                services.AddSingleton<LoadSettingView>();
                services.AddSingleton<UDPMonitorView>();
                services.AddSingleton<SerialMonitorView>();
                services.AddSingleton<AgOpenIOSettingViewModel>();

                #endregion

                #region Simulator Services

                services.AddSingleton<SimulatorDashboardView>();
                services.AddSingleton<SimulatorDashboardViewModel>();

                services.AddSingleton<SimulatorSettingView>();
                services.AddSingleton<SimulatorGeneralSettingViewModel>();

                services.AddSingleton<SimulatorUtilitiesView>();
                services.AddSingleton<SimulatorUtilitiesViewModel>();

                //services.AddSingleton<SimulatorScreensView>();
                //services.AddSingleton<SimulatorScreensViewModel>();

                services.AddSingleton<SimulatorSteerView>();
                services.AddSingleton<SimulatorSteerViewModel>();


                #endregion

                #region NTRIP Services
                services.AddSingleton<ClientNTRIP_View>();
                services.AddSingleton<ClientNTRIPViewModel>();
                services.AddSingleton<RadioNTRIP_View>();
                services.AddSingleton<RadioNTRIPViewModel>();
                services.AddSingleton<SerialNTRIP_View>();
                services.AddSingleton<SerialNTRIPViewModel>();
                #endregion




            }).Build();

        /// <summary>
        /// Gets registered service.
        /// </summary>
        /// <typeparam name="T">Type of the service to get.</typeparam>
        /// <returns>Instance of the service or <see langword="null"/>.</returns>
        public static T GetService<T>()
            where T : class
        {
            return _host.Services.GetService(typeof(T)) as T;
        }

        /// <summary>
        /// Occurs when the application is loading.
        /// </summary>
        private void OnStartup(object sender, StartupEventArgs e)
        {
            LocalizeDictionary.Instance.Culture = CultureInfo.CurrentCulture;
            _host.Start();
        }

        /// <summary>
        /// Occurs when the application is closing.
        /// </summary>
        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync();

            _host.Dispose();
        }

        /// <summary>
        /// Occurs when an exception is thrown by an application but not handled.
        /// </summary>
        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // For more info see https://docs.microsoft.com/en-us/dotnet/api/system.windows.application.dispatcherunhandledexception?view=windowsdesktop-6.0
        }
    }
}
