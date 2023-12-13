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
    /// Interaction logic for SerialNTRIP_View.xaml
    /// </summary>
    public partial class SerialNTRIP_View : INavigableView<SerialNTRIPViewModel>
    {
        public SerialNTRIPViewModel ViewModel { get; }

        public SerialNTRIP_View(SerialNTRIPViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }
    }
}