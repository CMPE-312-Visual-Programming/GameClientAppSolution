using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using GameClientApp.Interfaces.Login;
using GameClientApp.ViewModels.Main;
using GameClientApp.ViewModels.Login;
using GameClientApp.Views;

namespace GameClientApp;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            LoginWindow? loginWindow = null;

            void SwitchToMainWindow(IPersonLoginControl loggedInUser)
            {
                var mainWindow = new MainWindow
                {
                    DataContext = new MainViewModel(loggedInUser)
                };

                desktop.MainWindow = mainWindow;
                mainWindow.Show();
                loginWindow?.Close();
            }

            loginWindow = new LoginWindow
            {
                DataContext = new LoginWindowViewModel(SwitchToMainWindow)
            };

            desktop.MainWindow = loginWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }
}