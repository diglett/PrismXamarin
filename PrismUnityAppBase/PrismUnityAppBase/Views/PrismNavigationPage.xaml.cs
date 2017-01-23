using Prism.Navigation;
using Xamarin.Forms;

namespace PrismUnityAppBase.Views
{
    public partial class PrismNavigationPage : NavigationPage, INavigationPageOptions, IDestructible
    {
        public PrismNavigationPage()
        {
            InitializeComponent();
        }

        public bool ClearNavigationStackOnNavigation
        {
            get { return true; }
        }

        public void Destroy()
        {

        }
    }
}
