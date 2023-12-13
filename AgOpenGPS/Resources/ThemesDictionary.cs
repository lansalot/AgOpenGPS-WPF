using System.Windows.Markup;
using Wpf.Ui.Appearance;

namespace AgOpenGPS.Resources
{
    [Localizability(LocalizationCategory.Ignore)]
    [Ambient]
    [UsableDuringInitialization(true)]
    public class ThemesDictionary : ResourceDictionary
    {
        //
        // Summary:
        //     Sets the default application theme.
        public ApplicationTheme Theme
        {
            set
            {
                base.Source = new Uri("Resources/CustomThemes/" + value switch
                {
                    ApplicationTheme.Dark => "Dark",
                    ApplicationTheme.HighContrast => "HighContrast",
                    _ => "Light",
                } + ".xaml", UriKind.Relative);
            }
        }
    }
}
