using AgOpenGPS.ViewModels.Pages.AgOpenIO_Settings_Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Controls;

namespace AgOpenGPS.Views.Pages.AgOPenIOSetting_Pages
{
    /// <summary>
    /// Interaction logic for SerialMonitorView.xaml
    /// </summary>
    public partial class SerialMonitorView : INavigableView<AgOpenIOSettingViewModel>
    {
        public AgOpenIOSettingViewModel ViewModel { get; }

        public SerialMonitorView(AgOpenIOSettingViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}

