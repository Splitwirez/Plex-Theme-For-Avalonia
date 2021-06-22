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
    /// <summary>
    /// Includes the plex theme in an application.
    /// </summary>
    public partial class PlexTheme : IStyle, IResourceProvider
    {
        /*const string SCM_CHRM = "Chrome";
        const string SCM_TMNA = "ToolsMenu";
        const string SCM_CLBG = "Background";
        const string SCM_CTRL = "Controls";*/
        internal static readonly string SCM_CHRM = PlexColorScheme.ChromeProperty.Name;
        internal static readonly string SCM_TMNA = PlexColorScheme.ToolsMenuAreaProperty.Name;
        internal static readonly string SCM_CLBG = PlexColorScheme.BackgroundProperty.Name;
        internal static readonly string SCM_CTRL = PlexColorScheme.ControlsProperty.Name;
        internal static readonly string SCM_P_CLMD = PlexColorScheme.ColorModeProperty.Name;



        static readonly ThemeRules _themeRules;
        
        
        static PlexTheme()
        {
            _themeRules = new ThemeRules()
            {
                _buttonRules,
                _captionButtonsRules,
                _checkBoxRules,
                _menuRules,
                _menuItemRules,
                _sliderRules,
                _textBlockRules,
                _textBoxRules,
                _toggleSwitchRules,
                _toolsMenuAreaRules,
                _toolsMenuAreaControlRules,
                _windowRules,
                _windowTitleBarRules

                /*new ThemeRuleGroup("Window")
                {
                    new IfElseRule<PlexColorMode>(SCM_P_CLMD, PlexColorMode.Dark)
                    {
                        TrueValue = 
                        new ThemeRuleGroup(string.Empty)
                        {
                            new LinearGradientBrushThemeRule("Background", new RelativePoint(0, 1, RelativeUnit.Relative))
                            {
                                new GradientStopThemeRule(SCM_CLBG, 0, LockSaturationAndValue(saturation: Over100ToOver255(0), value: Over100ToOver255(18), out object[] bp1), bp1),
                                new GradientStopThemeRule(SCM_CLBG, 1, LockSaturationAndValue(saturation: Over100ToOver255(36), value: Over100ToOver255(0), out object[] bp2), bp2), //saturation: Over100ToOver255(48), value: Over100ToOver255(18)),
                            },
                            new SolidColorBrushThemeRule("Foreground", SCM_CLBG, LockSaturationAndValue(saturation: Over100ToOver255(0), value: Over100ToOver255(100), out object[] bp3), bp3) //saturation: Over100ToOver255(0), value: Over100ToOver255(100))
                        },
                        
                        FalseValue =
                        new ThemeRuleGroup(string.Empty)
                        {
                            new LinearGradientBrushThemeRule("Background", new RelativePoint(0, 1, RelativeUnit.Relative))
                            {
                                new GradientStopThemeRule(SCM_CLBG, 0, LockSaturationAndValue(saturation: Over100ToOver255(0), value: Over100ToOver255(100), out object[] bp4), bp4),
                                new GradientStopThemeRule(SCM_CLBG, 1, LockSaturationAndValue(saturation: Over100ToOver255(16), value: Over100ToOver255(91), out object[] bp5), bp5), //Over100ToOver255(91)),
                            },
                            new SolidColorBrushThemeRule("Foreground", SCM_CLBG, LockSaturationAndValue(saturation: Over100ToOver255(0), value: Over100ToOver255(0), out object[] bp6), bp6)
                        }
                    }
                }*/
            };
        }

        static Func<HsvColor, object[], Color> zLockSaturationAndValue(double saturation, double value, out object[] bonusParams)
        {
            bonusParams = new object[]
            {
                saturation,
                value
            };
            return (schemeColor, sv) => new HsvColor(schemeColor.H, (double)sv[0], (double)sv[1]).ToColor();
        }

        static Func<HsvColor, object[], Color> FilterSaturationAndValue(byte saturation, byte value, byte alpha = 0xFF)
        {
            double s = Over100ToOver255(saturation);
            double v = Over100ToOver255(value);
            return (schemeColor, e) => new HsvColor(schemeColor.H, s * (schemeColor.S / 255), v).ToColor(alpha);
        }

        static double Over100ToOver255(byte over100)
        {
            return /*(byte)*/(((double)over100 / 100.0) * 255.0);
        }
    }
}