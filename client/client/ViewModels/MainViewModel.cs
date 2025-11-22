
using Avalonia.Controls;
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

    public MainViewModel() 
    {
        ProfilePage = new ProfilePageView();
        FrameSelected = new ProfilePageView();
        CurriculumPage = new CurriculumPageView();


        //Присваивание реактивным командам методов. "CreateFromTask" для ассинхронщины, просто "Create" - для синхронщины.

        PanSwitchCommand = ReactiveCommand.CreateFromTask(PanSwitch);
    }



    public ReactiveCommand<Unit, Unit> PanSwitchCommand { get; set; } //Пример Реактивной команды. (Пиши <Unit, Unit>)
    public async Task PanSwitch() //Метод для использования реактивной командой
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

}
