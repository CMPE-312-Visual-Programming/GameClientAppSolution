using CommunityToolkit.Mvvm.ComponentModel;
using GameClientApp.ViewModels.Base;

namespace GameClientApp.ViewModels.Main;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] public partial string Greeting { get; set; } = "Welcome to Avalonia!";
}