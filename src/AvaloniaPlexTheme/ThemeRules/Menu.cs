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
        static readonly ThemeRuleGroup _menuRules =
        new ThemeRuleGroup("Menu")
        {
            new SolidColorBrushThemeRule("Foreground", SCM_CLBG, FilterSaturationAndValue(77, 58)),
            new ThemeRuleGroup("ToolsMenuArea")
            {
                new SolidColorBrushThemeRule("Foreground", SCM_TMNA, FilterSaturationAndValue(39, 99))
            },
        };
    }
}
