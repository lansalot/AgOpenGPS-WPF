// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using AgOpenGPS.Controls;
using System.Collections.ObjectModel;
using System.Windows.Media;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace AgOpenGPS.ViewModels.Windows
{
    public partial class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            
        }



        [ObservableProperty]
        private string _applicationTitle = "WPF UI - AgOpenGPS";

        [ObservableProperty]
        private ObservableCollection<object> _menuItems = new()
        {
            new NavigationViewItem()
            {
                Content="Simulater",
                Icon = new PathIconElement {
                Path=Geometry.Parse("M4 21H20V8H4M14 15V18H10V15H7L12 10L17 15M3 3H21V7H3")  },
                TargetPageType = typeof(Views.Pages.Simulator_Pages.SimulatorDashboardView),
                 MenuItems =new List<NavigationViewItem>()
                 {
                     
                       new NavigationViewItem()
                      {

                          Content="General Settings",
                          Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                          TargetPageType = typeof(Views.Pages.Simulator_Pages.Simulator_Setting_Pages.SimulatorSettingView),
                          
                           
                      }
                      ,

                      new NavigationViewItem()
                      {

                          Content="Utilities",
                          Icon = new SymbolIcon { Symbol = SymbolRegular.Toolbox12 },
                          TargetPageType = typeof(Views.Pages.Simulator_Pages.SimulatorUtilitiesView)
                      }
                      ,
                      new NavigationViewItem()
                      {
                          Content= "Field Menu",
                          Icon = new SymbolIcon { Symbol = SymbolRegular.TextBoxSettings20 },
                          TargetPageType = typeof(Views.Pages.DataPage),

                      }
                      ,
                      new NavigationViewItem()
                      {
                          Content= "Steer Configuration",
                          Icon = new SymbolIcon { Symbol = SymbolRegular.PointScan20},
                          TargetPageType = typeof(Views.Pages.Simulator_Pages.SimulatorSteerView)
                      }
                      ,
                       new NavigationViewItem()
                      {
                          Content= "Vehicle",
                          Icon = new SymbolIcon { Symbol = SymbolRegular.VehicleCab20},
                          TargetPageType = typeof(Views.Pages.DataPage)
                      }

                 }
            },
             new NavigationViewItem()
            {
                Content= "IMU",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Accessibility24},
                TargetPageType = typeof(Views.Pages.CommGPSView),
             },
             new NavigationViewItem()
            {

                Content="Steer",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Accessibility24 },
                TargetPageType = typeof(Views.Pages.CommGPSView),
            }
            ,
            new NavigationViewItem()
            {

                Content="Steering",
                Icon = new SymbolIcon { Symbol = SymbolRegular.VehicleBicycle24 },
                TargetPageType = typeof(Views.Pages.CommGPSView),
            }
            ,
            new NavigationViewItem()
            {
                Content= "GPS",
                Icon = new SymbolIcon { Symbol = SymbolRegular.CropInterim20 },
                TargetPageType = typeof(Views.Pages.CommGPSView),

            }
            ,
            new NavigationViewItem()
            {
                Content= "Section Controler",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Braces16},
                TargetPageType = typeof(Views.Pages.CommGPSView),
            }
             ,
               new NavigationViewItem()
            {
                Content= "NTRIP",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Signature24},
                  MenuItems =new List<NavigationViewItem>()
                  { 
                        new NavigationViewItem()
                       {

                           Content="Client NTRIP",
                           Icon = new SymbolIcon { Symbol = SymbolRegular.Accessibility24 },
                           TargetPageType = typeof(Views.Pages.NTRIP_Pages.ClientNTRIP_View)
                       }
                       ,

                       new NavigationViewItem()
                       {

                           Content="Radio NTRIP",
                           Icon = new SymbolIcon { Symbol = SymbolRegular.VehicleBicycle24 },
                           TargetPageType = typeof(Views.Pages.NTRIP_Pages.RadioNTRIP_View)
                       }
                       ,
                       new NavigationViewItem()
                       {
                           Content= "Serial NTRIP",
                           Icon = new SymbolIcon { Symbol = SymbolRegular.CropInterim20 },
                           TargetPageType = typeof(Views.Pages.NTRIP_Pages.SerialNTRIP_View),

                       }



                  }
            },
           new NavigationViewItem()
            {
                Content = "Ethernet Configuration",
                Icon = new SymbolIcon { Symbol = SymbolRegular.ConferenceRoom24 },
                TargetPageType = typeof(Views.Pages.EthernetConfigurationView),

           },
           new NavigationViewItem()
            {
                Content = "Settings",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                //TargetPageType = typeof(Views.Pages.SettingsPage),
                MenuItems =new List<NavigationViewItem>()
                {
                        new NavigationViewItem()
                       {

                           Content="Save",
                           Icon = new SymbolIcon { Symbol = SymbolRegular.Save24 },
                           TargetPageType = typeof(Views.Pages.AgOPenIOSetting_Pages.SaveSettingView)
                       }
                       ,

                       new NavigationViewItem()
                       {

                           Content="Load",
                           Icon = new SymbolIcon { Symbol = SymbolRegular.Archive24 },
                           TargetPageType = typeof(Views.Pages.AgOPenIOSetting_Pages.LoadSettingView)
                       }
                       ,
                       new NavigationViewItem()
                       {
                           Content= "UDP Monitor",
                           Icon = new SymbolIcon { Symbol = SymbolRegular.Desk24 },
                           TargetPageType = typeof(Views.Pages.AgOPenIOSetting_Pages.UDPMonitorView),

                       }
                        ,
                       new NavigationViewItem()
                       {
                           Content= "Serial Monitor",
                           Icon = new SymbolIcon { Symbol = SymbolRegular.Dismiss24 },
                           TargetPageType = typeof(Views.Pages.AgOPenIOSetting_Pages.SerialMonitorView),

                       },
                       new NavigationViewItem()
                       {
                           Content= "Device Manager",
                           Icon = new SymbolIcon { Symbol = SymbolRegular.AccessibilityCheckmark24 },
                           TargetPageType= typeof(string),

                       }
            ,


                }
            }
                 ,




        };

        [ObservableProperty]
        private ObservableCollection<object> _footerMenuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "App Settings",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                TargetPageType = typeof(Views.Pages.SettingsPage),

               }
        };

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new()
        {
            new MenuItem { Header = "Home", Tag = "tray_home" }
        };
        private readonly INavigationService navigationService;
    }
}
