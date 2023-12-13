using AgOpenGPS.ViewModels.Pages;
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
    /// Interaction logic for ClientNTRIP_View.xaml
    /// </summary>
    public partial class ClientNTRIP_View : INavigableView<ClientNTRIPViewModel>
    {
        public ClientNTRIPViewModel ViewModel { get; }

        public ClientNTRIP_View(ClientNTRIPViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }
    }
}