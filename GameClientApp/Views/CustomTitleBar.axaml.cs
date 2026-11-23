using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace GameClientApp.Views;

public partial class CustomTitleBar : UserControl
{
    public CustomTitleBar()
    {
        InitializeComponent();
    }

    private Window? HostWindow => TopLevel.GetTopLevel(this) as Window;

    private void OnTitleBarPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
        {
            HostWindow?.BeginMoveDrag(e);
        }
    }

    private void OnMinimizeClick(object? sender, RoutedEventArgs e)
    {
        if (HostWindow is not null)
            HostWindow.WindowState = WindowState.Minimized;
    }

    private void OnMaximizeClick(object? sender, RoutedEventArgs e)
    {
        if (HostWindow is null) return;

        HostWindow.WindowState = HostWindow.WindowState == WindowState.Maximized
            ? WindowState.Normal
            : WindowState.Maximized;
    }

    private void OnCloseClick(object? sender, RoutedEventArgs e)
    {
        HostWindow?.Close();
    }
}