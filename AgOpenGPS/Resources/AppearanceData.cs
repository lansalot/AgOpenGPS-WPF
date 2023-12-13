using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using Wpf.Ui.Appearance;

namespace AgOpenGPS.Resources
{
    public static class AppearanceData
    {
        //
        // Summary:
        //     Collection of handles that have a background effect applied.
        public static List<IntPtr> ModifiedBackgroundHandles = new List<IntPtr>();

        //
        // Summary:
        //     Namespace for the XAML dictionaries.
        public const string LibraryNamespace = "ui;";

        //
        // Summary:
        //     Main dictionary for WPF UI controls.
        public const string LibraryMainDictionary = "Wpf.Ui";

        //
        // Summary:
        //     Default System.Uri for the application theme dictionaries.
        public const string LibraryThemeDictionariesUri = "pack://application:,,,/Wpf.Ui;component/Styles/Theme/";

        //
        // Summary:
        //     Default System.Uri for the application theme dictionaries.
        public const string LibraryDictionariesUri = "pack://application:,,,/Wpf.Ui;component/Styles/";

        //
        // Summary:
        //     Current system theme.
        public static SystemTheme SystemTheme = SystemTheme.Unknown;

        //
        // Summary:
        //     Current application theme.
        public static ApplicationTheme ApplicationTheme = ApplicationTheme.Unknown;

        //
        // Summary:
        //     Adds given window to list of modified handles.
        public static void AddHandle(Window window)
        {
            AddHandle(new WindowInteropHelper(window).Handle);
        }

        //
        // Summary:
        //     Adds given handle to list of modified handles.
        public static void AddHandle(IntPtr hWnd)
        {
            if (!ModifiedBackgroundHandles.Contains(hWnd))
            {
                ModifiedBackgroundHandles.Add(hWnd);
            }
        }

        //
        // Summary:
        //     Removes given window from list of modified handles.
        public static void RemoveHandle(Window window)
        {
            RemoveHandle(new WindowInteropHelper(window).Handle);
        }

        //
        // Summary:
        //     Removes given handle from list of modified handles.
        public static void RemoveHandle(IntPtr hWnd)
        {
            if (!ModifiedBackgroundHandles.Contains(hWnd))
            {
                ModifiedBackgroundHandles.Remove(hWnd);
            }
        }

        //
        // Summary:
        //     Returns a value indicating whether the given window had a modified background.
        public static bool HasHandle(Window window)
        {
            return HasHandle(new WindowInteropHelper(window).Handle);
        }

        //
        // Summary:
        //     Returns a value indicating whether the given handle had a modified background.
        public static bool HasHandle(IntPtr hWnd)
        {
            return ModifiedBackgroundHandles.Contains(hWnd);
        }
    }
}
