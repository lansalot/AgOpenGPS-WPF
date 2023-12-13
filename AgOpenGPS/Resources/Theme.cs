using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace AgOpenGPS.Resources
{

    public class Theme
    {
        //
        // Summary:
        //     Event triggered when the application's theme is changed.
        public static event ThemeChangedEvent? Changed;
        public static void Apply(ApplicationTheme themeType, WindowBackdropType backgroundEffect = WindowBackdropType.Mica, bool updateAccent = true, bool forceBackground = false)
        {
            if (updateAccent)
            {
              // Accent.Apply(Accent.GetColorizationColor(), themeType);
            }

            if (themeType != 0)
            {
                ResourceDictionaryManager resourceDictionaryManager = new ResourceDictionaryManager("AgOpenGPS;");
                string text = "Light";
                if (themeType == ApplicationTheme.Dark)
                {
                    text = "Dark";
                }

                if (resourceDictionaryManager.UpdateDictionary("customthemes", new Uri("Resources/CustomThemes/" + text + ".xaml", UriKind.Relative)))
                {
                    //AppearanceData.ApplicationTheme = themeType;
                    //Theme.Changed?.Invoke(themeType,Colors.Red);
                    //UpdateBackground(themeType, backgroundEffect, forceBackground);
                }
            }
        }

        //
        // Summary:
        //     Forces change to application background. Required if custom background effect
        //     was previously applied.
        private static void UpdateBackground(ApplicationTheme themeType, WindowBackdropType backgroundEffect = WindowBackdropType.None, bool forceBackground = false)
        {
            foreach (IntPtr modifiedBackgroundHandle in AppearanceData.ModifiedBackgroundHandles)
            {
                WindowBackdrop.ApplyBackdrop(modifiedBackgroundHandle, backgroundEffect);
            }

            if (!AppearanceData.HasHandle(Application.Current.MainWindow))
            {
                WindowBackdrop.ApplyBackdrop(Application.Current.MainWindow, backgroundEffect);
                AppearanceData.AddHandle(Application.Current.MainWindow);
            }
        }

    }
}
