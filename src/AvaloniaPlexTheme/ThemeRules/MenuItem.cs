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
        static readonly ThemeRuleGroup _menuItemRules =
        new ThemeRuleGroup("MenuItem")
        {
            new ThemeRuleGroup("Hover")
            {
                new LinearGradientBrushThemeRule("Background0", new RelativePoint(0.5, 1, RelativeUnit.Relative), new RelativePoint(0.96875, 0.9375, RelativeUnit.Relative))
                {
                    new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(20), value: Over100ToOver255(98)),
                    new GradientStopThemeRule(SCM_CTRL, 0.5, saturation: Over100ToOver255(35), value: Over100ToOver255(93)),
                    new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(37), value: Over100ToOver255(91)),
                },
                new LinearGradientBrushThemeRule("Background1", new RelativePoint(0.125, 0, RelativeUnit.Relative), new RelativePoint(0, 0.625, RelativeUnit.Relative))
                {
                    new GradientStopThemeRule(SCM_CTRL, 0, saturation: Over100ToOver255(49), value: Over100ToOver255(80)),
                    new GradientStopThemeRule(SCM_CTRL, 1, saturation: Over100ToOver255(49), value: Over100ToOver255(80), alpha: 0),
                }
            },
            new ThemeRuleGroup("Pressed")
            {
                new SolidColorBrushThemeRule("Background", SCM_CTRL, saturation: Over100ToOver255(63), value: Over100ToOver255(83))
            }
        };
    }
}