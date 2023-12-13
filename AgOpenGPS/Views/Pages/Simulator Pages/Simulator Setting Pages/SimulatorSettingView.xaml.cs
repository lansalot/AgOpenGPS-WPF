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

namespace AgOpenGPS.Views.Pages.Simulator_Pages.Simulator_Setting_Pages
{
    /// <summary>
    /// Interaction logic for SimulatorSettingView.xaml
    /// </summary>
    public partial class SimulatorSettingView : Page
    {
        private readonly SimulatorGeneralSettingViewModel viewModel;

        public SimulatorSettingView(SimulatorGeneralSettingViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            List<DummyList> lst=new List<DummyList>()
            {
                 new DummyList()
                 {
                     Icon=(DrawingImage)this.FindResource("SettingDrawingImage"),
                     Content="General Settings"
                 },
                 new DummyList()
                 {
                     Icon=(DrawingImage)this.FindResource("TractorDrawingImage"),
                     Content="Vehicale Configuration"
                 },
                 new DummyList()
                 {
                     Icon=(DrawingImage)this.FindResource("FarmDrawingImage"),
                     Content="Implement Configuration"
                 },
                 new DummyList()
                 {
                     Icon=(DrawingImage)this.FindResource("SourceIconDrawingImage"),
                     Content="Source Configuration"
                 },
                 new DummyList()
                 {
                     Icon=(DrawingImage)this.FindResource("UturnIconDrawingImage"),
                     Content="Uturn Configuration"
                 },
                 new DummyList()
                 {
                     Icon=(DrawingImage)this.FindResource("CircuitDrawingImage"),
                     Content="Arduino Configuration"
                 },
                 new DummyList()
                 {
                     Icon=(DrawingImage)this.FindResource("TermsDrawingImage"),
                     Content="Trams Configuration"
                 },
                 new DummyList()
                 {
                     Icon=(DrawingImage)this.FindResource("IconsDrawingImage"),
                     Content="Icons Configuration"
                 },
            };
           
            listView.ItemsSource = lst;
            
           


        }
    }

    public class DummyList
    {
        public string Image { get; set; }
        public DrawingImage Icon { get; set; }
        public string Content { get; set; }
    }
}
