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
        private static Uri PLEX_CORE_URI = new Uri("avares://AvaloniaPlexTheme/Internal/PlexBase.axaml", UriKind.Absolute);

        private static Uri PLEX_TEMPCOLOURS_URI = new Uri("avares://AvaloniaPlexTheme/Colors/LightBlueReso.axaml", UriKind.Absolute);

        private readonly Uri _baseUri;
        //private IStyle[]? _loaded;

        private Styles _style = null;

        private IReadOnlyList<IStyle> _childStyles = null;
        
        private bool _isLoading;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlexTheme"/> class.
        /// </summary>
        /// <param name="baseUri">The base URL for the XAML context.</param>
        public PlexTheme(Uri baseUri)
        {
            _baseUri = baseUri;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlexTheme"/> class.
        /// </summary>
        /// <param name="serviceProvider">The XAML service provider.</param>
        public PlexTheme(IServiceProvider serviceProvider)
        {
            _baseUri = ((IUriContext)serviceProvider.GetService(typeof(IUriContext))).BaseUri;
        }

        public IResourceHost? Owner => (Loaded as IResourceProvider)?.Owner;

        /// <summary>
        /// Gets the loaded style.
        /// </summary>
        public IStyle Loaded
        {
            get
            {
                RefreshStyles();
                return _style;
            }
        }

        void RefreshStyles()
        {
            _isLoading = true;

            bool firstTime = _style == null;
            if (firstTime)
            {
                _style = (Styles)AvaloniaXamlLoader.Load(PLEX_CORE_URI, _baseUri);
                RefreshColours();

                _childStyles = new IStyle[]
                {
                    _style
                };
            }
            _isLoading = false;
        }

        

        public void RefreshColours(int hue)
        {
            RefreshColours(hue, hue, hue, hue);
        }


        public void RefreshColours(int chromeHue = 210, int toolsMenuAreaHue = 210, int clientAreaBackgroundHue = 210, int controlsHue = 210)
        {
            //var reso = GetLegacyColorResources();
            
            
            
            ThemeColorScheme colorScheme = new ThemeColorScheme()
            {
                {
                    SCM_CHRM,
                    new ThemeColor((byte)GetValidHue(chromeHue), 53, 96) //(byte)((210 - 200) + whatever)
                },
                {
                    SCM_TMNA,
                    new ThemeColor((byte)GetValidHue(toolsMenuAreaHue), 56, 85) //(byte)((210 - 200) + whatever)
                },
                {
                    SCM_CLBG,
                    new ThemeColor((byte)GetValidHue(clientAreaBackgroundHue + 7), 12, 90) //(byte)((217 - 200) + whatever)
                },
                {
                    SCM_CTRL,
                    new ThemeColor((byte)GetValidHue(controlsHue - 5), 62, 99) //(byte)((205 - 200) + whatever)
                },
            };
            


            var testResources = _themeRules.ToValuesDictionary(colorScheme);

            
            //Console.WriteLine("TEST RESOURCES:\n");
            if (_style is Styles styleRes)
            {
                var tKeys = testResources.Keys;
                //var rKeys = reso.Keys.Where(x => !tKeys.Contains(x));
                
                /*foreach (object key in rKeys)
                {
                    //Console.WriteLine("KEY: " + key);
                    styleRes.Resources[key] = reso[key];
                }*/

                foreach (string resKey in tKeys)
                {
                    /*var val = testResources[resKey];
                    if (val is Avalonia.Media.IBrush brush)
                        Console.WriteLine($"{resKey} BRUSH: {brush}, {brush.GetType()}");
                    else
                        Console.WriteLine($"{resKey}: {val}, {val.GetType()}");*/
                    

                    styleRes.Resources[resKey] = testResources[resKey];
                }
            }
            //Console.WriteLine("\n");
        }


        static int GetValidHue(int potentiallyInvalidHue)
        {
            if (false)
            {
                int whatever = potentiallyInvalidHue;
                while (whatever < 0)
                {
                    whatever += 255;
                }
                while (whatever > 255)
                {
                    whatever -= 255;
                }
                return whatever;
            }
            
            return Math.Clamp(potentiallyInvalidHue, 0, 255);
        }

        /*IResourceDictionary GetLegacyColorResources()
        {
            return (IResourceDictionary)AvaloniaXamlLoader.Load(PLEX_TEMPCOLOURS_URI, _baseUri);
        }*/
        
        /*void zRefreshColours()
        {
            var reso = GetLegacyColorResources();
            if (_style is Styles styleRes)
            {
                var keys = reso.Keys;
                
                foreach (object key in keys)
                {
                    //Console.WriteLine("KEY: " + key);
                    styleRes.Resources[key] = reso[key];
                }
            }


            /*var rules = new RuleGroup("RuleGroupTest")
            {
                new AvaloniaThemeColorization.Rules.SolidColorBrushRule("SolidColorBrushRuleTest", "Background", 128, 255, 128),
                new LinearGradientBrushRule("LinearGradientBrushRuleTest", new RelativePoint(0, 0, RelativeUnit.Relative), new RelativePoint(5, 0, RelativeUnit.Relative))
                {
                    new GradientStopRule("GradientStopRuleTest1", "Background", 0, 128, 128, 0),
                    new GradientStopRule("GradientStopRuleTest2", "Background", 0, 128, 128, 255)
                }
            };

            var testResources = rules.ToResources(new ThemeColorScheme()
            {
                {
                    "Background",
                    new ThemeColor(0)
                }
            }, new IColorRule[0]);*

            string color1 = "TestColor1";
            string color2 = "TestColor2";


            ThemeColorScheme colorScheme = new ThemeColorScheme()
            {
                {
                    color1,
                    new ThemeColor(0x00, 0x7F, 0x7F)
                },
                {
                    color2,
                    new ThemeColor(0x7F, 0xFF, 0x40)
                },
            };
            
            var testResources = new ThemeRuleGroup("ThemeRuleGroupTest")
            {
                new ThemeRuleGroup("ThemeRuleGroupTest1")
                {
                    new ThemeRuleGroup("ThemeRuleGroupTest1A")
                    {
                        new SolidColorBrushThemeRule("ThemeSolidColorBrushRuleTest1A1", color1, 0xFF, 0x7F),
                        new SolidColorBrushThemeRule("ThemeSolidColorBrushRuleTest1A2", color2, 0xFF, 0x7F)
                    },
                    new ThemeRuleGroup("ThemeRuleGroupTest1B")
                    {

                    },
                    new SolidColorBrushThemeRule("ThemeSolidColorBrushRuleTest1C", color2, 0xFF, 0x7F)
                },
                new ThemeRuleGroup("ThemeRuleGroupTest2")
                {
                    new SolidColorBrushThemeRule("ThemeSolidColorBrushRuleTest2A", color1, 0xFF, 0x7F),
                    new ThemeRuleGroup("ThemeRuleGroupTest2B")
                    {

                    }
                },
                new SolidColorBrushThemeRule("ThemeSolidColorBrushRuleTest3", color2, 0xFF, 0x7F)
            }.ToValuesDictionary(colorScheme);


            Console.WriteLine("TEST RESOURCES:\n");
            foreach (string resKey in testResources.Keys)
            {
                var val = testResources[resKey];
                if (val is Avalonia.Media.IBrush brush)
                    Console.WriteLine($"{resKey} BRUSH: {brush}, {brush.GetType()}");
                else
                    Console.WriteLine($"{resKey}: {val}, {val.GetType()}");
            }
            Console.WriteLine("\n");
        }*/

        bool IResourceNode.HasResources => (Loaded as IResourceProvider)?.HasResources ?? false;

        IReadOnlyList<IStyle> IStyle.Children => _childStyles ?? Array.Empty<IStyle>();

        public event EventHandler OwnerChanged
        {
            add
            {
                if (Loaded is IResourceProvider rp)
                {
                    rp.OwnerChanged += value;
                }
            }
            remove
            {
                if (Loaded is IResourceProvider rp)
                {
                    rp.OwnerChanged -= value;
                }
            }
        }

        public SelectorMatchResult TryAttach(IStyleable target, IStyleHost? host) => Loaded.TryAttach(target, host);

        public bool TryGetResource(object key, out object? value)
        {
            if (!_isLoading && Loaded is IResourceProvider p)
            {
                return p.TryGetResource(key, out value);
            }

            value = null;
            return false;
        }

        void IResourceProvider.AddOwner(IResourceHost owner) => (Loaded as IResourceProvider)?.AddOwner(owner);
        void IResourceProvider.RemoveOwner(IResourceHost owner) => (Loaded as IResourceProvider)?.RemoveOwner(owner);



        static byte Over100ToOver255(byte over100)
        {
            return (byte)(((double)over100 / 100.0) * 255.0);
        }
    }
}