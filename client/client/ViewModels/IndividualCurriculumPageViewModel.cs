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

        public string SearchText { get; set; } = string.Empty;

        public ProfessionPreviewView SelectedProfessionPage { get; set; }
        public int SelectedProfessionID { get; set; }

        public ReactiveCommand<Unit, Unit> ViewTheCourse_Click { get; set; }
        public ObservableCollection<Profession> Professions { get; set; }
        public string SearchProfession { set; get; } = "";


        UserService AppUserService;

        public IndividualCurriculumPageViewModel(UserService appUserService)
        {

            AppUserService = appUserService;
            Professions = new ObservableCollection<Profession> {

            new Profession{Name = "Profess"}
            };
            SelectedProfessionPage = new ProfessionPreviewView();
            (SelectedProfessionPage.DataContext as ProfessionPreviewViewModel).SetDelegate(BackToDataGrid);
            ViewTheCourse_Click = ReactiveCommand.CreateFromTask(ViewTheCourse);
        }


        public async Task ViewTheCourse()
        {
            (SelectedProfessionPage.DataContext as ProfessionPreviewViewModel).Profession = Professions[SelectedProfessionID];
            IsViewingTheCourse = true;
        }
        public void BackToDataGrid()
        {
            IsViewingTheCourse = false;
        }

    }
}
