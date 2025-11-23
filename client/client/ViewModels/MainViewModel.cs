
using Avalonia.Controls;
using client.Models;
using client.Services;
using client.Views;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;
using System.Threading.Tasks;

namespace client.ViewModels;

public class MainViewModel : ViewModelBase
{
    private string _splitViewButtonContent = ">";
    [Reactive] public string SplitViewButtonContent { get { return _splitViewButtonContent; } set { _splitViewButtonContent = value; } }
    private bool _splitViewIsPaneOpen = false;
    
    [Reactive]public bool SplitViewPaneOpen { get { return _splitViewIsPaneOpen; } 
        set {
            _splitViewIsPaneOpen = value;

        } }
    [Reactive] public UserControl FrameSelected {  get; set; }
    public ProfilePageView ProfilePage { get; set; }
    public CurriculumPageView CurriculumPage { get; set; }
    public IndividualCurriculumPageView IndividualCurriculumPage { get; set; }
    public RegistrationPageView RegistrationPage { get; set; }




    public UserService AppUserService { get; private set; }

    public MainViewModel(UserService userService) 
    {
        AppUserService = userService;


        ProfilePage = new ProfilePageView(AppUserService);
        CurriculumPage = new CurriculumPageView(AppUserService);
        IndividualCurriculumPage = new IndividualCurriculumPageView(AppUserService);
        RegistrationPage = new RegistrationPageView();


        PanSwitchCommand = ReactiveCommand.CreateFromTask(PanSwitch);
        SwitchToProfilePage = ReactiveCommand.CreateFromTask(switchProfilePage);
        SwitchToCurriculumPage = ReactiveCommand.CreateFromTask(switchToCurriculum);
        SwitchToIndividualCurriculumPage = ReactiveCommand.CreateFromTask(switchToIndividualCurriculum);
        SwitchToRegistratioPage = ReactiveCommand.CreateFromTask(SwitchToRegistr);

        switchProfilePage();
    }



    public ReactiveCommand<Unit, Unit> PanSwitchCommand { get; set; }
    public ReactiveCommand<Unit, Unit> SwitchToProfilePage { get; set; }
    public ReactiveCommand<Unit, Unit> SwitchToCurriculumPage { get; set; }
    public ReactiveCommand<Unit, Unit> SwitchToIndividualCurriculumPage { get; set; }
    public ReactiveCommand<Unit, Unit> SwitchToRegistratioPage { get; set; }


    public async Task PanSwitch() 
    {
        SplitViewPaneOpen = !SplitViewPaneOpen;

        if (SplitViewPaneOpen)
        {
            SplitViewButtonContent = "<";

        }
        else
        {
            SplitViewButtonContent = ">";

        }
    }

    public async Task switchProfilePage()
    {
        FrameSelected = ProfilePage;
        (ProfilePage.DataContext as ProfilePageViewModel).Refresh();
    }

    public async Task switchToCurriculum()
    {
        FrameSelected = CurriculumPage;
    }
    public async Task switchToIndividualCurriculum()
    {
        FrameSelected = IndividualCurriculumPage;
    }

    public async Task SwitchToRegistr()
    {
        FrameSelected = RegistrationPage;
    }
}
