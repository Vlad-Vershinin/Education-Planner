using Avalonia.Controls;
using client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Services
{
    public class NavigationService : INavigationService, INotifyPropertyChanged
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Stack<UserControl> _navigationStack;

        private UserControl _currentUserControl;
        public UserControl CurrentUserControl
        {
            get => _currentUserControl;
            set
            {
                if (_currentUserControl == value) return;
                _currentUserControl = value;
                RaisePropertyChanged(nameof(CurrentUserControl));
            }
        }

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _navigationStack = new Stack<UserControl>();
        }

        public bool CanGoBack => _navigationStack.Count > 0;

        public void GoBack()
        {
            if (!CanGoBack)
                return;

            CurrentUserControl = _navigationStack.Pop();
        }

        public void NavigateTo<T>() where T : UserControl
        {
            NavigateTo(typeof(T));
        }

        public void NavigateTo(Type windowType)
        {
            if (!typeof(UserControl).IsAssignableFrom(windowType))
                throw new ArgumentException("Type must be a UserControl");

            if (CurrentUserControl != null)
            {
                _navigationStack.Push(CurrentUserControl);
            }

            CurrentUserControl = (UserControl)_serviceProvider.GetService(windowType);

            if (CurrentUserControl == null)
                throw new InvalidOperationException($"UserControl {windowType.Name} is not registered");
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
