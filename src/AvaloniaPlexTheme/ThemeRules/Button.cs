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
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(29), value: Over100ToOver255(59)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, saturation: Over100ToOver255(33), value: Over100ToOver255(56)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, saturation: Over100ToOver255(36), value: Over100ToOver255(53)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(37), value: Over100ToOver255(52)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(29), value: Over100ToOver255(58))
                        },
                        new LinearGradientBrushThemeRule("Background1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(20), value: Over100ToOver255(75)),
                            new GradientStopThemeRule(SCM_CTRL, 0.75, saturation: Over100ToOver255(32), value: Over100ToOver255(74)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(75))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(58), value: Over100ToOver255(39)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(79), value: Over100ToOver255(23)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(58), value: Over100ToOver255(39))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(23), value: Over100ToOver255(57)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(1), value: Over100ToOver255(73)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(23), value: Over100ToOver255(57))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(11), value: Over100ToOver255(63)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(75))
                        }
                    },
                    new ThemeRuleGroup("Hover")
                    {
                        new LinearGradientBrushThemeRule("Background0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(29), value: Over100ToOver255(84)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, saturation: Over100ToOver255(33), value: Over100ToOver255(71)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, saturation: Over100ToOver255(36), value: Over100ToOver255(68)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(37), value: Over100ToOver255(67)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(29), value: Over100ToOver255(73))
                        },
                        new LinearGradientBrushThemeRule("Background1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(85)),
                            new GradientStopThemeRule(SCM_CTRL, 0.75, saturation: Over100ToOver255(12), value: Over100ToOver255(85)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(85))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(58), value: Over100ToOver255(54)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(79), value: Over100ToOver255(48)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(58), value: Over100ToOver255(54))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(23), value: Over100ToOver255(82)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(1), value: Over100ToOver255(73)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(23), value: Over100ToOver255(82))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(11), value: Over100ToOver255(63)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(75))
                        }
                        /*new LinearGradientBrushThemeRule("BorderBrush0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(74), value: Over100ToOver255(100)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(78), value: Over100ToOver255(75)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(74), value: Over100ToOver255(100))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(26), value: Over100ToOver255(99)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(0), value: Over100ToOver255(99)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(26), value: Over100ToOver255(99))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(7), value: Over100ToOver255(99)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(100))
                        }*/
                    },
                    new ThemeRuleGroup("Disabled")
                    {
                        new LinearGradientBrushThemeRule("Background0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(35)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, saturation: Over100ToOver255(0), value: Over100ToOver255(31)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, saturation: Over100ToOver255(0), value: Over100ToOver255(28)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(0), value: Over100ToOver255(24)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(39))
                        },
                        new LinearGradientBrushThemeRule("Background1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(51)),
                            new GradientStopThemeRule(SCM_CTRL, 0.75, saturation: Over100ToOver255(0), value: Over100ToOver255(45)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(60))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(1)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(0), value: Over100ToOver255(0 /*-1*/)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(5))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(35)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(0), value: Over100ToOver255(42)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(40))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(44)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(60))
                        },
                        new SolidColorBrushThemeRule("Foreground", SCM_CTRL, saturation: Over100ToOver255(0), value: Over100ToOver255(80)),
                    },
                    new SolidColorBrushThemeRule("Foreground", SCM_CTRL, saturation: Over100ToOver255(8), value: Over100ToOver255(100)),
                },

                FalseValue = 
                new ThemeRuleGroup(string.Empty)
                {
                    new ThemeRuleGroup("Idle")
                    {
                        new LinearGradientBrushThemeRule("Background0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(42), value: Over100ToOver255(99)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, saturation: Over100ToOver255(51), value: Over100ToOver255(99)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, saturation: Over100ToOver255(57), value: Over100ToOver255(99)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(61), value: Over100ToOver255(99)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(42), value: Over100ToOver255(99))
                        },
                        new LinearGradientBrushThemeRule("Background1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(20), value: Over100ToOver255(100)),
                            new GradientStopThemeRule(SCM_CTRL, 0.75, saturation: Over100ToOver255(32), value: Over100ToOver255(99)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(100))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(94), value: Over100ToOver255(99)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(98), value: Over100ToOver255(74)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(94), value: Over100ToOver255(99))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(46), value: Over100ToOver255(99)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(3), value: Over100ToOver255(99)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(46), value: Over100ToOver255(99))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(27), value: Over100ToOver255(99)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(100))
                        }
                    },
                    new ThemeRuleGroup("Hover")
                    {
                        new LinearGradientBrushThemeRule("Background0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(22), value: Over100ToOver255(100)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, saturation: Over100ToOver255(31), value: Over100ToOver255(100)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, saturation: Over100ToOver255(37), value: Over100ToOver255(100)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(41), value: Over100ToOver255(100)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(22), value: Over100ToOver255(100))
                        },
                        new LinearGradientBrushThemeRule("Background1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(100)),
                            new GradientStopThemeRule(SCM_CTRL, 0.75, saturation: Over100ToOver255(12), value: Over100ToOver255(100)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(100))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(74), value: Over100ToOver255(100)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(78), value: Over100ToOver255(75)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(74), value: Over100ToOver255(100))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(26), value: Over100ToOver255(99)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(0), value: Over100ToOver255(99)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(26), value: Over100ToOver255(99))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(7), value: Over100ToOver255(99)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(100))
                        }
                    },
                    new ThemeRuleGroup("Disabled")
                    {
                        new LinearGradientBrushThemeRule("Background0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(75)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, saturation: Over100ToOver255(0), value: Over100ToOver255(71)),
                            new GradientStopThemeRule(SCM_CTRL, 0.375, saturation: Over100ToOver255(0), value: Over100ToOver255(68)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(0), value: Over100ToOver255(64)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(79))
                        },
                        new LinearGradientBrushThemeRule("Background1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(91)),
                            new GradientStopThemeRule(SCM_CTRL, 0.75, saturation: Over100ToOver255(0), value: Over100ToOver255(85)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(100))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush0", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(41)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(0), value: Over100ToOver255(34)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(45))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush1", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(75)),
                            new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(0), value: Over100ToOver255(82)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(80))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(84)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(100))
                        },
                        new SolidColorBrushThemeRule("Foreground", SCM_CTRL, saturation: Over100ToOver255(0), value: Over100ToOver255(18)),
                    },
                    new SolidColorBrushThemeRule("Foreground", SCM_CTRL, saturation: Over100ToOver255(96), value: Over100ToOver255(30)),
                },
            },
            new ThemeRuleGroup("Pressed")
            {
                new LinearGradientBrushThemeRule("Background", new RelativePoint(0, 1, RelativeUnit.Relative))
                {
                    new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(44), value: Over100ToOver255(80)),
                    new GradientStopThemeRule(SCM_CTRL, 0.375, saturation: Over100ToOver255(53), value: Over100ToOver255(84)),
                    new GradientStopThemeRule(SCM_CTRL, 0.375, saturation: Over100ToOver255(57), value: Over100ToOver255(79)),
                    new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(61), value: Over100ToOver255(79)),
                    new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(42), value: Over100ToOver255(81))
                },
                new LinearGradientBrushThemeRule("BorderBrush", new RelativePoint(0, 1, RelativeUnit.Relative))
                {
                    new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(94), value: Over100ToOver255(59)),
                    new GradientStopThemeRule(SCM_CTRL, 0.625, saturation: Over100ToOver255(98), value: Over100ToOver255(34)),
                    new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(94), value: Over100ToOver255(59))
                },
                new SolidColorBrushThemeRule("Foreground", SCM_CTRL, saturation: Over100ToOver255(22), value: Over100ToOver255(96)),
            }
        };
    }
}