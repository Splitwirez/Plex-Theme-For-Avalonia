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
        static readonly IThemeRule _windowTitleBarRules =
        new IfElseRule<PlexColorMode>(SCM_P_CLMD, PlexColorMode.Dark)
        {
            TrueValue = 
            new ThemeRuleGroup("WindowTitleBar")
            {
                new LinearGradientBrushThemeRule("BottomBorderBrush", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                {
                    new GradientStopThemeRule(SCM_CHRM, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(11)), //53
                    new GradientStopThemeRule(SCM_CHRM, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(26)), //68
                },
                new ThemeRuleGroup("Active")
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_CHRM, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(25)), //83
                        new GradientStopThemeRule(SCM_CHRM, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(40)), //96
                    },
                    new LinearGradientBrushThemeRule("BorderBrush", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_CHRM, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(57), alpha: 0), //97
                        new GradientStopThemeRule(SCM_CHRM, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(57)), //97
                    },
                    new SolidColorBrushThemeRule("Foreground", SCM_CHRM, saturation: Over100ToOver255(0), value: Over100ToOver255(100))
                },
                new ThemeRuleGroup("Inactive")
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_CHRM, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(15)), //73
                        new GradientStopThemeRule(SCM_CHRM, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(38)), //84
                    },
                    new LinearGradientBrushThemeRule("BorderBrush", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_CHRM, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(45), alpha: 0), //85
                        new GradientStopThemeRule(SCM_CHRM, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(45)), //85
                    },
                    new SolidColorBrushThemeRule("Foreground", SCM_CHRM, saturation: Over100ToOver255(0), value: Over100ToOver255(90))
                }
            },

            FalseValue =
            new ThemeRuleGroup("WindowTitleBar")
            {
                new LinearGradientBrushThemeRule("BottomBorderBrush", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                {
                    new GradientStopThemeRule(SCM_CHRM, 0, saturation: Over100ToOver255(56), value: Over100ToOver255(53)),
                    new GradientStopThemeRule(SCM_CHRM, 1, saturation: Over100ToOver255(58), value: Over100ToOver255(68)),
                },
                new ThemeRuleGroup("Active")
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
                new ThemeRuleGroup("Inactive")
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
                    new SolidColorBrushThemeRule("Foreground", SCM_CHRM, saturation: Over100ToOver255(24), value: Over100ToOver255(90))
                }
            }
        };
    }
}