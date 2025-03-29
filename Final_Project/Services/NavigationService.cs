using Final_Project.Models;
using Final_Project.ViewModels;
using Final_Project.Views;
using System;
using System.Collections.Generic;

namespace Final_Project.Services
{
    public interface INavigationService
    {
        void NavigateTo<TViewModel>(object parameter = null) where TViewModel : class;
        void GoBack();
    }

    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Stack<object> _navigationStack = new Stack<object>();
        private MainViewModel _mainViewModel;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void SetMainViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public void NavigateTo<TViewModel>(object parameter = null) where TViewModel : class
        {
            // Resolve the ViewModel using the service provider
            var viewModel = _serviceProvider.GetService(typeof(TViewModel)) as TViewModel;

            if (viewModel == null)
            {
                throw new InvalidOperationException($"ViewModel of type {typeof(TViewModel).Name} could not be resolved.");
            }

            // Initialize the ViewModel if it supports parameterization
            if (viewModel is IParameterizedViewModel parameterizedViewModel && parameter != null)
            {
                parameterizedViewModel.Initialize(parameter);
            }

            // Push the ViewModel onto the navigation stack and set it as the current ViewModel
            _navigationStack.Push(viewModel);
            _mainViewModel.CurrentViewModel = viewModel;
        }




        public void GoBack()
        {
            if (_navigationStack.Count > 1)
            {
                _navigationStack.Pop();
                var previousViewModel = _navigationStack.Peek();
                _mainViewModel.CurrentViewModel = previousViewModel;
            }
        }
    }

    // Interface for ViewModels that support parameterized initialization
    public interface IParameterizedViewModel
    {
        void Initialize(object parameter);
    }
}
