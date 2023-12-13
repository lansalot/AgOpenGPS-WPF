using AgOpenGPS.ViewModels.Pages;
using AgOpenGPS.ViewModels.Pages.Simulator_Pages;
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

namespace AgOpenGPS.Views.Pages.Simulator_Pages
{
    /// <summary>
    /// Interaction logic for SimulatorDashboardView.xaml
    /// </summary>
    public partial class SimulatorDashboardView : INavigableView<SimulatorDashboardViewModel>
    {
        public SimulatorDashboardViewModel ViewModel { get; }

        public SimulatorDashboardView(SimulatorDashboardViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}
