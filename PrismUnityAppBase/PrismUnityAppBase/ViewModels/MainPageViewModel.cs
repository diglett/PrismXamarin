using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismUnityAppBase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismUnityAppBase.ViewModels
{
    public class MainPageViewModel : ViewModelBase, INavigationAware
    {
        public string Title
        {
            get { return Get(() => Title); }
            set { Set(() => Title, value); }
        }

        public MainPageViewModel()
        {

        }

        public new void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public new void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
