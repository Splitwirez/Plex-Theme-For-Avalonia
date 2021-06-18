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
        static readonly ThemeRuleGroup _toggleSwitchRules =
        new ThemeRuleGroup("ToggleSwitch")
        {
            new ThemeRuleGroup("Thumb")
            {
                new ThemeRuleGroup("Idle")
                {
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
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(0.625, 0.25, RelativeUnit.Relative), new RelativePoint(0.375, 0.625, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(54), value: Over100ToOver255(97)),
                        new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(87), value: Over100ToOver255(89))
                    },
                    new LinearGradientBrushThemeRule("BorderBrush", new RelativePoint(0, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(13), value: Over100ToOver255(70)),
                        new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(12), value: Over100ToOver255(87))
                    }
                },
                new ThemeRuleGroup("Disabled")
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(0.625, 0.25, RelativeUnit.Relative), new RelativePoint(0.375, 0.625, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(66)),
                        new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(49))
                    },
                    new LinearGradientBrushThemeRule("BorderBrush", new RelativePoint(0, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(75)),
                        new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(93))
                    }
                },
            },
            new ThemeRuleGroup("Track")
            {
                new ThemeRuleGroup("Idle")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, saturation: Over100ToOver255(0), value: Over100ToOver255(100)),
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
                new ThemeRuleGroup("Disabled")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, saturation: Over100ToOver255(0), value: Over100ToOver255(68)),
                    new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, saturation: Over100ToOver255(0), value: Over100ToOver255(27)),
                },
                new LinearGradientBrushThemeRule("BorderBrush", new RelativePoint(0, 1, RelativeUnit.Relative))
                {
                    new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(13), value: Over100ToOver255(70)),
                    new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(12), value: Over100ToOver255(87))
                }
            },
            new ThemeRuleGroup("ToolsMenuArea")
            {
                new ThemeRuleGroup("Track")
                {
                    new ThemeRuleGroup("Idle")
                    {
                        new SolidColorBrushThemeRule("Background", SCM_CTRL, saturation: Over100ToOver255(63), value: Over100ToOver255(56)),
                        new SolidColorBrushThemeRule("BorderBrush0", SCM_CTRL, saturation: Over100ToOver255(63), value: Over100ToOver255(46)),
                        new SolidColorBrushThemeRule("BorderBrush1", SCM_CTRL, saturation: Over100ToOver255(29), value: Over100ToOver255(100)),
                    },
                }
            }
        };
    }
}