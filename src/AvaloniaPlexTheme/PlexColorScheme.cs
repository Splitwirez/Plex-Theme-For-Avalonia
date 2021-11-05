#if OLD_COLORS
using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Media;
using Avalonia.Styling;
using AvaloniaThemeColorization;
using AvaloniaThemeColorization.Rules;

#nullable enable

namespace AvaloniaPlexTheme
{
    public enum PlexColorMode
    {
        //Light,
        Bright,
        Dark
    }


    public partial class PlexColorScheme : AvaloniaObject, IThemeColorScheme
    {
        public const PlexColorMode DEFAULT_COLOR_MODE = PlexColorMode.Bright;


        public static readonly StyledProperty<HsvColor> ChromeProperty =
            AvaloniaProperty.Register<PlexColorScheme, HsvColor>(nameof(Chrome), new HsvColor(210, 0xFF));
        public HsvColor Chrome
        {
            get => GetValue(ChromeProperty);
            set => SetValue(ChromeProperty, value);
        }

        public static readonly StyledProperty<HsvColor> ToolsMenuAreaProperty =
            AvaloniaProperty.Register<PlexColorScheme, HsvColor>(nameof(ToolsMenuArea), new HsvColor(210));
        public HsvColor ToolsMenuArea
        {
            get => GetValue(ToolsMenuAreaProperty);
            set => SetValue(ToolsMenuAreaProperty, value);
        }

        public static readonly StyledProperty<HsvColor> BackgroundProperty =
            AvaloniaProperty.Register<PlexColorScheme, HsvColor>(nameof(Background), new HsvColor(217));
        public HsvColor Background
        {
            get => GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }

        public static readonly StyledProperty<HsvColor> ControlsProperty =
            AvaloniaProperty.Register<PlexColorScheme, HsvColor>(nameof(Controls), new HsvColor(205));
        public HsvColor Controls
        {
            get => GetValue(ControlsProperty);
            set => SetValue(ControlsProperty, value);
        }


        static int CoerceHueProperties(IAvaloniaObject s, int e)
        {
            return Math.Clamp(e, byte.MinValue, byte.MaxValue);
        }


        public static readonly StyledProperty<PlexColorMode> ColorModeProperty =
            AvaloniaProperty.Register<PlexColorScheme, PlexColorMode>(nameof(ColorMode), DEFAULT_COLOR_MODE);
        public PlexColorMode ColorMode
        {
            get => GetValue(ColorModeProperty);
            set => SetValue(ColorModeProperty, value);
        }


        /*static HsvColor GetDefaultThemeColor(StyledProperty<int> property) =>
            new HsvColor((byte)property.GetDefaultValue(typeof(int)));
        
        HsvColor _chromeColor = GetDefaultThemeColor(ChromeProperty);
        HsvColor _toolsMenuAreaColor = GetDefaultThemeColor(ToolsMenuAreaProperty);
        HsvColor _backgroundColor = GetDefaultThemeColor(BackgroundProperty);
        HsvColor _controlsColor = GetDefaultThemeColor(ControlsProperty);
        
        static PlexColorScheme()
        {
            ChromeProperty.Changed.AddClassHandler<PlexColorScheme>(OnColorHuePropertiesChanged);
            ToolsMenuAreaProperty.Changed.AddClassHandler<PlexColorScheme>(OnColorHuePropertiesChanged);
            BackgroundProperty.Changed.AddClassHandler<PlexColorScheme>(OnColorHuePropertiesChanged);
            ControlsProperty.Changed.AddClassHandler<PlexColorScheme>(OnColorHuePropertiesChanged);
        }

        static void OnColorHuePropertiesChanged(AvaloniaObject sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (sender is PlexColorScheme scheme)
                scheme.RefreshColorProperty(e.Property.Name, (int)e.NewValue);
        }*/


        public PlexColorScheme(HsvColor chrome, HsvColor toolsMenuArea, HsvColor background, HsvColor controls, PlexColorMode mode)
        {
            Chrome = chrome;
            ToolsMenuArea = toolsMenuArea;
            Background = background; // + 7);
            Controls = controls; // - 5);

            ColorMode = mode;
        }
        /*public PlexColorScheme(byte chrome, byte toolsMenuArea, byte background, byte controls)
            : this(chrome, toolsMenuArea, background, controls, DEFAULT_COLOR_MODE)
        { }*/
        public PlexColorScheme(double hue, double saturation, PlexColorMode mode)
            : this(new HsvColor(hue, saturation), new HsvColor(hue, saturation), new HsvColor(hue + 7, saturation), new HsvColor(hue - 5, saturation), mode)
        { }

        public PlexColorScheme(double hue, PlexColorMode mode)
            : this(hue, 0xFF, mode)
        { }
        /*public PlexColorScheme(byte hue)
            :this(hue, DEFAULT_COLOR_MODE)
        { }*/


        static byte EnsureHue(int potentiallyInvalidHue)
        {
            int retVal = potentiallyInvalidHue;
            
            while (retVal > byte.MaxValue)
                retVal -= byte.MaxValue;
            
            while (retVal < byte.MinValue)
                retVal += byte.MaxValue;
            
            return (byte)retVal;
        }

