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
        const string SCM_CHRM = "Chrome";
        const string SCM_TMNA = "ToolsMenu";
        const string SCM_CLBG = "Background";
        const string SCM_CTRL = "Controls";

        static readonly ThemeRules _themeRules = new ThemeRules()
        {
            new ThemeRuleGroup("Window")
            {
                new LinearGradientBrushThemeRule("Background", new RelativePoint(0, 1, RelativeUnit.Relative))
                {
                    new GradientStopThemeRule(SCM_CLBG, 0, saturation: 0, value: Over100ToOver255(100)),
                    new GradientStopThemeRule(SCM_CLBG, 1, saturation: Over100ToOver255(16), value: Over100ToOver255(91)), //Over100ToOver255(91)),
                },
                new SolidColorBrushThemeRule("Foreground", SCM_CLBG, saturation: 0, value: Over100ToOver255(100), generateContrastForForeground: true),
                new ThemeRuleGroup("TitleBar")
                {
                    new LinearGradientBrushThemeRule("BottomBorderBrush", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_CHRM, 0, saturation: Over100ToOver255(56), value: Over100ToOver255(69)),
                        new GradientStopThemeRule(SCM_CHRM, 1, saturation: Over100ToOver255(58), value: Over100ToOver255(70)),
                    }
                    //new SolidColorBrushThemeRule("BottomBorderBrush", SCM_CHRM, saturation: Over100ToOver255(58), value: Over100ToOver255(70))
                },
                new ThemeRuleGroup("ActiveTitleBar")
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_CHRM, 0, saturation: Over100ToOver255(63), value: Over100ToOver255(83)),
                        new GradientStopThemeRule(SCM_CHRM, 1, saturation: Over100ToOver255(53), value: Over100ToOver255(96)),
                    },
                    new LinearGradientBrushThemeRule("BorderBrush", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_CHRM, 0, saturation: Over100ToOver255(32), value: Over100ToOver255(97), alpha: 0),
                        new GradientStopThemeRule(SCM_CHRM, 1, saturation: Over100ToOver255(32), value: Over100ToOver255(97)),
                    },
                    new SolidColorBrushThemeRule("Foreground", SCM_CHRM, saturation: Over100ToOver255(0), value: Over100ToOver255(100))
                },
                new ThemeRuleGroup("InactiveTitleBar")
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_CHRM, 0, saturation: Over100ToOver255(63), value: Over100ToOver255(73)),
                        new GradientStopThemeRule(SCM_CHRM, 1, saturation: Over100ToOver255(53), value: Over100ToOver255(84)),
                    },
                    new LinearGradientBrushThemeRule("BorderBrush", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_CHRM, 0, saturation: Over100ToOver255(36), value: Over100ToOver255(85), alpha: 0),
                        new GradientStopThemeRule(SCM_CHRM, 1, saturation: Over100ToOver255(36), value: Over100ToOver255(85)),
                    },
                    new SolidColorBrushThemeRule("Foreground", SCM_CHRM, saturation: Over100ToOver255(0), value: Over100ToOver255(100))
                },
                new ThemeRuleGroup("CaptionButton")
                {
                    new SolidColorBrushThemeRule("Stroke", SCM_CHRM, saturation: Over100ToOver255(0), value: Over100ToOver255(0), alpha: 64),
                    new SolidColorBrushThemeRule("ActiveIdle", SCM_CHRM, saturation: Over100ToOver255(23), value: Over100ToOver255(100)),
                    new SolidColorBrushThemeRule("InactiveIdle", SCM_CHRM, saturation: Over100ToOver255(34), value: Over100ToOver255(82)),
                    new SolidColorBrushThemeRule("Hover", SCM_CHRM, saturation: Over100ToOver255(0), value: Over100ToOver255(100)),
                    new SolidColorBrushThemeRule("Pressed", SCM_CHRM, saturation: Over100ToOver255(34), value: Over100ToOver255(82)),
                }
            },
            new ThemeRuleGroup("ToolsMenuArea")
            {
                new LinearGradientBrushThemeRule("Background", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                {
                    new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(67), value: Over100ToOver255(69)),
                    new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(56), value: Over100ToOver255(85)),
                },
                new SolidColorBrushThemeRule("SideBorderBrush", SCM_TMNA, Over100ToOver255(67), value: Over100ToOver255(69)),
                new LinearGradientBrushThemeRule("BottomBorderBrush0", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                {
                    new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(67), value: Over100ToOver255(69)),
                    new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(56), value: Over100ToOver255(85)),
                },
                new LinearGradientBrushThemeRule("BottomBorderBrush1", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                {
                    new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(58), value: Over100ToOver255(82)),
                    new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(49), value: Over100ToOver255(98)),
                },
                new LinearGradientBrushThemeRule("BottomBorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                {
                    new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(66), value: Over100ToOver255(69)),
                    new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(74), value: Over100ToOver255(60)),
                },
                new SolidColorBrushThemeRule("Foreground", SCM_TMNA, saturation: Over100ToOver255(0), value: Over100ToOver255(100))
            },
            new ThemeRuleGroup("ToolsMenuAreaControl")
            {
                new LinearGradientBrushThemeRule("BorderBrush0", new RelativePoint(0, 1, RelativeUnit.Relative))
                {
                    new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(63), value: Over100ToOver255(76)),
                    new GradientStopThemeRule(SCM_TMNA, 0.5, saturation: Over100ToOver255(62), value: Over100ToOver255(80)),
                    new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(58), value: Over100ToOver255(83)),
                },
                new LinearGradientBrushThemeRule("BorderBrush1", new RelativePoint(0, 1, RelativeUnit.Relative))
                {
                    new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(38), value: Over100ToOver255(85), alpha: 0),
                    new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(38), value: Over100ToOver255(85)),
                },
                new LinearGradientBrushThemeRule("BorderBrush2", new RelativePoint(0, 1, RelativeUnit.Relative))
                {
                    new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(63), value: Over100ToOver255(76)),
                    new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(63), value: Over100ToOver255(50)),
                },
                new ThemeRuleGroup("Hover")
                {
                    new LinearGradientBrushThemeRule("Background0", new RelativePoint(0.5, 1, RelativeUnit.Relative), new RelativePoint(0.96875, 0.9375, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(20), value: Over100ToOver255(98)),
                        new GradientStopThemeRule(SCM_TMNA, 0.5, saturation: Over100ToOver255(35), value: Over100ToOver255(93)),
                        new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(37), value: Over100ToOver255(91)),
                    },
                    new LinearGradientBrushThemeRule("Background1", new RelativePoint(0.125, 0, RelativeUnit.Relative), new RelativePoint(0, 0.625, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(49), value: Over100ToOver255(80)),
                        new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(49), value: Over100ToOver255(80), alpha: 0),
                    },
                    new SolidColorBrushThemeRule("Foreground", SCM_TMNA, saturation: Over100ToOver255(0), value: Over100ToOver255(0))
                },
                new ThemeRuleGroup("Pressed")
                {
                    new SolidColorBrushThemeRule("Background", SCM_TMNA, saturation: Over100ToOver255(63), value: Over100ToOver255(83))
                },  
            },
            new ThemeRuleGroup("Button")
            {
                new ThemeRuleGroup("Idle")
                {
                    new LinearGradientBrushThemeRule("Background0", new RelativePoint(0, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(44), value: Over100ToOver255(99)),
                        new GradientStopThemeRule(SCM_CTRL, 0.375, saturation: Over100ToOver255(53), value: Over100ToOver255(99)),
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
                        new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(24), value: Over100ToOver255(100)),
                        new GradientStopThemeRule(SCM_CTRL, 0.375, saturation: Over100ToOver255(33), value: Over100ToOver255(100)),
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
                    }
                },
                new SolidColorBrushThemeRule("Foreground", SCM_CTRL, saturation: Over100ToOver255(88), value: Over100ToOver255(34)),
            },
            new ThemeRuleGroup("CheckBox")
            {
                new ThemeRuleGroup("Idle")
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(1, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(2), value: Over100ToOver255(86)),
                        new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(100))
                    },
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, saturation: Over100ToOver255(78), value: Over100ToOver255(50)),
                    new SolidColorBrushThemeRule("CheckMark", SCM_CTRL, saturation: Over100ToOver255(79), value: Over100ToOver255(63))
                },
                new ThemeRuleGroup("Hover")
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(1, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(2), value: Over100ToOver255(100)),
                        new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(100))
                    },
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, saturation: Over100ToOver255(93), value: Over100ToOver255(50)),
                    new SolidColorBrushThemeRule("CheckMark", SCM_CTRL, saturation: Over100ToOver255(94), value: Over100ToOver255(78))
                },
                new ThemeRuleGroup("Pressed")
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(1, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(2), value: Over100ToOver255(76)),
                        new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(90))
                    },
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, saturation: Over100ToOver255(78), value: Over100ToOver255(40)),
                    new SolidColorBrushThemeRule("CheckMark", SCM_CTRL, saturation: Over100ToOver255(79), value: Over100ToOver255(53))
                },
                new ThemeRuleGroup("Disabled")
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(1, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(68)),
                        new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(80))
                    },
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, saturation: Over100ToOver255(0), value: Over100ToOver255(27)),
                    new SolidColorBrushThemeRule("CheckMark", SCM_CTRL, saturation: Over100ToOver255(0), value: Over100ToOver255(42))
                },
                new ThemeRuleGroup("ToolsMenuArea")
                {
                    new ThemeRuleGroup("Idle")
                    {
                        new SolidColorBrushThemeRule("Background", SCM_CTRL, saturation: Over100ToOver255(63), value: Over100ToOver255(56)),
                        new SolidColorBrushThemeRule("BorderBrush0", SCM_CTRL, saturation: Over100ToOver255(63), value: Over100ToOver255(46)),
                        new SolidColorBrushThemeRule("BorderBrush1", SCM_CTRL, saturation: Over100ToOver255(29), value: Over100ToOver255(100)), //Over100ToOver255(63), value: Over100ToOver255(46)),
                        new SolidColorBrushThemeRule("CheckMark", SCM_CTRL, saturation: Over100ToOver255(0), value: Over100ToOver255(100))
                    }
                }
            },
            new ThemeRuleGroup("TextBox")
            {
                new ThemeRuleGroup("Idle")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, saturation: Over100ToOver255(0), value: Over100ToOver255(100)),
                    new LinearGradientBrushThemeRule("BorderBrush", new RelativePoint(0, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(13), value: Over100ToOver255(80)),
                        new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(12), value: Over100ToOver255(97))
                    },
                    new SolidColorBrushThemeRule("Watermark", SCM_CTRL, saturation: Over100ToOver255(50), value: Over100ToOver255(57)),
                    new SolidColorBrushThemeRule("Foreground", SCM_CTRL, saturation: Over100ToOver255(50), value: Over100ToOver255(17)),
                }
            },
            new ThemeRuleGroup("ToggleSwitch")
            {
                new ThemeRuleGroup("Thumb")
                {
                    new ThemeRuleGroup("Idle")
                    {
                        //new SolidColorBrushThemeRule("Background0", SCM_CTRL, saturation: Over100ToOver255(57), value: Over100ToOver255(84)),
                        new LinearGradientBrushThemeRule("Background", new RelativePoint(0.625, 0.25, RelativeUnit.Relative), new RelativePoint(0.375, 0.625, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(24), value: Over100ToOver255(92)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(57), value: Over100ToOver255(84))
                        },
                        new LinearGradientBrushThemeRule("BorderBrush", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(13), value: Over100ToOver255(80)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(12), value: Over100ToOver255(97))
                        }
                    },
                    new ThemeRuleGroup("Hover")
                    {
                        new LinearGradientBrushThemeRule("Background", new RelativePoint(0.625, 0.25, RelativeUnit.Relative), new RelativePoint(0.375, 0.625, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(17), value: Over100ToOver255(100)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(57), value: Over100ToOver255(99))
                        }
                    },
                    new ThemeRuleGroup("Pressed")
                    {
                        new LinearGradientBrushThemeRule("Background", new RelativePoint(0.625, 0.25, RelativeUnit.Relative), new RelativePoint(0.375, 0.625, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(44), value: Over100ToOver255(92)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(77), value: Over100ToOver255(84))
                        }
                    },
                    new ThemeRuleGroup("Checked")
                    {
                        /*new LinearGradientBrushThemeRule("Background", new RelativePoint(0.625, 0.25, RelativeUnit.Relative), new RelativePoint(0.375, 0.625, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(34), value: Over100ToOver255(92)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(67), value: Over100ToOver255(84))
                        },*/
                        new LinearGradientBrushThemeRule("BorderBrush", new RelativePoint(0, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(13), value: Over100ToOver255(70)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(12), value: Over100ToOver255(87))
                        }
                    }
                },
                new ThemeRuleGroup("Track")
                {
                    new ThemeRuleGroup("Idle")
                    {
                        new SolidColorBrushThemeRule("Background", SCM_CTRL, saturation: Over100ToOver255(0), value: Over100ToOver255(100)),
                        new SolidColorBrushThemeRule("Watermark", SCM_CTRL, saturation: Over100ToOver255(50), value: Over100ToOver255(57)),
                        new SolidColorBrushThemeRule("Foreground", SCM_CTRL, saturation: Over100ToOver255(50), value: Over100ToOver255(17)),
                    },
                    new ThemeRuleGroup("Hover")
                    {
                        new SolidColorBrushThemeRule("Background", SCM_CTRL, saturation: Over100ToOver255(16), value: Over100ToOver255(95)),
                    },
                    new ThemeRuleGroup("Pressed")
                    {
                        new SolidColorBrushThemeRule("Background", SCM_CTRL, saturation: Over100ToOver255(16), value: Over100ToOver255(85)),
                    },
                    new ThemeRuleGroup("Checked")
                    {
                        new LinearGradientBrushThemeRule("Background", new RelativePoint(1, 0, RelativeUnit.Relative), new RelativePoint(0.5, 1, RelativeUnit.Relative))
                        {
                            new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(19), value: Over100ToOver255(89)),
                            new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(100))
                        }
                    },
                    new LinearGradientBrushThemeRule("BorderBrush", new RelativePoint(0, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(13), value: Over100ToOver255(70)),
                        new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(12), value: Over100ToOver255(87))
                    }
                }
            },
            new ThemeRuleGroup("Menu")
            {
                new SolidColorBrushThemeRule("Foreground", SCM_CLBG, saturation: Over100ToOver255(77), value: Over100ToOver255(58)),
                new ThemeRuleGroup("ToolsMenuArea")
                {
                    new SolidColorBrushThemeRule("Foreground", SCM_TMNA, saturation: Over100ToOver255(39), value: Over100ToOver255(99))
                },
            },
            new ThemeRuleGroup("MenuItem")
            {
                new ThemeRuleGroup("Hover")
                {
                    new LinearGradientBrushThemeRule("Background0", new RelativePoint(0.5, 1, RelativeUnit.Relative), new RelativePoint(0.96875, 0.9375, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(20), value: Over100ToOver255(98)),
                        new GradientStopThemeRule(SCM_CTRL, 0.5, saturation: Over100ToOver255(35), value: Over100ToOver255(93)),
                        new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(37), value: Over100ToOver255(91)),
                    },
                    new LinearGradientBrushThemeRule("Background1", new RelativePoint(0.125, 0, RelativeUnit.Relative), new RelativePoint(0, 0.625, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(49), value: Over100ToOver255(80)),
                        new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(49), value: Over100ToOver255(80), alpha: 0),
                    }
                },
                new ThemeRuleGroup("Pressed")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, saturation: Over100ToOver255(63), value: Over100ToOver255(83))
                }
            }
        };
    }
}