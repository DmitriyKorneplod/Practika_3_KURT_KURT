using StomaTomaToma.Views;
namespace StomaTomaToma.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            _StomatologiControl = new StomaTomaControl();
            _StomatologiControl.DataContext = new StomatologiControlViewModel();
            _ServiceControl = new Service();
            _ServiceControl.DataContext = new ServiceControlViewModel();
        }
       
         public StomaTomaControl _StomatologiControl { get; set;}
         public Service _ServiceControl { get; set; }
    }
}
    
