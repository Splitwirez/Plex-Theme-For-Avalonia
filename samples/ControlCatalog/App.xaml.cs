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
        /*private static readonly StyleInclude DataGridFluent = new StyleInclude(new Uri("avares://ControlCatalog/Styles"))
        {
            Source = new Uri("avares://Avalonia.Controls.DataGrid/Themes/Fluent.xaml")
        };

        private static readonly StyleInclude DataGridDefault = new StyleInclude(new Uri("avares://ControlCatalog/Styles"))
        {
            Source = new Uri("avares://Avalonia.Controls.DataGrid/Themes/Default.xaml")
        };

        public static Styles FluentDark = new Styles
        {
            new StyleInclude(new Uri("avares://ControlCatalog/Styles"))
            {
                Source = new Uri("avares://Avalonia.Themes.Fluent/FluentDark.xaml")
            },
            DataGridFluent
        };

        public static Styles FluentLight = new Styles
        {
            new StyleInclude(new Uri("avares://ControlCatalog/Styles"))
            {
                Source = new Uri("avares://Avalonia.Themes.Fluent/FluentLight.xaml")
            },
            DataGridFluent
        };

        public static Styles DefaultLight = new Styles
        {
            new StyleInclude(new Uri("resm:Styles?assembly=ControlCatalog"))
            {
                Source = new Uri("avares://Avalonia.Themes.Fluent/Accents/AccentColors.xaml")
            },
            new StyleInclude(new Uri("resm:Styles?assembly=ControlCatalog"))
            {
                Source = new Uri("avares://Avalonia.Themes.Fluent/Accents/Base.xaml")
            },
            new StyleInclude(new Uri("resm:Styles?assembly=ControlCatalog"))
            {
                Source = new Uri("avares://Avalonia.Themes.Fluent/Accents/BaseLight.xaml")
            },
            new StyleInclude(new Uri("resm:Styles?assembly=ControlCatalog"))
            {
                Source = new Uri("avares://Avalonia.Themes.Default/Accents/BaseLight.xaml")
            },
            new StyleInclude(new Uri("resm:Styles?assembly=ControlCatalog"))
            {
                Source = new Uri("avares://Avalonia.Themes.Default/DefaultTheme.xaml")
            },
            DataGridDefault
        };

        public static Styles DefaultDark = new Styles
        {
            new StyleInclude(new Uri("resm:Styles?assembly=ControlCatalog"))
            {
                Source = new Uri("avares://Avalonia.Themes.Fluent/Accents/AccentColors.xaml")
            },
            new StyleInclude(new Uri("resm:Styles?assembly=ControlCatalog"))
            {
                Source = new Uri("avares://Avalonia.Themes.Fluent/Accents/Base.xaml")
            },
            new StyleInclude(new Uri("resm:Styles?assembly=ControlCatalog"))
            {
                Source = new Uri("avares://Avalonia.Themes.Fluent/Accents/BaseDark.xaml")
            },
            new StyleInclude(new Uri("resm:Styles?assembly=ControlCatalog"))
            {
                Source = new Uri("avares://Avalonia.Themes.Default/Accents/BaseDark.xaml")
            },
            new StyleInclude(new Uri("resm:Styles?assembly=ControlCatalog"))
            {
                Source = new Uri("avares://Avalonia.Themes.Default/DefaultTheme.xaml")
            },
            DataGridDefault
        };*/

        public override void Initialize()
        {
            //Styles.Insert(0, FluentLight);

            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime)
                desktopLifetime.MainWindow = new MainWindow();
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewLifetime)
                singleViewLifetime.MainView = new MainView();

            base.OnFrameworkInitializationCompleted();
        }

        public void RefreshColours(double hue)
        {
            RefreshColours(hue, hue, hue + 7, hue - 5);
        }

        public void RefreshColours(double hue, PlexColorMode colorMode)
        {
            RefreshColours(hue, hue, hue, hue, colorMode);
        }
        /*public void RefreshColours(double chromeHue = 210, double toolsMenuAreaHue = 210, double clientAreaBackgroundHue = 210, double controlsHue = 210)
        {
            RefreshColours(chromeHue, toolsMenuAreaHue, clientAreaBackgroundHue, controlsHue, PlexColorScheme.DEFAULT_COLOR_MODE);
        }*/
        public void RefreshColours(double chromeHue, double toolsMenuAreaHue, double clientAreaBackgroundHue, double controlsHue, PlexColorMode colorMode = PlexColorScheme.DEFAULT_COLOR_MODE)
        {
            PlexTheme theme = (PlexTheme)(this.Styles.FirstOrDefault(x => x is PlexTheme));

            theme.ColorScheme =
                new PlexColorScheme(
                    (byte)chromeHue,
                    (byte)toolsMenuAreaHue,
                    (byte)clientAreaBackgroundHue,
                    (byte)controlsHue,
                    colorMode
                );
            
            /*theme.RefreshColours((int)chromeHue, (int)toolsMenuAreaHue, (int)clientAreaBackgroundHue, (int)controlsHue);
            
            int themeIndex = Styles.IndexOf(theme);
            
            Styles.RemoveAt(themeIndex);
            
            Styles.Insert(themeIndex, theme);*/
        }
    }
}
