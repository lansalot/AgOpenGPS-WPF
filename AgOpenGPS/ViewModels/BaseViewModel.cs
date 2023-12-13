using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Controls;

namespace AgOpenGPS.ViewModels
{
   public partial class BaseViewModel : ObservableObject, INavigationAware
    {
        public virtual void OnNavigatedFrom()
        {
            
        }

        public virtual void OnNavigatedTo()
        {
            
        }
    }
}
