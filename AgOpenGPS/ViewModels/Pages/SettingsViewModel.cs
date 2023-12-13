// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using AgOpenGPS.Resources;
using Wpf.Ui;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;
using WPFLocalizeExtension.Engine;

namespace AgOpenGPS.ViewModels.Pages
{
    public partial class SettingsViewModel : BaseViewModel
    {
        private bool _isInitialized = false;

        public SettingsViewModel(IThemeService themeService)
        {
            var culture = LocalizeDictionary.Instance.Culture;
            if (culture.EnglishName.Contains("English"))
                LangSelectedValue = "English";
            PropertyChanged += SettingsViewModel_PropertyChanged;
            Langs = new List<string>()
          {
            "English",
            "German"
          };
            PropertyChanged += SettingsViewModel_PropertyChanged;
            ThemeService = themeService;
        }

        private void SettingsViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName==nameof(LangSelectedValue))
            {
                setLang(LangSelectedValue);
            }
        }

        [ObservableProperty]
        List<string> langs;


        [ObservableProperty]
        private string _langSelectedValue ;

        private void setLang(string selected)
        {
            if (selected == "English")
                LocalisedWords.Instance.setCulture("en-US");
            else if (selected == "German")
                LocalisedWords.Instance.setCulture("de-CH");
        }//

        [ObservableProperty]
        private string _appVersion = String.Empty;

        [ObservableProperty]
        private Wpf.Ui.Appearance.ApplicationTheme _currentTheme = Wpf.Ui.Appearance.ApplicationTheme.Unknown;

        public IThemeService ThemeService { get; }

        public override void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        public override void OnNavigatedFrom() { }

        private void InitializeViewModel()
        {
          
            CurrentTheme = Wpf.Ui.Appearance.ApplicationTheme.Light;
            AppVersion = $"AgOpenGPS - {GetAssemblyVersion()}";

            _isInitialized = true;
         
        }

        private string GetAssemblyVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString()
                ?? String.Empty;
        }

        [RelayCommand]
        private void OnChangeTheme(string parameter)
        {
            switch (parameter)
            {
                case "theme_light":
                    if (CurrentTheme == Wpf.Ui.Appearance.ApplicationTheme.Light)
                        break;

                    CurrentTheme = Wpf.Ui.Appearance.ApplicationTheme.Light;
                    ThemeService.SetTheme(CurrentTheme);
                    Theme.Apply(Wpf.Ui.Appearance.ApplicationTheme.Light);

                    break;

                default:
                    if (CurrentTheme == Wpf.Ui.Appearance.ApplicationTheme.Dark)
                        break;

                    CurrentTheme = Wpf.Ui.Appearance.ApplicationTheme.Dark;
                    ThemeService.SetTheme(CurrentTheme);
                    Theme.Apply(Wpf.Ui.Appearance.ApplicationTheme.Dark);

                    break;
            }

           
        }
    }
}
