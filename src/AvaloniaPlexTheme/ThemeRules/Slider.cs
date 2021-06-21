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
        static readonly ThemeRuleGroup _sliderRules =
        new ThemeRuleGroup("Slider")
        {
            new ThemeRuleGroup("Track")
            {
                new ThemeRuleGroup("Idle")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, FilterSaturationAndValue(43, 98)),
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, FilterSaturationAndValue(54, 73)),
                },
                new ThemeRuleGroup("Hover")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, FilterSaturationAndValue(23, 98)),
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, FilterSaturationAndValue(34, 73)),
                },
                new ThemeRuleGroup("Pressed")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, FilterSaturationAndValue(43, 78)),
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, FilterSaturationAndValue(54, 53)),
                },
                new ThemeRuleGroup("Disabled")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, FilterSaturationAndValue(0, 68)),
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, FilterSaturationAndValue(0, 43)),
                },
            },
            new ThemeRuleGroup("Thumb")
            {
                new ThemeRuleGroup("TrackGlow")
                {
                    new LinearGradientBrushThemeRule("Horizontal", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 100, 0x00)),
                        new GradientStopThemeRule(SCM_CTRL, 0.75, FilterSaturationAndValue(0, 100, 0x7F))
                    },
                    new LinearGradientBrushThemeRule("Vertical", new RelativePoint(0, 0.5, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 100, 0x00)),
                        new GradientStopThemeRule(SCM_CTRL, 0.75, FilterSaturationAndValue(0, 100, 0x7F))
                    }
                },
                new ThemeRuleGroup("Idle")
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(0, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 100)),
                        new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(2, 97))
                    },
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, FilterSaturationAndValue(31, 66))
                },
                new ThemeRuleGroup("Hover")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, FilterSaturationAndValue(0, 100)),
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, FilterSaturationAndValue(21, 72))
                },
                new ThemeRuleGroup("Pressed")
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(0, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(8, 80)),
                        new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(10, 77))
                    },
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, FilterSaturationAndValue(21, 72))
                },
                new ThemeRuleGroup("Disabled")
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(0, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 70)),
                        new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 67))
                    },
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, FilterSaturationAndValue(0, 62))
                }
            }
            /*new ThemeRuleGroup("Track")
            {
                new SolidColorBrushThemeRule("Background", SCM_CTRL, FilterSaturationAndValue(12, 91)),
                new SolidColorBrushThemeRule("BorderBrush0", SCM_CTRL, FilterSaturationAndValue(40, 87)),
                new SolidColorBrushThemeRule("BorderBrush1", SCM_CTRL, FilterSaturationAndValue(0, 99)),
            },
            new ThemeRuleGroup("Thumb")
            {
                new ThemeRuleGroup("NonInteracting")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, FilterSaturationAndValue(4, 92)),
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, FilterSaturationAndValue(25, 71))
                },
                new ThemeRuleGroup("Interacting")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, FilterSaturationAndValue(27, 96)),
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, FilterSaturationAndValue(63, 55)),
                },
                new ThemeRuleGroup("Disabled")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, FilterSaturationAndValue(0, 100)),
                },
            }*/
        };
    }
}
