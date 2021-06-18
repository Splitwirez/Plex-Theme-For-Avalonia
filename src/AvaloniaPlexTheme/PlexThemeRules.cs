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
        /*const string SCM_CHRM = "Chrome";
        const string SCM_TMNA = "ToolsMenu";
        const string SCM_CLBG = "Background";
        const string SCM_CTRL = "Controls";*/
        internal static readonly string SCM_CHRM = PlexColorScheme.ChromeProperty.Name;
        internal static readonly string SCM_TMNA = PlexColorScheme.ToolsMenuAreaProperty.Name;
        internal static readonly string SCM_CLBG = PlexColorScheme.BackgroundProperty.Name;
        internal static readonly string SCM_CTRL = PlexColorScheme.ControlsProperty.Name;
        internal static readonly string SCM_P_CLMD = PlexColorScheme.ColorModeProperty.Name;



        static readonly ThemeRules _themeRules;
        
        
        static PlexTheme()
        {
            _themeRules = new ThemeRules()
            {
                _buttonRules,
                _captionButtonsRules,
                _checkBoxRules,
                _menuRules,
                _menuItemRules,
                _sliderRules,
                _textBoxRules,
                _toggleSwitchRules,
                _toolsMenuAreaRules,
                _toolsMenuAreaControlRules,
                _windowRules,
                _windowTitleBarRules
            };
        }
    }
}