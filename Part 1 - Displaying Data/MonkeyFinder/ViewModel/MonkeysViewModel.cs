using CommunityToolkit.Mvvm.Input;
using MonkeyFinder.Services;
namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    MonkeyService monkeyService;


    // this collection below acts as a List or Array and will be notified when things changed
    public ObservableCollection<Monkey> Monkeys { get; } = new();


    public MonkeysViewModel(MonkeyService monkeyService)
    {
        Title = "Monkey Finder Editted";
        this.monkeyService = monkeyService;
  
    }

    [RelayCommand]
    async Task GetMonkeysAsync()
    {
        if(IsBusy) return;

        try
        {
            IsBusy= true;
            var monkeys = await monkeyService.GetMonkeys();

            if(Monkeys.Count != 0)
            {
                monkeys.Clear();

                foreach(var monkey in Monkeys)
                {
                    Monkeys.Add(monkey);
                }
            }
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!", $"Unable to get monkeys: {ex.Message}", "OK");

            // do not practice the above alert!!
        }
        
    }
}
