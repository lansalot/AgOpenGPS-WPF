namespace AgOpenGPS.ViewModels.Pages.Simulator_Pages
{
    public partial class SimulatorGeneralSettingViewModel : BaseViewModel
    {
        public SimulatorGeneralSettingViewModel()
        {
            PropertyChanged += SimulatorGeneralSettingViewModel_PropertyChanged;
        }

        private void SimulatorGeneralSettingViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName==nameof(CurrentSettingViewIndex))
            {
                CurrentSettingViewIndexStr = CurrentSettingViewIndex.ToString();
            }
        }

        [ObservableProperty]
        int _currentSettingViewIndex=0;
        [ObservableProperty]
        string _currentSettingViewIndexStr;
    }
}
