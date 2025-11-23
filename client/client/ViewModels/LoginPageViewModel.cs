using Avalonia.Input;
using client.Models;
using client.Services;
using client.Services.Interfaces;
using client.Views;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace client.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public string Login {  get; set; }
        public string Password { get; set; }
        public string Warning { get; set; } // Сообщения для вывода под полями пароля и логина (аля Введен неверный логин или пароль)


        [Reactive] public bool IsLogged { get; set; } = false;



        public ReactiveCommand<Unit,Unit> TryLogIn_Click { get; set; }
        public UserService AppUserService { get; private set; }


        [Reactive]  public MainView AppInstance { get; set; }



        public LoginPageViewModel()
        {
            
            TryLogIn_Click = ReactiveCommand.CreateFromTask(TryLogIn);
        }


        public async Task TryLogIn()
        {
            User user = new User() { Login = this.Login, FirstName = this.Login };
            AppUserService = new UserService();
            AppUserService.CurrentUser = user;



            AppInstance = new MainView(AppUserService);
            IsLogged = true;
        }


    }
}
