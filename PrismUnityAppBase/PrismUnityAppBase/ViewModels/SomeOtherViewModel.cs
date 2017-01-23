using PrismUnityAppBase.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Modularity;
using System;
using Prism.Services;

namespace PrismUnityAppBase.ViewModels
{
    public class SomeOtherViewModel : ViewModelBase
    {
        IPageDialogService _dialogService;
                
        public string Title
        {
            get { return Get(() => Title); }
            set { Set(() => Title, value); }
        }

        public DelegateCommand LoadModuleACommand { get; set; }

        public SomeOtherViewModel(IPageDialogService dialogService)
        {
            Title = "Some Other ViewModel that doesn't follow the ViewModelLocatorRules";

            _dialogService = dialogService;
            LoadModuleACommand = new DelegateCommand(ShowDialog);
        }

        void ShowDialog()
        {
            _dialogService.DisplayAlertAsync("Hello from SomeOtherViewModel", "This is a message from an exception to the ViewModelLocator rules.", "Cool");
        }
    }
}