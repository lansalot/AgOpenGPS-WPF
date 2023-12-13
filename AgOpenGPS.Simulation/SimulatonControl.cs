using AgOpenGPS.Simulation.Struct;
using System;
using System.Collections.Generic;

namespace AgOpenGPS.Simulation
{
    public partial class SimulatonControl:OpenTK.Wpf.GLWpfControl
    {
        public SimulatonControl()
        {
            this.Loaded += SimulatonControl_Loaded;
        }
        private void SimulatonControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
   
}
