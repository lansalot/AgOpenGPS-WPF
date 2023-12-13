using AgOpenGPS.ViewModels.Pages.Simulator_Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AgOpenGPS.ViewModels
{
   public class ViewModelLocator
    {

        public SimulatorGeneralSettingViewModel SimulatorGeneralSettingViewModel => App.GetService<SimulatorGeneralSettingViewModel>();



    }
}
