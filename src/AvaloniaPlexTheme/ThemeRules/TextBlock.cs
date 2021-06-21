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
        static readonly IThemeRule _textBlockRules =
        new ThemeRuleGroup("TextBlock")
        {
            new IfElseRule<PlexColorMode>(SCM_P_CLMD, PlexColorMode.Dark)
            {
                TrueValue = 
                new ThemeRuleGroup(string.Empty)
                {
                    new ThemeRuleGroup("Header")
                    {
                        new SolidColorBrushThemeRule("Normal", SCM_CLBG, FilterSaturationAndValue(83, 85)),
                        new SolidColorBrushThemeRule("Emphasized", SCM_CLBG, FilterSaturationAndValue(75, 99))
                    },
                    new SolidColorBrushThemeRule("Soft", SCM_CLBG, FilterSaturationAndValue(0, 60))
                },
                
                FalseValue =
                new ThemeRuleGroup(string.Empty)
                {
                    new ThemeRuleGroup("Header")
                    {
                        new SolidColorBrushThemeRule("Normal", SCM_CLBG, FilterSaturationAndValue(57, 89)),
                        new SolidColorBrushThemeRule("Emphasized", SCM_CLBG, FilterSaturationAndValue(99, 75))
                    },
                    new SolidColorBrushThemeRule("Soft", SCM_CLBG, FilterSaturationAndValue(0, 39))
                }
            }
        };
    }
}
