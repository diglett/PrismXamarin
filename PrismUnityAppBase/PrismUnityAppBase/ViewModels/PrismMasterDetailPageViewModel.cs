using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismUnityAppBase.ViewModels
{
    public class PrismMasterDetailPageViewModel : ViewModelBase
    {
        INavigationService _navigationService;

        public ICommand NavigateCommand
        {
            get { return Get(() => NavigateCommand, new DelegateCommand<string>(Navigate)); }
        }

        public PrismMasterDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private void Navigate(string name)
        {
            _navigationService.NavigateAsync(name);
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }
    }
}
