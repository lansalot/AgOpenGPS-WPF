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

namespace AgOpenGPS.Views.Pages.Simulator_Pages
{
    /// <summary>
    /// Interaction logic for SimulatorUtilitiesView.xaml
    /// </summary>
    public partial class SimulatorUtilitiesView : Page
    {
        public SimulatorUtilitiesView()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public int count { get; set; } = 0;
        
        int maxCount = 25;
        private void btnRestartWizard_Click(object sender, RoutedEventArgs e)
        {
            btnnext.Visibility = Visibility.Collapsed;
            btnPriv.Visibility = Visibility.Collapsed;
            count = 0;
            progressbar.Value= 0;   
        }

        private void btnStartWizard_Click(object sender, RoutedEventArgs e)
        {
            btnnext.Visibility = Visibility.Visible;
        }

        private void btnPriv_Click(object sender, RoutedEventArgs e)
        {
            count--;
            progressbar.Value = count;
            if (count == 0)
            {
                btnPriv.Visibility = Visibility.Collapsed;
            }
            else if(count<maxCount)
            {
                btnnext.Visibility = Visibility.Visible;
            }
            
        }

        private void btnnext_Click(object sender, RoutedEventArgs e)
        {
            count++;
            progressbar.Value = count;
            btnPriv.Visibility = Visibility.Visible;
            if (count == maxCount)
            {
                btnnext.Visibility = Visibility.Collapsed;
            }
            else if(count>0)
            {
                btnPriv.Visibility = Visibility.Visible;
            }
            
        }
    }
}
