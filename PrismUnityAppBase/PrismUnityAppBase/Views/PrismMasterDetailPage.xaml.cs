using Prism.Navigation;
using Xamarin.Forms;

namespace PrismUnityAppBase.Views
{
    public partial class PrismMasterDetailPage : MasterDetailPage, IMasterDetailPageOptions
    {
        public PrismMasterDetailPage()
        {
            InitializeComponent();
        }
                
        public bool IsPresentedAfterNavigation
        {
            get { return Device.Idiom != TargetIdiom.Phone; }
        }
    }
}