        /*void RefreshColorProperty(string propertyName, int newHue)
        {
            //Console.WriteLine($"hue: {newHue}");
            int real = Math.Max(0, Math.Min((newHue + 1) - 1, 249));
            byte newValue = (byte)real; //(byte)Math.Max(0, Math.Min(newHue, 255));

            if (propertyName == ChromeProperty.Name)
                _chromeColor = new HsvColor(newValue, 53, 96);
            else if (propertyName == ToolsMenuAreaProperty.Name)
                _toolsMenuAreaColor = new HsvColor(newValue, 53, 85);
            else if (propertyName == BackgroundProperty.Name)
                _backgroundColor = new HsvColor(newValue, 12, 90);
            else if (propertyName == ControlsProperty.Name)
                _controlsColor = new HsvColor(newValue, 62, 99);
            else
                throw new Exception($"Incorrect property: {propertyName}");
        }*/


        public bool HasColor(string key)
        {
            return (key == nameof(Chrome)) ||
            (key == nameof(ToolsMenuArea)) ||
            (key == nameof(Background)) ||
            (key == nameof(Controls));
        }

        public bool TryGetColor(string key, out HsvColor color)
        {
            color = this[key];
            return HasColor(key);
        }
        
        public HsvColor this[string key]
        {
            get
            {
                if (key == nameof(Chrome))
                    return Chrome;
                else if (key == nameof(ToolsMenuArea))
                    return ToolsMenuArea;
                else if (key == nameof(Background))
                    return Background;
                else if (key == nameof(Controls))
                    return Controls;
                else
                    return null;
            }
        }

        public T GetParameter<T>(string key)
        {
            /*bool sameType = typeof(T) == typeof(PlexColorMode);
            bool sameKey = key == PlexTheme.SCM_P_CLMD;
            Console.WriteLine($"key: {key}\nT: {typeof(T).FullName}\n\tsameType: {sameType}\n\tsameKey: {sameKey}");*/

            if ((typeof(T) == typeof(PlexColorMode)) && (key == PlexTheme.SCM_P_CLMD))
                return (T)((object)ColorMode);
            else
                return default(T);
        }

        public bool HasParameter<T>(string key)
        {
            return key == nameof(ColorMode);
        }

        public bool TryGetParameter<T>(string key, out T value)
        {
            bool has = HasParameter<T>(key);
            value = has ? GetParameter<T>(key) : default(T);
            return has;
        }

        /*public static PlexColorScheme Parse(string inText)
        {
            PlexColorMode mode = DEFAULT_COLOR_MODE;

            if (string.IsNullOrEmpty(inText) || string.IsNullOrWhiteSpace(inText))
                throw new Exception($"Can't parse a {nameof(PlexColorScheme)} from nothing.");

            string inStr = inText;

            if ((inStr.Last() != ';') && (inStr.Count(x => x == ';') == 1))
            {
                int sclnIndex = inStr.IndexOf(';');
                string colorModeStr = inStr.Substring(0, sclnIndex);
                if (Enum.TryParse<PlexColorMode>(colorModeStr, out mode))
                    inStr = inStr.Substring(sclnIndex + 1);
                else
                    throw new Exception($"'{colorModeStr}' is not a valid '{nameof(PlexColorMode)}'.");
            }


            if (inStr.Contains(' '))
                inStr = inStr.Replace(' ', ',');
            
            string[] hueVals =
            {
                inStr
            };
            
            if (inStr.Contains(','))
                hueVals = inStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            
            bool uniformHue = hueVals.Length == 1;
            bool individualHues = hueVals.Length == 4;
            
            if (uniformHue || individualHues)
            {
                if (!byte.TryParse(hueVals[0], out byte chromeOrUniformHue))
                    throw new Exception($"'{hueVals[0]}' is not a valid byte.");
                else
                {
                    if (uniformHue)
                        return new PlexColorScheme(chromeOrUniformHue, mode);
                    else if (individualHues)
                    {
                        if (!byte.TryParse(hueVals[1], out byte toolsMenuAreaHue))
                            throw new Exception($"'{hueVals[1]}' is not a valid byte.");
                        
                        if (byte.TryParse(hueVals[2], out byte backgroundHue))
                            throw new Exception($"'{hueVals[2]}' is not a valid byte.");

                        if (!byte.TryParse(hueVals[3], out byte controlsHue))
                            throw new Exception($"'{hueVals[3]}' is not a valid byte.");
                        else
                            return new PlexColorScheme(chromeOrUniformHue, toolsMenuAreaHue, backgroundHue, controlsHue);
                    }
                }
            }
            throw new Exception($"A '{nameof(PlexColorScheme)}' contains 4 colors - "
            + "One hue for each color or one hue for all colors is required. "
            + $"You specified {hueVals.Length} hues, which is neither. "
            + "Don't do that, ok?");
            
            
            
            
            throw new Exception("...are you Desmond the Moon Bear or something? How did you get here?");
        }*/
    }
}
#endif