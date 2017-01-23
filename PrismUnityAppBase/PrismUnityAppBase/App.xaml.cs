using Prism.Modularity;
using Prism.Unity;
using PrismUnityAppBase.ViewModels;
using PrismUnityAppBase.Views;

namespace PrismUnityAppBase
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            //NavigationService.NavigateAsync("MainPage?title=Hello%20from%20Xamarin.Forms"); NavigationService.NavigateAsync("MyMasterDetail/MyNavigationPage/MainPage", animated: false);
            NavigationService.NavigateAsync("PrismMasterDetailPage/PrismNavigationPage/MainPage", animated: false);
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage, SomeOtherViewModel>(); //override viewmodel convention
            Container.RegisterTypeForNavigation<PrismNavigationPage>();
            Container.RegisterTypeForNavigation<PrismMasterDetailPage>();
            Container.RegisterTypeForNavigation<PrismNavigationPage>();
        }

        protected override void ConfigureModuleCatalog()
        {
            //ModuleCatalog.AddModule(new ModuleInfo(typeof(ModuleA.ModuleAModule)));
            //ModuleCatalog.AddModule(new ModuleInfo("ModuleA", typeof(ModuleA.ModuleAModule), InitializationMode.OnDemand));
        }
    }
}
