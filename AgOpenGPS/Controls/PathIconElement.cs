using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Wpf.Ui.Controls;

namespace AgOpenGPS.Controls
{

    internal class PathIconElement : IconElement
    {
        protected override UIElement InitializeChildren()
        {
            iconPath = new System.Windows.Shapes.Path();
            Style pathSyle = (Style)Application.Current.Resources["PathIconStyle"];
            iconPath.Style = pathSyle;
            iconPath.UpdateLayout();
            iconPath.Loaded += IconPath_Loaded;
            return iconPath;

        }

        private void IconPath_Loaded(object sender, RoutedEventArgs e)
        {
        }

        public static readonly DependencyProperty 
            PathProperty = 
            DependencyProperty.Register("Path", typeof(Geometry), typeof(PathIconElement), new PropertyMetadata(Geometry.Empty,
                delegate (DependencyObject o, DependencyPropertyChangedEventArgs _)
        {
            ((PathIconElement)o).OnIconPathChanged();
        }));
        public static readonly DependencyProperty
          PathFilledProperty =
          DependencyProperty.Register("FilledPath", typeof(Geometry), typeof(PathIconElement), new PropertyMetadata(Geometry.Empty,
              delegate (DependencyObject o, DependencyPropertyChangedEventArgs _)
              {
                  ((PathIconElement)o).OnIconPathChanged();
              }));

        public static readonly DependencyProperty FilledProperty = DependencyProperty.Register("Filled", typeof(bool), typeof(PathIconElement), new PropertyMetadata(false));
        public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register("Padding", typeof(Thickness), typeof(PathIconElement), new PropertyMetadata(new Thickness(0,0,0,0)));


        public Thickness Padding
        {
            get
            {
                return (Thickness)GetValue(PaddingProperty);
            }
            set
            {
                SetValue(PaddingProperty, value);
            }
        }
        public bool Filled
        {
            get
            {
                return (bool)GetValue(FilledProperty);
            }
            set
            {
                SetValue(FilledProperty, value);
            }
        }


        [Bindable(true)]
        public Geometry Path
        {
            get
            {
                return (Geometry)GetValue(PathProperty);
            }
            set
            {
                SetValue(PathProperty, value);
            }
        }
        [Bindable(true)]
        public Geometry FilledPath
        {
            get
            {
                return (Geometry)GetValue(PathFilledProperty);
            }
            set
            {
                SetValue(PathFilledProperty, value);
            }
        }
        public PathIconElement()
        {
           
            //UIElement.FocusableProperty.OverrideMetadata(typeof(PathIconElement), new FrameworkPropertyMetadata(false));
            //KeyboardNavigation.IsTabStopProperty.OverrideMetadata(typeof(PathIconElement), new FrameworkPropertyMetadata(false));
        }
        private void OnIconPathChanged()
        {
           
        }
        Path? iconPath;
       
     
    }
}
