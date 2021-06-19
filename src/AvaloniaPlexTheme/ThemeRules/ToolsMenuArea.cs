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
                        new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(14)), //69
                        new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(32)), //85
                    },
                    new SolidColorBrushThemeRule("SideBorderBrush", SCM_TMNA, saturation: Over100ToOver255(0), value: Over100ToOver255(22)), //69
                    new LinearGradientBrushThemeRule("BottomBorderBrush0", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(9)), //69
                        new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(0)), //60
                    },
                    new LinearGradientBrushThemeRule("BottomBorderBrush1", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(29)), //82
                        new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(44)), //98
                    },
                    new LinearGradientBrushThemeRule("BottomBorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(22)), //69
                        new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(38)), //85
                    },
                    new SolidColorBrushThemeRule("Foreground", SCM_TMNA, saturation: Over100ToOver255(0), value: Over100ToOver255(100)) //100

                    /*new LinearGradientBrushThemeRule("Background", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(12)), //69
                        new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(28)), //85
                    },
                    new SolidColorBrushThemeRule("SideBorderBrush", SCM_TMNA, saturation: Over100ToOver255(0), value: Over100ToOver255(17)), //69
                    new LinearGradientBrushThemeRule("BottomBorderBrush0", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(9)), //69
                        new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(18)), //60
                    },
                    new LinearGradientBrushThemeRule("BottomBorderBrush1", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(17)), //82
                        new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(33)), //98
                    },
                    new LinearGradientBrushThemeRule("BottomBorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(0)), //69
                        new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(0), value: Over100ToOver255(16)), //85
                    },
                    new SolidColorBrushThemeRule("Foreground", SCM_TMNA, saturation: Over100ToOver255(0), value: Over100ToOver255(100)) //100
                    */
                },


                FalseValue = 
                new ThemeRuleGroup(string.Empty)
                {
                    new LinearGradientBrushThemeRule("Background", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(67), value: Over100ToOver255(69)),
                        new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(56), value: Over100ToOver255(85)),
                    },
                    new SolidColorBrushThemeRule("SideBorderBrush", SCM_TMNA, saturation: Over100ToOver255(67), value: Over100ToOver255(69)),
                    new LinearGradientBrushThemeRule("BottomBorderBrush0", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(66), value: Over100ToOver255(69)),
                        new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(74), value: Over100ToOver255(60)),
                    },
                    new LinearGradientBrushThemeRule("BottomBorderBrush1", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(58), value: Over100ToOver255(82)),
                        new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(49), value: Over100ToOver255(98)),
                    },
                    new LinearGradientBrushThemeRule("BottomBorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
                    {
                        new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(67), value: Over100ToOver255(69)),
                        new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(56), value: Over100ToOver255(85)),
                    },
                    new SolidColorBrushThemeRule("Foreground", SCM_TMNA, saturation: Over100ToOver255(0), value: Over100ToOver255(100))
                }
            }
        };
    }
}