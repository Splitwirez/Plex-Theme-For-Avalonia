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
        static readonly IThemeRule _toolsMenuAreaRules =
        new ThemeRuleGroup("ToolsMenuArea")
        {
            new IfElseRule<PlexColorMode>(SCM_P_CLMD, PlexColorMode.Dark)
            {
                TrueValue = 
                new ThemeRuleGroup(string.Empty)
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(0, 14)), //69
                        new GradientStopThemeRule(SCM_TMNA, 1, FilterSaturationAndValue(0, 32)), //85
                    },
                    new SolidColorBrushThemeRule("SideBorderBrush", SCM_TMNA, FilterSaturationAndValue(0, 22)), //69
                    new LinearGradientBrushThemeRule("BottomBorderBrush0", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(0, 9)), //69
                        new GradientStopThemeRule(SCM_TMNA, 1, FilterSaturationAndValue(0, 0)), //60
                    },
                    new LinearGradientBrushThemeRule("BottomBorderBrush1", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(0, 29)), //82
                        new GradientStopThemeRule(SCM_TMNA, 1, FilterSaturationAndValue(0, 44)), //98
                    },
                    new LinearGradientBrushThemeRule("BottomBorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(0, 22)), //69
                        new GradientStopThemeRule(SCM_TMNA, 1, FilterSaturationAndValue(0, 38)), //85
                    },
                    new SolidColorBrushThemeRule("Foreground", SCM_TMNA, FilterSaturationAndValue(0, 100)) //100

                    /*new LinearGradientBrushThemeRule("Background", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(0, 12)), //69
                        new GradientStopThemeRule(SCM_TMNA, 1, FilterSaturationAndValue(0, 28)), //85
                    },
                    new SolidColorBrushThemeRule("SideBorderBrush", SCM_TMNA, FilterSaturationAndValue(0, 17)), //69
                    new LinearGradientBrushThemeRule("BottomBorderBrush0", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(0, 9)), //69
                        new GradientStopThemeRule(SCM_TMNA, 1, FilterSaturationAndValue(0, 18)), //60
                    },
                    new LinearGradientBrushThemeRule("BottomBorderBrush1", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(0, 17)), //82
                        new GradientStopThemeRule(SCM_TMNA, 1, FilterSaturationAndValue(0, 33)), //98
                    },
                    new LinearGradientBrushThemeRule("BottomBorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(0, 0)), //69
                        new GradientStopThemeRule(SCM_TMNA, 1, FilterSaturationAndValue(0, 16)), //85
                    },
                    new SolidColorBrushThemeRule("Foreground", SCM_TMNA, FilterSaturationAndValue(0, 100)) //100
                    */
                },


                FalseValue = 
                new ThemeRuleGroup(string.Empty)
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(67, 69)),
                        new GradientStopThemeRule(SCM_TMNA, 1, FilterSaturationAndValue(56, 85)),
                    },
                    new SolidColorBrushThemeRule("SideBorderBrush", SCM_TMNA, FilterSaturationAndValue(67, 69)),
                    new LinearGradientBrushThemeRule("BottomBorderBrush0", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(66, 69)),
                        new GradientStopThemeRule(SCM_TMNA, 1, FilterSaturationAndValue(74, 60)),
                    },
                    new LinearGradientBrushThemeRule("BottomBorderBrush1", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(58, 82)),
                        new GradientStopThemeRule(SCM_TMNA, 1, FilterSaturationAndValue(49, 98)),
                    },
                    new LinearGradientBrushThemeRule("BottomBorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, FilterSaturationAndValue(67, 69)),
                        new GradientStopThemeRule(SCM_TMNA, 1, FilterSaturationAndValue(56, 85)),
                    },
                    new SolidColorBrushThemeRule("Foreground", SCM_TMNA, FilterSaturationAndValue(0, 100))
                }
            }
        };
    }
}
