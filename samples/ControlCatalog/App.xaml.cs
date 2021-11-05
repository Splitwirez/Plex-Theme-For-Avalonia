using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;
using AvaloniaPlexTheme;

namespace ControlCatalog
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
#if OLD_COLORS
            Styles.Remove(Styles.OfType<StyleInclude>().FirstOrDefault());
            Styles.Add(new PlexTheme());
#endif
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime)
                desktopLifetime.MainWindow = new MainWindow();
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewLifetime)
                singleViewLifetime.MainView = new MainView();

            base.OnFrameworkInitializationCompleted();
        }
    }
}
