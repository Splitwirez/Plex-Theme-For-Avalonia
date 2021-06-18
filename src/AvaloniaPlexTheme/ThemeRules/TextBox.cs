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
        static readonly ThemeRuleGroup _textBoxRules =
        new ThemeRuleGroup("TextBox")
        {
            new ThemeRuleGroup("Idle")
            {
                new SolidColorBrushThemeRule("Background", SCM_CTRL, saturation: Over100ToOver255(0), value: Over100ToOver255(100)),
                new LinearGradientBrushThemeRule("BorderBrush", new RelativePoint(0, 1, RelativeUnit.Relative))
                {
                    new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(13), value: Over100ToOver255(80)),
                    new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(12), value: Over100ToOver255(97))
                },
                new SolidColorBrushThemeRule("Watermark", SCM_CTRL, saturation: Over100ToOver255(50), value: Over100ToOver255(57)),
                new SolidColorBrushThemeRule("Foreground", SCM_CTRL, saturation: Over100ToOver255(50), value: Over100ToOver255(17)),
            }
        };
    }
}