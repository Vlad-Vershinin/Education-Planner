
using Avalonia.Controls;
using client.Models;
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
