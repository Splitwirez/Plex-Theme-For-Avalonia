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
                    new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(2, 86)),
                    new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 100))
                },
                new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, FilterSaturationAndValue(78, 50)),
                new SolidColorBrushThemeRule("CheckMark", SCM_CTRL, FilterSaturationAndValue(79, 63))
            },
            new ThemeRuleGroup("Hover")
            {
                new LinearGradientBrushThemeRule("Background", new RelativePoint(1, 1, RelativeUnit.Relative))
                {
                    new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(2, 100)),
                    new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 100))
                },
                new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, FilterSaturationAndValue(93, 50)),
                new SolidColorBrushThemeRule("CheckMark", SCM_CTRL, FilterSaturationAndValue(94, 78))
            },
            new ThemeRuleGroup("Pressed")
            {
                new LinearGradientBrushThemeRule("Background", new RelativePoint(1, 1, RelativeUnit.Relative))
                {
                    new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(2, 76)),
                    new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 90))
                },
                new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, FilterSaturationAndValue(78, 40)),
                new SolidColorBrushThemeRule("CheckMark", SCM_CTRL, FilterSaturationAndValue(79, 53))
            },
            new ThemeRuleGroup("Disabled")
            {
                new LinearGradientBrushThemeRule("Background", new RelativePoint(1, 1, RelativeUnit.Relative))
                {
                    new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 68)),
                    new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 80))
                },
                new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, FilterSaturationAndValue(0, 27)),
                new SolidColorBrushThemeRule("CheckMark", SCM_CTRL, FilterSaturationAndValue(0, 42))
            },
            new ThemeRuleGroup("ToolsMenuArea")
            {
                new ThemeRuleGroup("Idle")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, FilterSaturationAndValue(63, 56)),
                    new SolidColorBrushThemeRule("BorderBrush0", SCM_CTRL, FilterSaturationAndValue(63, 46)),
                    new SolidColorBrushThemeRule("BorderBrush1", SCM_CTRL, FilterSaturationAndValue(29, 100)), //Over100ToOver255(63, 46)),
                    new SolidColorBrushThemeRule("CheckMark", SCM_CTRL, FilterSaturationAndValue(0, 100))
                }
            }
        };
    }
}
