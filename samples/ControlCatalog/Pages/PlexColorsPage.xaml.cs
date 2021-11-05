using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Input;
using Avalonia.Interactivity;
using AvaloniaPlexTheme;
using System;
using System.Linq;
#if OLD_COLORS
using AvaloniaThemeColorization;
#endif

namespace ControlCatalog.Pages
{
    public class PlexColorsPage : UserControl
    {
        Slider _overallThemeHue;
        Slider _overallThemeSat;

        Slider _chromeHue;
        Slider _toolsMenuAreaHue;
        Slider _clientAreaBackgroundHue;
        Slider _controlsHue;

        ComboBox _colorMode;
        
        
        public PlexColorsPage()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
#if !OLD_COLORS
        }
#else
            _chromeHue = this.Find<Slider>("ChromeHue");
            _toolsMenuAreaHue = this.Find<Slider>("ToolsMenuAreaHue");
            _clientAreaBackgroundHue = this.Find<Slider>("ClientAreaBackgroundHue");
            _controlsHue = this.Find<Slider>("ControlsHue");
            
            _overallThemeHue = this.Find<Slider>("OverallThemeHue");
            _overallThemeSat = this.Find<Slider>("OverallThemeSat");

            _colorMode = this.Find<ComboBox>("ColorMode");


            this.Find<Button>("Apply").Click += (s, e) =>
            {
                PlexColorMode mode = (PlexColorMode)(_colorMode.SelectedIndex);

                if (_overallThemeHue.IsVisible)
                    RefreshColours(_overallThemeHue.Value, _overallThemeSat.Value, mode);
                else
                    RefreshColours(_chromeHue.Value, _toolsMenuAreaHue.Value, _clientAreaBackgroundHue.Value, _controlsHue.Value, mode);
            };


            /*Action refreshColoursSeparate = (() => 
            {
                Console.WriteLine("beep beep");
                (App.Current as App).RefreshColours(_chromeHue.Value, _toolsMenuAreaHue.Value, _clientAreaBackgroundHue.Value, _controlsHue.Value);
            });
            
            
            //_chromeHue.PointerReleased += (s, e) => refreshColoursSeparate();
            _chromeHue.AddHandler<PointerReleasedEventArgs>(Slider.PointerReleasedEvent, PartialColoursSliders_PointerReleased, RoutingStrategies.Bubble, true);
            _toolsMenuAreaHue.AddHandler<PointerReleasedEventArgs>(Slider.PointerReleasedEvent, PartialColoursSliders_PointerReleased, RoutingStrategies.Bubble, true);
            _clientAreaBackgroundHue.AddHandler<PointerReleasedEventArgs>(Slider.PointerReleasedEvent, PartialColoursSliders_PointerReleased, RoutingStrategies.Bubble, true);
            _controlsHue.AddHandler<PointerReleasedEventArgs>(Slider.PointerReleasedEvent, PartialColoursSliders_PointerReleased, RoutingStrategies.Bubble, true);

            /*_toolsMenuAreaHue.PointerReleased += (s, e) => refreshColoursSeparate();
            _clientAreaBackgroundHue.PointerReleased += (s, e) => refreshColoursSeparate();
            _controlsHue.PointerReleased += (s, e) => refreshColoursSeparate();*


            
            _overallThemeHue.AddHandler<PointerReleasedEventArgs>(Slider.PointerReleasedEvent, (s, e) => (App.Current as App).RefreshColours(_overallThemeHue.Value), RoutingStrategies.Bubble, true);*/
        }



        /*void PartialColoursSliders_PointerReleased(object sender, PointerReleasedEventArgs e)
        {
            (App.Current as App).RefreshColours(_chromeHue.Value, _toolsMenuAreaHue.Value, _clientAreaBackgroundHue.Value, _controlsHue.Value);
        }*/



        void RefreshColours(double hue, double saturation, PlexColorMode colorMode)
        {
            PlexTheme theme = (PlexTheme)((App.Current as App).Styles.FirstOrDefault(x => x is PlexTheme));

            theme.ColorScheme = new PlexColorScheme(hue, saturation, colorMode);
        }
        
        void RefreshColours(double chromeHue, double toolsMenuAreaHue, double clientAreaBackgroundHue, double controlsHue, PlexColorMode colorMode)
        {
            PlexTheme theme = (PlexTheme)((App.Current as App).Styles.FirstOrDefault(x => x is PlexTheme));

            theme.ColorScheme =
                new PlexColorScheme(
                    new HsvColor(chromeHue),
                    new HsvColor(toolsMenuAreaHue),
                    new HsvColor(clientAreaBackgroundHue),
                    new HsvColor(controlsHue),
                    colorMode
                );
        }
#endif
    }
}