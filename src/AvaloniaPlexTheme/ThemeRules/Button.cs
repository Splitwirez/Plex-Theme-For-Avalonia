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
        static readonly IThemeRule 
         _buttonRules =
        new ThemeRuleGroup("Button")
        {
            new IfElseRule<PlexColorMode>(SCM_P_CLMD, PlexColorMode.Dark)
            {
                TrueValue = 
                new ThemeRuleGroup(string.Empty)
                {
                    new ThemeRuleGroup("Idle")
                    {
                        new LinearGradientBrushThemeRule("Background0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(29, 59)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, FilterSaturationAndValue(33, 56)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, FilterSaturationAndValue(36, 53)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(37, 52)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(29, 58))
                        },
                        new LinearGradientBrushThemeRule("Background1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(20, 75)),
                            new GradientStopThemeRule(SCM_CTRL, 0.75, FilterSaturationAndValue(32, 74)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 75))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(58, 39)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(79, 23)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(58, 39))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(23, 57)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(1, 73)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(23, 57))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(11, 63)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 75))
                        }
                    },
                    new ThemeRuleGroup("Hover")
                    {
                        new LinearGradientBrushThemeRule("Background0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(29, 84)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, FilterSaturationAndValue(33, 71)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, FilterSaturationAndValue(36, 68)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(37, 67)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(29, 73))
                        },
                        new LinearGradientBrushThemeRule("Background1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 85)),
                            new GradientStopThemeRule(SCM_CTRL, 0.75, FilterSaturationAndValue(12, 85)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 85))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(58, 54)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(79, 48)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(58, 54))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(23, 82)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(1, 73)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(23, 82))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(11, 63)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 75))
                        }
                        /*new LinearGradientBrushThemeRule("BorderBrush0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(74, 100)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(78, 75)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(74, 100))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(26, 99)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(0, 99)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(26, 99))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(7, 99)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 100))
                        }*/
                    },
                    new ThemeRuleGroup("Disabled")
                    {
                        new LinearGradientBrushThemeRule("Background0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 35)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, FilterSaturationAndValue(0, 31)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, FilterSaturationAndValue(0, 28)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(0, 24)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 39))
                        },
                        new LinearGradientBrushThemeRule("Background1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 51)),
                            new GradientStopThemeRule(SCM_CTRL, 0.75, FilterSaturationAndValue(0, 45)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 60))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 1)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(0, 0 /*-1*/)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 5))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 35)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(0, 42)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 40))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 44)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 60))
                        },
                        new SolidColorBrushThemeRule("Foreground", SCM_CTRL, FilterSaturationAndValue(0, 80)),
                    },
                    new SolidColorBrushThemeRule("Foreground", SCM_CTRL, FilterSaturationAndValue(8, 100)),
                },

                FalseValue = 
                new ThemeRuleGroup(string.Empty)
                {
                    new ThemeRuleGroup("Idle")
                    {
                        new LinearGradientBrushThemeRule("Background0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(42, 99)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, FilterSaturationAndValue(51, 99)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, FilterSaturationAndValue(57, 99)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(61, 99)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(42, 99))
                        },
                        new LinearGradientBrushThemeRule("Background1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(20, 100)),
                            new GradientStopThemeRule(SCM_CTRL, 0.75, FilterSaturationAndValue(32, 99)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 100))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(94, 99)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(98, 74)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(94, 99))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(46, 99)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(3, 99)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(46, 99))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(27, 99)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 100))
                        }
                    },
                    new ThemeRuleGroup("Hover")
                    {
                        new LinearGradientBrushThemeRule("Background0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(22, 100)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, FilterSaturationAndValue(31, 100)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, FilterSaturationAndValue(37, 100)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(41, 100)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(22, 100))
                        },
                        new LinearGradientBrushThemeRule("Background1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 100)),
                            new GradientStopThemeRule(SCM_CTRL, 0.75, FilterSaturationAndValue(12, 100)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 100))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(74, 100)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(78, 75)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(74, 100))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(26, 99)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(0, 99)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(26, 99))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(7, 99)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 100))
                        }
                    },
                    new ThemeRuleGroup("Disabled")
                    {
                        new LinearGradientBrushThemeRule("Background0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 75)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, FilterSaturationAndValue(0, 71)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, FilterSaturationAndValue(0, 68)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(0, 64)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 79))
                        },
                        new LinearGradientBrushThemeRule("Background1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 91)),
                            new GradientStopThemeRule(SCM_CTRL, 0.75, FilterSaturationAndValue(0, 85)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 100))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 41)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(0, 34)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 45))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 75)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(0, 82)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 80))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 84)),
                            new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 100))
                        },
                        new SolidColorBrushThemeRule("Foreground", SCM_CTRL, FilterSaturationAndValue(0, 18)),
                    },
                    new SolidColorBrushThemeRule("Foreground", SCM_CTRL, FilterSaturationAndValue(96, 30)),
                },
            },
            new ThemeRuleGroup("Pressed")
            {
                new LinearGradientBrushThemeRule("Background", new RelativePoint(0, 1, RelativeUnit.Relative))
                {
                    new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(44, 80)),
                    new GradientStopThemeRule(SCM_CTRL, 0.375, FilterSaturationAndValue(53, 84)),
                    new GradientStopThemeRule(SCM_CTRL, 0.375, FilterSaturationAndValue(57, 79)),
                    new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(61, 79)),
                    new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(42, 81))
                },
                new LinearGradientBrushThemeRule("BorderBrush", new RelativePoint(0, 1, RelativeUnit.Relative))
                {
                    new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(94, 59)),
                    new GradientStopThemeRule(SCM_CTRL, 0.625, FilterSaturationAndValue(98, 34)),
                    new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(94, 59))
                },
                new SolidColorBrushThemeRule("Foreground", SCM_CTRL, FilterSaturationAndValue(22, 96)),
            }
        };
    }
}
