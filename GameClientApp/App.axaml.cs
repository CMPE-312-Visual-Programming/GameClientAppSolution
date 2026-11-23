using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using GameClientApp.ViewModels;
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

            void SwitchToMainWindow()
            {
                var mainWindow = new MainWindow
                {
                    DataContext = new MainViewModel()
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