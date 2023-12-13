using AgOpenGPS.ViewModels.Pages.NTRIP_Pages;
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

namespace AgOpenGPS.Views.Pages.NTRIP_Pages
{
    /// <summary>
    /// Interaction logic for RadioNTRIP_View.xaml
    /// </summary>
    public partial class RadioNTRIP_View : INavigableView<RadioNTRIPViewModel>
    {
        public RadioNTRIPViewModel ViewModel { get; }

        public RadioNTRIP_View(RadioNTRIPViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }
    }
}
