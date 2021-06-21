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
        new ThemeRuleGroup("WindowTitleBar")
        {
            new IfElseRule<PlexColorMode>(SCM_P_CLMD, PlexColorMode.Dark)
            {
                TrueValue = 
                new ThemeRuleGroup(string.Empty)
                {
                    new LinearGradientBrushThemeRule("BottomBorderBrush", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_CHRM, 0, FilterSaturationAndValue(0, 11)), //53
                        new GradientStopThemeRule(SCM_CHRM, 1, FilterSaturationAndValue(0, 26)), //68
                    },
                    new ThemeRuleGroup("Active")
                    {
                        new LinearGradientBrushThemeRule("Background", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CHRM, 0, FilterSaturationAndValue(0, 25)), //83
                            new GradientStopThemeRule(SCM_CHRM, 1, FilterSaturationAndValue(0, 40)), //96
                        },
                        new LinearGradientBrushThemeRule("BorderBrush", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CHRM, 0, FilterSaturationAndValue(0, 57, 0)), //97
                            new GradientStopThemeRule(SCM_CHRM, 1, FilterSaturationAndValue(0, 57)), //97
                        },
                        new SolidColorBrushThemeRule("Foreground", SCM_CHRM, FilterSaturationAndValue(0, 100))
                    },
                    new ThemeRuleGroup("Inactive")
                    {
                        new LinearGradientBrushThemeRule("Background", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CHRM, 0, FilterSaturationAndValue(0, 15)), //73
                            new GradientStopThemeRule(SCM_CHRM, 1, FilterSaturationAndValue(0, 38)), //84
                        },
                        new LinearGradientBrushThemeRule("BorderBrush", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CHRM, 0, FilterSaturationAndValue(0, 45, 0)), //85
                            new GradientStopThemeRule(SCM_CHRM, 1, FilterSaturationAndValue(0, 45)), //85
                        },
                        new SolidColorBrushThemeRule("Foreground", SCM_CHRM, FilterSaturationAndValue(0, 90))
                    }
                },

                FalseValue =
                new ThemeRuleGroup(string.Empty)
                {
                    new LinearGradientBrushThemeRule("BottomBorderBrush", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_CHRM, 0, FilterSaturationAndValue(56, 53)),
                        new GradientStopThemeRule(SCM_CHRM, 1, FilterSaturationAndValue(58, 68)),
                    },
                    new ThemeRuleGroup("Active")
                    {
                        new LinearGradientBrushThemeRule("Background", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CHRM, 0, FilterSaturationAndValue(63, 83)),
                            new GradientStopThemeRule(SCM_CHRM, 1, FilterSaturationAndValue(53, 96)),
                        },
                        new LinearGradientBrushThemeRule("BorderBrush", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CHRM, 0, FilterSaturationAndValue(32, 97, 0)),
                            new GradientStopThemeRule(SCM_CHRM, 1, FilterSaturationAndValue(32, 97)),
                        },
                        new SolidColorBrushThemeRule("Foreground", SCM_CHRM, FilterSaturationAndValue(0, 100))
                    },
                    new ThemeRuleGroup("Inactive")
                    {
                        new LinearGradientBrushThemeRule("Background", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CHRM, 0, FilterSaturationAndValue(63, 73)),
                            new GradientStopThemeRule(SCM_CHRM, 1, FilterSaturationAndValue(53, 84)),
                        },
                        new LinearGradientBrushThemeRule("BorderBrush", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                        {
                            new GradientStopThemeRule(SCM_CHRM, 0, FilterSaturationAndValue(36, 85, 0)),
                            new GradientStopThemeRule(SCM_CHRM, 1, FilterSaturationAndValue(36, 85)),
                        },
                        new SolidColorBrushThemeRule("Foreground", SCM_CHRM, FilterSaturationAndValue(24, 90))
                    }
                }
            }
        };
    }
}
