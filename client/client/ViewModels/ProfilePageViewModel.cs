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
    public class ProfilePageViewModel : ViewModelBase
    {
        public ReactiveCommand<Unit,Unit> LogOut_Click { get; set; }

        private readonly INavigationService _navigationService;

        public User CurrentUser {  get; set; }
        [Reactive] public List<Course> EnrolledCourses { get; set; } 

        public ProfilePageViewModel()
        {
            CurrentUser = new User();
            //EnrolledCourses = CurrentUser.EnrolledCourses;
            EnrolledCourses = new List<Course>
            {
                new Course{Title = "Тпт", Description="Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr "},
                new Course{Title = "Тпт", Description="Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr "},
                new Course{Title = "Тпт", Description="Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr "},
                new Course{Title = "Тпт", Description="Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr "},
                new Course{Title = "Тпт", Description="Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr "},
                new Course{Title = "Тпт", Description="Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr "},
                new Course{Title = "Тпт", Description="Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr "},
                new Course{Title = "Тпт", Description="Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr "},
                new Course{Title = "Тпт", Description="Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr "},
                new Course{Title = "Тпт", Description="Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr "},
                new Course{Title = "Тпт", Description="Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr "},
                new Course{Title = "Тпт", Description="Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr "},
                new Course{Title = "Тпт", Description="Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr "},
                new Course{Title = "Тпт", Description="Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr Descr "},
            };


            LogOut_Click = ReactiveCommand.CreateFromTask(LogOut);
        }

        public void SetUser(User user)
        {
            CurrentUser = user;
            EnrolledCourses = CurrentUser.EnrolledCourses;
        }


        public async Task LogOut()
        {
            _navigationService.NavigateTo<LoginPageView>();
        }



    }
}
