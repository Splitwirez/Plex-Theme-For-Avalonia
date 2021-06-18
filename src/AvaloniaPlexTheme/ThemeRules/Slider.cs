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
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, saturation: Over100ToOver255(43), value: Over100ToOver255(98)),
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, saturation: Over100ToOver255(54), value: Over100ToOver255(73)),
                },
                new ThemeRuleGroup("Hover")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, saturation: Over100ToOver255(23), value: Over100ToOver255(98)),
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, saturation: Over100ToOver255(34), value: Over100ToOver255(73)),
                },
                new ThemeRuleGroup("Pressed")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, saturation: Over100ToOver255(43), value: Over100ToOver255(78)),
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, saturation: Over100ToOver255(54), value: Over100ToOver255(53)),
                },
                new ThemeRuleGroup("Disabled")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, saturation: Over100ToOver255(0), value: Over100ToOver255(68)),
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, saturation: Over100ToOver255(0), value: Over100ToOver255(43)),
                },
            },
            new ThemeRuleGroup("Thumb")
            {
                new ThemeRuleGroup("TrackGlow")
                {
                    new LinearGradientBrushThemeRule("Horizontal", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(100), alpha: 0x00),
                        new GradientStopThemeRule(SCM_CTRL, 0.75, saturation: Over100ToOver255(0), value: Over100ToOver255(100), alpha: 0x7F)
                    },
                    new LinearGradientBrushThemeRule("Vertical", new RelativePoint(0, 0.5, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(100), alpha: 0x00),
                        new GradientStopThemeRule(SCM_CTRL, 0.75, saturation: Over100ToOver255(0), value: Over100ToOver255(100), alpha: 0x7F)
                    }
                },
                new ThemeRuleGroup("Idle")
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(0, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(100)),
                        new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(2), value: Over100ToOver255(97))
                    },
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, saturation: Over100ToOver255(31), value: Over100ToOver255(66))
                },
                new ThemeRuleGroup("Hover")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, saturation: Over100ToOver255(0), value: Over100ToOver255(100)),
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, saturation: Over100ToOver255(21), value: Over100ToOver255(72))
                },
                new ThemeRuleGroup("Pressed")
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(0, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(8), value: Over100ToOver255(80)),
                        new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(10), value: Over100ToOver255(77))
                    },
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, saturation: Over100ToOver255(21), value: Over100ToOver255(72))
                },
                new ThemeRuleGroup("Disabled")
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(0, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(70)),
                        new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(67))
                    },
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, saturation: Over100ToOver255(0), value: Over100ToOver255(62))
                }
            }
            /*new ThemeRuleGroup("Track")
            {
                new SolidColorBrushThemeRule("Background", SCM_CTRL, saturation: Over100ToOver255(12), value: Over100ToOver255(91)),
                new SolidColorBrushThemeRule("BorderBrush0", SCM_CTRL, saturation: Over100ToOver255(40), value: Over100ToOver255(87)),
                new SolidColorBrushThemeRule("BorderBrush1", SCM_CTRL, saturation: Over100ToOver255(0), value: Over100ToOver255(99)),
            },
            new ThemeRuleGroup("Thumb")
            {
                new ThemeRuleGroup("NonInteracting")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, saturation: Over100ToOver255(4), value: Over100ToOver255(92)),
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, saturation: Over100ToOver255(25), value: Over100ToOver255(71))
                },
                new ThemeRuleGroup("Interacting")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, saturation: Over100ToOver255(27), value: Over100ToOver255(96)),
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, saturation: Over100ToOver255(63), value: Over100ToOver255(55)),
                },
                new ThemeRuleGroup("Disabled")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, saturation: Over100ToOver255(0), value: Over100ToOver255(100)),
                },
            }*/
        };
    }
}