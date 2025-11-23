using Avalonia.Controls;
using client.Models;
using client.Models.Enum;
using client.Services;
using client.Views;
using DynamicData.Binding;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace client.ViewModels
{
    public class CurriculumPageViewModel : ViewModelBase
    {
        [Reactive] public bool IsViewingTheCourse { get; set; } = false;
        public string BTN_FilterName { get { return "Фильтр"; } }
        public string TXT { get; set; } = "Курсы";
        public string BTN_Search { get; set; } = "Поиск";

        public string SearchText { get; set; } = string.Empty;

        public CurriculumView SelectedCoursePage { get; set; }
        public int SelectedCourseID { get; set; }

        public ReactiveCommand<Unit, Unit> ViewTheCourse_Click { get;set; }



        public ObservableCollection<Course> Courses { get; set;}

        UserService AppUserService;

        public CurriculumPageViewModel(UserService appUserService) 
        {
            AppUserService = appUserService;
            Courses = new ObservableCollection<Course> {

            new Course{Title = "Титле"}
            };

            SelectedCoursePage = new CurriculumView();
            (SelectedCoursePage.DataContext as CurriculumViewModel).SetDelegate(BackToDataGrid);
            ViewTheCourse_Click = ReactiveCommand.CreateFromTask(ViewTheCourse);
        }


        public async Task ViewTheCourse()
        {
            (SelectedCoursePage.DataContext as CurriculumViewModel).CourseSelected = Courses[SelectedCourseID];
            IsViewingTheCourse = true;
        }
        public void BackToDataGrid()
        {
            IsViewingTheCourse = false;
        }

    }
}
