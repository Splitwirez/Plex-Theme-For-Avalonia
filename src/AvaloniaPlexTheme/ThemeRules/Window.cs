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
        static readonly ThemeRuleGroup _windowRules =
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
                    new GradientStopThemeRule(SCM_CHRM, 0, saturation: Over100ToOver255(56), value: Over100ToOver255(53)),
                    new GradientStopThemeRule(SCM_CHRM, 1, saturation: Over100ToOver255(58), value: Over100ToOver255(68)),
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
            /*new ThemeRuleGroup("CaptionButton")
            {
                new SolidColorBrushThemeRule("Stroke", SCM_CHRM, saturation: Over100ToOver255(0), value: Over100ToOver255(0), alpha: 64),
                new SolidColorBrushThemeRule("ActiveIdle", SCM_CHRM, saturation: Over100ToOver255(23), value: Over100ToOver255(100)),
                new SolidColorBrushThemeRule("InactiveIdle", SCM_CHRM, saturation: Over100ToOver255(34), value: Over100ToOver255(82)),
                new SolidColorBrushThemeRule("Hover", SCM_CHRM, saturation: Over100ToOver255(0), value: Over100ToOver255(100)),
                new SolidColorBrushThemeRule("Pressed", SCM_CHRM, saturation: Over100ToOver255(34), value: Over100ToOver255(82)),
            }*/
        };
    }
}