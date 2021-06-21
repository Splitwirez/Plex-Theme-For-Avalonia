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
        static readonly IThemeRule _toolsMenuAreaControlRules =
        new ThemeRuleGroup("ToolsMenuAreaControl")
        {
            new IfElseRule<PlexColorMode>(SCM_P_CLMD, PlexColorMode.Dark)
            {
                TrueValue = 
                new ThemeRuleGroup(string.Empty)
                {
                    new LinearGradientBrushThemeRule("BorderBrush0", new RelativePoint(0, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(0, 32)),
                        new GradientStopThemeRule(SCM_TMNA, 0.5, FilterSaturationAndValue(0, 36)),
                        new GradientStopThemeRule(SCM_TMNA, 1, FilterSaturationAndValue(0, 50)),
                    },
                    new LinearGradientBrushThemeRule("BorderBrush1", new RelativePoint(0, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(27, 44)),
                        new GradientStopThemeRule(SCM_TMNA, 1, FilterSaturationAndValue(29, 26)),
                    },
                    new ThemeRuleGroup("Hover")
                    {
                        new LinearGradientBrushThemeRule("Background0", new RelativePoint(0, 1, RelativeUnit.Relative)) //new RelativePoint(0.5, 1, RelativeUnit.Relative), new RelativePoint(0.96875, 0.9375, RelativeUnit.Relative))
                        {
                            //new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(5, 79)),
                            /*new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(17, 52)),
                            new GradientStopThemeRule(SCM_TMNA, 1, FilterSaturationAndValue(14, 64)),*/
                            new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(25, 68)),
                            new GradientStopThemeRule(SCM_TMNA, 1, FilterSaturationAndValue(25, 88)),
                        },
                        new SolidColorBrushThemeRule("Background1", SCM_TMNA, FilterSaturationAndValue(11, 86)),
                        //new SolidColorBrushThemeRule("Background1", SCM_TMNA, FilterSaturationAndValue(5, 79)),
                    },
                    new ThemeRuleGroup("Pressed")
                    {
                        new SolidColorBrushThemeRule("Background", SCM_TMNA, FilterSaturationAndValue(63, 83))
                    },
                },

                FalseValue =
                new ThemeRuleGroup(string.Empty)
                {
                    new LinearGradientBrushThemeRule("BorderBrush0", new RelativePoint(0, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(63, 76)),
                        new GradientStopThemeRule(SCM_TMNA, 0.5, FilterSaturationAndValue(62, 80)),
                        new GradientStopThemeRule(SCM_TMNA, 1, FilterSaturationAndValue(38, 85)),
                    },
                    new LinearGradientBrushThemeRule("BorderBrush1", new RelativePoint(0, 1, RelativeUnit.Relative))
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(63, 76)),
                        new GradientStopThemeRule(SCM_TMNA, 1, FilterSaturationAndValue(63, 50)),
                    },
                    new ThemeRuleGroup("Hover")
                    {
                        new LinearGradientBrushThemeRule("Background0", new RelativePoint(0, 1, RelativeUnit.Relative)) //, new RelativePoint(0.5, 1, RelativeUnit.Relative), new RelativePoint(0.96875, 0.9375, RelativeUnit.Relative))
                        {
                            //new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(20, 98)),
                            /*new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(37, 91)),
                            //new GradientStopThemeRule(SCM_TMNA, 1, FilterSaturationAndValue(35, 93)),*/
                            new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(49, 80)),
                            new GradientStopThemeRule(SCM_TMNA, 1, FilterSaturationAndValue(49, 100))
                        },
                        new SolidColorBrushThemeRule("Background1", SCM_TMNA, FilterSaturationAndValue(20, 98))
                        //new SolidColorBrushThemeRule("Background1", SCM_TMNA, FilterSaturationAndValue(49, 80)),
                    },
                    new ThemeRuleGroup("Pressed")
                    {
                        new SolidColorBrushThemeRule("Background", SCM_TMNA, FilterSaturationAndValue(63, 83))
                    },  
                }
            },
            new ThemeRuleGroup("Hover")
            {
                new SolidColorBrushThemeRule("Foreground", SCM_TMNA, FilterSaturationAndValue(0, 0))
            },
            new ThemeRuleGroup("Disabled")
            {
                new SolidColorBrushThemeRule("Foreground", SCM_TMNA, FilterSaturationAndValue(12, 86))
            },
        };
    }
}
