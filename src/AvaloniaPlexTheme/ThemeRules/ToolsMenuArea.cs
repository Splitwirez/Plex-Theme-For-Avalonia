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
        static readonly ThemeRuleGroup _toolsMenuAreaRules =
        new ThemeRuleGroup("ToolsMenuArea")
        {
            new LinearGradientBrushThemeRule("Background", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
            {
                new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(67), value: Over100ToOver255(69)),
                new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(56), value: Over100ToOver255(85)),
            },
            new SolidColorBrushThemeRule("SideBorderBrush", SCM_TMNA, Over100ToOver255(67), value: Over100ToOver255(69)),
            new LinearGradientBrushThemeRule("BottomBorderBrush0", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
            {
                new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(67), value: Over100ToOver255(69)),
                new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(56), value: Over100ToOver255(85)),
            },
            new LinearGradientBrushThemeRule("BottomBorderBrush1", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
            {
                new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(58), value: Over100ToOver255(82)),
                new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(49), value: Over100ToOver255(98)),
            },
            new LinearGradientBrushThemeRule("BottomBorderBrush2", new RelativePoint(0.5, 0, RelativeUnit.Relative), GradientSpreadMethod.Reflect)
            {
                new GradientStopThemeRule(SCM_TMNA, 0, saturation: Over100ToOver255(66), value: Over100ToOver255(69)),
                new GradientStopThemeRule(SCM_TMNA, 1, saturation: Over100ToOver255(74), value: Over100ToOver255(60)),
            },
            new SolidColorBrushThemeRule("Foreground", SCM_TMNA, saturation: Over100ToOver255(0), value: Over100ToOver255(100))
        };
    }
}