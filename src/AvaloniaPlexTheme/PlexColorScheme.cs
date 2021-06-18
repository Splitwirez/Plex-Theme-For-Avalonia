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


        public static readonly StyledProperty<byte> ChromeProperty =
            AvaloniaProperty.Register<PlexColorScheme, byte>(nameof(Chrome), 210);
        public byte Chrome
        {
            get => GetValue(ChromeProperty);
            set => SetValue(ChromeProperty, value);
        }

        public static readonly StyledProperty<byte> ToolsMenuAreaProperty =
            AvaloniaProperty.Register<PlexColorScheme, byte>(nameof(ToolsMenuArea), 210);
        public byte ToolsMenuArea
        {
            get => GetValue(ToolsMenuAreaProperty);
            set => SetValue(ToolsMenuAreaProperty, value);
        }

        public static readonly StyledProperty<byte> BackgroundProperty =
            AvaloniaProperty.Register<PlexColorScheme, byte>(nameof(Background), 217);
        public byte Background
        {
            get => GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }

        public static readonly StyledProperty<byte> ControlsProperty =
            AvaloniaProperty.Register<PlexColorScheme, byte>(nameof(Controls), 205);
        public byte Controls
        {
            get => GetValue(ControlsProperty);
            set => SetValue(ControlsProperty, value);
        }


        public static readonly StyledProperty<PlexColorMode> ColorModeProperty =
            AvaloniaProperty.Register<PlexColorScheme, PlexColorMode>(nameof(ColorMode), DEFAULT_COLOR_MODE);
        public PlexColorMode ColorMode
        {
            get => GetValue(ColorModeProperty);
            set => SetValue(ColorModeProperty, value);
        }


        static ThemeColor GetDefaultThemeColor(StyledProperty<byte> property) =>
            new ThemeColor(property.GetDefaultValue(typeof(byte)));
        
        ThemeColor _chromeColor = GetDefaultThemeColor(ChromeProperty);
        ThemeColor _toolsMenuAreaColor = GetDefaultThemeColor(ToolsMenuAreaProperty);
        ThemeColor _backgroundColor = GetDefaultThemeColor(BackgroundProperty);
        ThemeColor _controlsColor = GetDefaultThemeColor(ControlsProperty);
        
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
                scheme.RefreshColorProperty(e.Property.Name, (byte)e.NewValue);
        }


        public PlexColorScheme(byte chrome, byte toolsMenuArea, byte background, byte controls, PlexColorMode mode)
        {
            Chrome = EnsureHue(chrome);
            ToolsMenuArea = EnsureHue(toolsMenuArea);
            Background = EnsureHue(background + 7);
            Controls = EnsureHue(controls - 5);

            ColorMode = mode;
        }
        public PlexColorScheme(byte chrome, byte toolsMenuArea, byte background, byte controls)
            : this(chrome, toolsMenuArea, background, controls, DEFAULT_COLOR_MODE)
        { }
        public PlexColorScheme(byte hue, PlexColorMode mode)
            : this(hue, hue, hue, hue, mode)
        { }
        public PlexColorScheme(byte hue)
            :this(hue, DEFAULT_COLOR_MODE)
        { }


        static byte EnsureHue(int potentiallyInvalidHue)
        {
            int retVal = potentiallyInvalidHue;
            
            while (retVal > byte.MaxValue)
                retVal -= byte.MaxValue;
            
            while (retVal < byte.MinValue)
                retVal += byte.MaxValue;
            
            return (byte)retVal;
        }

        void RefreshColorProperty(string propertyName, byte newValue)
        {
            if (propertyName == ChromeProperty.Name)
                _chromeColor = new ThemeColor(newValue, 53, 96);
            else if (propertyName == ToolsMenuAreaProperty.Name)
                _toolsMenuAreaColor = new ThemeColor(newValue, 53, 85);
            else if (propertyName == BackgroundProperty.Name)
                _backgroundColor = new ThemeColor(newValue, 12, 90);
            else if (propertyName == ControlsProperty.Name)
                _controlsColor = new ThemeColor(newValue, 62, 99);
            else
                throw new Exception($"Incorrect property: {propertyName}");
        }


        public bool HasColor(string key)
        {
            return (key == nameof(Chrome)) ||
            (key == nameof(ToolsMenuArea)) ||
            (key == nameof(Background)) ||
            (key == nameof(Controls));
        }

        public bool TryGetColor(string key, out ThemeColor color)
        {
            color = this[key];
            return HasColor(key);
        }
        
        public ThemeColor this[string key]
        {
            get
            {
                if (key == nameof(Chrome))
                    return _chromeColor;
                else if (key == nameof(ToolsMenuArea))
                    return _toolsMenuAreaColor;
                else if (key == nameof(Background))
                    return _backgroundColor;
                else if (key == nameof(Controls))
                    return _controlsColor;
                else
                    return null;
            }
        }

        public T GetParameter<T>(string key)
        {
            if ((typeof(T) == typeof(PlexColorMode)) && (key == nameof(ColorMode)))
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

        public static PlexColorScheme Parse(string inText)
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
        }
    }
}