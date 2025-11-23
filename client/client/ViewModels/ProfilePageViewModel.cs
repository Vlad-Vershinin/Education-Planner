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

        [Reactive] public bool IsViewingTheCourse { get; set; } = false;

        public CurriculumView SelectedCoursePage { get; set; }
        public int SelectedCourseID { get; set; }


        public ReactiveCommand<Unit,Unit> LogOut_Click { get; set; }

        private readonly INavigationService _navigationService;

        [Reactive] public User CurrentUser {  get; set; }
        [Reactive] public Profession CurrentProfession { get; set; }



        [Reactive] public List<Course> SkillsObtained { get; set; }
        public int SelectedSkillID { get; set; }




        [Reactive] public List<Course> EnrolledCourses { get; set; }
        [Reactive] public Course CurrentCourse { get; set; }


        public ReactiveCommand<Unit, Unit> ViewTheCourse_Click { get; set; }

        UserService AppUserService;
        public ProfilePageViewModel(UserService appUserService)
        {
            AppUserService = appUserService;
            CurrentUser = appUserService.CurrentUser;
            //EnrolledCourses = CurrentUser.EnrolledCourses;
            EnrolledCourses = appUserService.CurrentUser.EnrolledCourses;


            LogOut_Click = ReactiveCommand.CreateFromTask(LogOut);

            SelectedCoursePage = new CurriculumView(AppUserService);
            (SelectedCoursePage.DataContext as CurriculumViewModel).SetDelegate(BackToDataGrid);
            ViewTheCourse_Click = ReactiveCommand.CreateFromTask(ViewTheCourse);
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



        public async Task ViewTheCourse()
        {

            (SelectedCoursePage.DataContext as CurriculumViewModel).CourseSelected = EnrolledCourses[SelectedCourseID];
            IsViewingTheCourse = true;
        }
        public void BackToDataGrid()
        {
            IsViewingTheCourse = false;
        }


    }
}
