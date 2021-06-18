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
        static readonly ThemeRuleGroup _captionButtonsRules =
        new ThemeRuleGroup("CaptionButtons")
        {
            new ThemeRuleGroup("Active")
            {
                new SolidColorBrushThemeRule("Idle", SCM_CHRM, saturation: Over100ToOver255(23), value: Over100ToOver255(100)),
            },
            new ThemeRuleGroup("Inactive")
            {
                new SolidColorBrushThemeRule("Idle", SCM_CHRM, saturation: Over100ToOver255(34), value: Over100ToOver255(82)),
            },
            new SolidColorBrushThemeRule("Hover", SCM_CHRM, saturation: Over100ToOver255(0), value: Over100ToOver255(100)),
            new SolidColorBrushThemeRule("Pressed", SCM_CHRM, saturation: Over100ToOver255(34), value: Over100ToOver255(82)),
            new SolidColorBrushThemeRule("Stroke", SCM_CHRM, saturation: Over100ToOver255(0), value: Over100ToOver255(0), alpha: 64),
        };
    }
}