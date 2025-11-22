
using Avalonia.Controls;
using client.Models;
using client.Views;
using ReactiveUI;
using System.Reactive;
using System.Threading.Tasks;

namespace client.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string SplitViewButtonContent { get; set; } = ">";
    private bool _splitViewIsPaneOpen = false;
    public bool SplitViewPaneOpen { get { return _splitViewIsPaneOpen; } 
        set { 
            if (value)
            {
                SplitViewButtonContent = "<";

            }
            else 
            {
                SplitViewButtonContent = ">";

            }
            _splitViewIsPaneOpen = value;
        } }
    public UserControl FrameSelected {  get; set; }
    public ProfilePageView ProfilePage { get; set; }
    public CurriculumPageView CurriculumPage { get; set; }
    public CurriculumView Curriculum { get; set; }
    public RegistrationPageView RegistrationPage { get; set; }

    public MainViewModel() 
    {
        ProfilePage = new ProfilePageView();
        FrameSelected = new ProfilePageView();
        CurriculumPage = new CurriculumPageView();
        Curriculum = new CurriculumView();
        RegistrationPage = new RegistrationPageView();


        PanSwitchCommand = ReactiveCommand.CreateFromTask(PanSwitch);
        SwitchToPage = ReactiveCommand.CreateFromTask(switchProfilePage);
        SwitchToCurriculumPage = ReactiveCommand.CreateFromTask(switchToCurriculum);
        SwitchToCurriculumView = ReactiveCommand.CreateFromTask(switchToCurricul);
        SwitchToRegistratioPage = ReactiveCommand.CreateFromTask(SwitchToRegistr);
    }



    public ReactiveCommand<Unit, Unit> PanSwitchCommand { get; set; }
    public ReactiveCommand<Unit, Unit>SwitchToPage { get; set; }
    public ReactiveCommand<Unit, Unit> SwitchToCurriculumPage { get; set; }
    public ReactiveCommand<Unit, Unit> SwitchToCurriculumView { get; set; }
    public ReactiveCommand<Unit, Unit> SwitchToRegistratioPage { get; set; }


    public async Task PanSwitch() 
    {
        SplitViewPaneOpen = !SplitViewPaneOpen;
    }

    public async Task switchProfilePage()
    {
        FrameSelected = ProfilePage;
    }

    public async Task switchToCurriculum()
    {
        FrameSelected = CurriculumPage;
    }

    public async Task switchToCurricul()
    {
        FrameSelected = Curriculum;
    }

    public async Task SwitchToRegistr()
    {
        FrameSelected = RegistrationPage;
    }
}
