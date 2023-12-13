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

namespace AgOpenGPS.UserControls
{
    /// <summary>
    /// Interaction logic for VehicalsConfigurationUC.xaml
    /// </summary>
    public partial class VehicalsConfigurationUC : UserControl
    {
        public VehicalsConfigurationUC()
        {
            InitializeComponent();
            List<DummyList> lst1 = new List<DummyList>()
            {
                 new DummyList()
                 {
                     Image="/Assets/Brand/Case.png",

                 },
                 new DummyList()
                 {
                     Image="/Assets/Brand/Claas.png",
                 },
                 new DummyList()
                 {
                     Image="/Assets/Brand/Deutz.png",
                 },
                 new DummyList()
                 {
                    Image="/Assets/Brand/Massey.png",
                 },
                 new DummyList()
                 {
                    Image="/Assets/Brand/NewHolland.png",
                 },
                 new DummyList()
                 {
                    Image="/Assets/Brand/Same.png",
                 },
                 new DummyList()
                 {
                    Image="/Assets/Brand/Ursus.png",
                 },
                 new DummyList()
                 {
                    Image="/Assets/Brand/Valtra.png",
                 },
                 new DummyList()
                 {
                    Image="/Assets/Brand/JohnDeere.png",
                 },
                  new DummyList()
                 {
                    Image="/Assets/Brand/Fendt.png",
                 },
                   new DummyList()
                 {
                    Image="/Assets/Brand/Steyr.png",
                 },
                    new DummyList()
                 {
                    Image="/Assets/Brand/Kubota.png",
                 },
            };
            listView1.ItemsSource = lst1;
            listView2.ItemsSource = lst1;
            listView3.ItemsSource = lst1;
        }
    }
    public class DummyList
    {
        public string Image { get; set; }
        public DrawingImage Icon { get; set; }
        public string Content { get; set; }
    }
}
