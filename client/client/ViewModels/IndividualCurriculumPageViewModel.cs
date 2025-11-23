using client.Models;
using client.Services;
using client.Views;
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
    public class IndividualCurriculumPageViewModel : ViewModelBase
    {
        [Reactive] public bool IsViewingTheCourse { get; set; } = false;
        public string BTN_FilterName { get { return "Фильтр"; } }
        public string TXT { get; set; } = "Курсы";
        public string BTN_Search { get; set; } = "Поиск";

        public string SearchText { get; set; } = string.Empty;

        public CurriculumView SelectedCoursePage { get; set; }
        public int SelectedCourseID { get; set; }

        public ReactiveCommand<Unit, Unit> ViewTheCourse_Click { get; set; }
        public ObservableCollection<Course> Courses { get; set; }
        public string SearchProfession { set; get; } = "";


        UserService AppUserService;

        public IndividualCurriculumPageViewModel(UserService appUserService)
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
