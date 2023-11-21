using StomaTomaToma.Views;
namespace StomaTomaToma.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            _StomatologiControl = new StomaTomaControl();
            _StomatologiControl.DataContext = new StomatologiControlViewModel();
        }
        public StomaTomaControl _StomatologiControl { get; set;}
        //1
    }
}
    
