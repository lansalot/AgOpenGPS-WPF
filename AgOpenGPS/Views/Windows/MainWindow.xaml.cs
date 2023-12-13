// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using AgOpenGPS.ViewModels.Windows;
using System.Diagnostics;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace AgOpenGPS.Views.Windows
{
    public partial class MainWindow
    {
        public MainWindowViewModel ViewModel { get; }

        public MainWindow(
            MainWindowViewModel viewModel,
            INavigationService navigationService,
            IServiceProvider serviceProvider,
            ISnackbarService snackbarService,
            IContentDialogService contentDialogService
        )
        {
          //  Wpf.Ui.Appearance.Watcher.Watch(this);

            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();

            navigationService.SetNavigationControl(NavigationView);
            snackbarService.SetSnackbarPresenter(SnackbarPresenter);
            contentDialogService.SetContentPresenter(RootContentDialog);

            NavigationView.SetServiceProvider(serviceProvider);
           
        }

        private void NavigationView_Navigating(NavigationView sender, NavigatingCancelEventArgs args)
        {
            //var item=args.;
            if (args.Page is Exception)
            {

                //open device manager
                try
                {

                    var processStartInfo = new ProcessStartInfo
                    {
                        FileName = "mmc.exe",
                        Arguments = "devmgmt.msc",
                        UseShellExecute=true
                    };

                    var process = new Process
                    {
                        StartInfo = processStartInfo
                    };

                    process.Start();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show($"Error: {ex.Message}");
                }
                args.Cancel = true;
            }
        }
    }
}
