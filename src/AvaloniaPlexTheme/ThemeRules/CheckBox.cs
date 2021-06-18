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
        static readonly ThemeRuleGroup _checkBoxRules =
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
        };
    }
}