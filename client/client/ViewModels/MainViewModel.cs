
using Avalonia.Controls;
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
    }

}
