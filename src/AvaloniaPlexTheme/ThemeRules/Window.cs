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
        static readonly IThemeRule _windowRules =
        new IfElseRule<PlexColorMode>(SCM_P_CLMD, PlexColorMode.Dark)
        {
            TrueValue = 
            new ThemeRuleGroup("Window")
            {
                new LinearGradientBrushThemeRule("Background", new RelativePoint(0, 1, RelativeUnit.Relative))
                {
                    new GradientStopThemeRule(SCM_CLBG, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(18)),
                    new GradientStopThemeRule(SCM_CLBG, 1, saturation: Over100ToOver255(36), value: Over100ToOver255(0)), //saturation: Over100ToOver255(48), value: Over100ToOver255(18)),
                },
                new SolidColorBrushThemeRule("Foreground", SCM_CLBG, saturation: Over100ToOver255(0), value: Over100ToOver255(100))
            },
            
            FalseValue =
            new ThemeRuleGroup("Window")
            {
                new LinearGradientBrushThemeRule("Background", new RelativePoint(0, 1, RelativeUnit.Relative))
                {
                    new GradientStopThemeRule(SCM_CLBG, 0, saturation: Over100ToOver255(0), value: Over100ToOver255(100)),
                    new GradientStopThemeRule(SCM_CLBG, 1, saturation: Over100ToOver255(16), value: Over100ToOver255(91)), //Over100ToOver255(91)),
                },
                new SolidColorBrushThemeRule("Foreground", SCM_CLBG, saturation: Over100ToOver255(0), value: Over100ToOver255(0))
            }
        };
    }
}