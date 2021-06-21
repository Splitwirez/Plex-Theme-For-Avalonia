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
                        new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(24, 92)),
                        new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(57, 84))
                    },
                    /*new LinearGradientBrushThemeRule("BorderBrush0", new RelativePoint(0, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(8, 50)),
                        new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(7, 67))
                    },*/
                    new LinearGradientBrushThemeRule("BorderBrush1", new RelativePoint(0.625, 0.25, RelativeUnit.Relative), new RelativePoint(0.375, 0.625, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(13, 97)),
                        new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(12, 89))
                    }
                },
                new ThemeRuleGroup("Hover")
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(0.625, 0.25, RelativeUnit.Relative), new RelativePoint(0.375, 0.625, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(17, 100)),
                        new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(57, 99))
                    }
                },
                new ThemeRuleGroup("Pressed")
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(0.625, 0.25, RelativeUnit.Relative), new RelativePoint(0.375, 0.625, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(44, 92)),
                        new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(77, 84))
                    }
                },
                new ThemeRuleGroup("Checked")
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(0.625, 0.25, RelativeUnit.Relative), new RelativePoint(0.375, 0.625, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(54, 97)),
                        new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(87, 89))
                    },
                    /*new LinearGradientBrushThemeRule("BorderBrush0", new RelativePoint(0, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(13, 70)),
                        new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(12, 87))
                    }*/
                },
                new ThemeRuleGroup("Disabled")
                {
                    /*new LinearGradientBrushThemeRule("Background", new RelativePoint(0.625, 0.25, RelativeUnit.Relative), new RelativePoint(0.375, 0.625, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 66)),
                        new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 49))
                    },*/
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(0.625, 0.25, RelativeUnit.Relative), new RelativePoint(0.375, 0.625, RelativeUnit.Relative)) //, new RelativePoint(0, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 62)),
                        new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 54))
                    },
                    /*new RadialGradientBrushThemeRule("Background", new RelativePoint(0.625, 0.25, RelativeUnit.Relative), 0.625) //, new RelativePoint(0, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0.25, FilterSaturationAndValue(0, 62)),
                        new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 54))
                    },*/


                    /*new LinearGradientBrushThemeRule("BorderBrush0", new RelativePoint(0, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 40)),
                        new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 57))
                    },*/
                    //new SolidColorBrushThemeRule("BorderBrush0", SCM_CTRL, FilterSaturationAndValue(0, 33)),
                    new SolidColorBrushThemeRule("BorderBrush0", SCM_CTRL, FilterSaturationAndValue(0, 42)),
                    new LinearGradientBrushThemeRule("BorderBrush1", new RelativePoint(0.625, 0.25, RelativeUnit.Relative), new RelativePoint(0.375, 0.625, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 67)),
                        new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 59))
                    }
                },
                new SolidColorBrushThemeRule("BorderBrush0", SCM_CTRL, FilterSaturationAndValue(7, 72)),
            },
            new ThemeRuleGroup("Track")
            {
                new ThemeRuleGroup("Idle")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, FilterSaturationAndValue(0, 100)),
                    new SolidColorBrushThemeRule("Foreground", SCM_CTRL, FilterSaturationAndValue(50, 17)),
                },
                new ThemeRuleGroup("Hover")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, FilterSaturationAndValue(16, 95)),
                },
                new ThemeRuleGroup("Pressed")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, FilterSaturationAndValue(16, 85)),
                },
                new ThemeRuleGroup("Checked")
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(1, 0, RelativeUnit.Relative), new RelativePoint(0.5, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(19, 89)),
                        new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 100))
                    }
                },
                new ThemeRuleGroup("Disabled")
                {
                    new SolidColorBrushThemeRule("Background", SCM_CTRL, FilterSaturationAndValue(0, 70)),
                    //new SolidColorBrushThemeRule("BorderBrush", SCM_CTRL, FilterSaturationAndValue(0, 27)),
                    new LinearGradientBrushThemeRule("BorderBrush", new RelativePoint(0, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(0, 40)),
                        new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(0, 57))
                    }
                },
                new LinearGradientBrushThemeRule("BorderBrush", new RelativePoint(0, 1, RelativeUnit.Relative))
                {
                    new GradientStopThemeRule(SCM_CTRL, 0, FilterSaturationAndValue(13, 70)),
                    new GradientStopThemeRule(SCM_CTRL, 1, FilterSaturationAndValue(12, 87))
                }
            },
            new ThemeRuleGroup("ToolsMenuArea")
            {
                new ThemeRuleGroup("Track")
                {
                    new ThemeRuleGroup("Idle")
                    {
                        new SolidColorBrushThemeRule("Background", SCM_CTRL, FilterSaturationAndValue(63, 56)),
                        new SolidColorBrushThemeRule("BorderBrush0", SCM_CTRL, FilterSaturationAndValue(63, 46)),
                        new SolidColorBrushThemeRule("BorderBrush1", SCM_CTRL, FilterSaturationAndValue(29, 100)),
                    },
                }
            }
        };
    }
}
