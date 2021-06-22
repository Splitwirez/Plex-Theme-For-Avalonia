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
        private static Uri PLEX_CORE_URI = new Uri("avares://AvaloniaPlexTheme/PlexBase.axaml", UriKind.Absolute);
        private static readonly ResourceDictionary EMPTY = new ResourceDictionary();

        //private static Uri PLEX_TEMPCOLOURS_URI = new Uri("avares://AvaloniaPlexTheme/Colors/LightBlueReso.axaml", UriKind.Absolute);

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



        PlexColorScheme _colorScheme = new PlexColorScheme(210, PlexColorMode.Bright);
        /*{
            Chrome = new ThemeColor(210, 53, 96),
            ToolsMenuArea = new ThemeColor(210, 56, 85),
            Background = new ThemeColor(217, 12, 90),
            Controls = new ThemeColor(205, 62, 99),
            ColorMode = PlexColorMode.Bright
        };*/

        public PlexColorScheme ColorScheme
        {
            get => _colorScheme;
            set
            {
                _colorScheme = value;
                RefreshColours();
            }
        }



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

        
        //List<KeyValuePair<object, object>> _fixed = new List<KeyValuePair<object, object>>();
        void RefreshStyles()
        {
            _isLoading = true;

            bool firstTime = _style == null;
            if (firstTime)
            {
                _style = (Styles)AvaloniaXamlLoader.Load(PLEX_CORE_URI, _baseUri);

                //_style.Resources = _fixed;
                //RefreshResources();
                RefreshColours();
                //OwnerChanged += Styles_OwnerChanged;

                _childStyles = new IStyle[]
                {
                    _style
                };
            }
            _isLoading = false;
        }

        /*void Styles_OwnerChanged(object sender, EventArgs e)
        {
            RefreshResources(this.Owner);
            (sender as Styles).OwnerChanged -= Styles_OwnerChanged;
        }*/

        
        void RefreshColours() =>
            RefreshColours(ColorScheme);
        
        bool _isRefreshingColors = false;
        void RefreshColours(IThemeColorScheme colorScheme)
        {
            _isRefreshingColors = true;
            //_style.Resources = EMPTY;
            /*for (int rIndex = 0; rIndex < _themeRules.Count; rIndex++)
            {
                Console.WriteLine($"Rule {rIndex} is " + (_themeRules[rIndex] != null ? "NON-NULL" : "NULL") );
            }*/


            var testResources = _themeRules.ToChangingResources(colorScheme);
            if (_style is Styles styleRes)
            {
                var tKeys = testResources.Keys;

                foreach (string resKey in tKeys)
                {
                    var newVal = testResources[resKey];
                    //Console.WriteLine($"Setting color {resKey} to {newVal}");
                    
                    styleRes.Resources[resKey] = newVal;
                }
            }
            _isRefreshingColors = false;
            //_style.Resources = _fixed;
            Owner?.NotifyHostedResourcesChanged(ResourcesChangedEventArgs.Empty);
        }

        void RefreshResources() =>
            RefreshResources(Owner);

        
        void RefreshResources(IResourceHost owner)
        {
            Console.WriteLine("RefreshResources");

            var testResources = _themeRules.ToFixedResources(ColorScheme, owner);
                
            var tKeys = testResources.Keys;

            foreach (string resKey in tKeys)
            {
                //_fixed.Add(new KeyValuePair(resKey, tKeys));
                _style.Resources[resKey] = testResources[resKey];
            }
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
            if ((!_isRefreshingColors) && (!_isLoading && Loaded is IResourceProvider p))
            {
                return p.TryGetResource(key, out value);
            }

            value = null;
            return false;
        }

        void IResourceProvider.AddOwner(IResourceHost owner)
        {
            (Loaded as IResourceProvider)?.AddOwner(owner);
            RefreshResources(owner);
            //RefreshColours();
        }

        void IResourceProvider.RemoveOwner(IResourceHost owner) => (Loaded as IResourceProvider)?.RemoveOwner(owner);
    }

    /*public partial class PlexTheme : IStyle, IResourceProvider
    {
        private static Uri PLEX_CORE_URI = new Uri("avares://AvaloniaPlexTheme/PlexBase.axaml", UriKind.Absolute);

        //private static Uri PLEX_TEMPCOLOURS_URI = new Uri("avares://AvaloniaPlexTheme/Colors/LightBlueReso.axaml", UriKind.Absolute);

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

        private PlexTheme()
        {
            
        }

        public IResourceHost? Owner => (Loaded as IResourceProvider)?.Owner;



        PlexColorScheme _colorScheme = new PlexColorScheme(210);

        /*{
Chrome = new ThemeColor(210, 53, 96),
ToolsMenuArea = new ThemeColor(210, 56, 85),
Background = new ThemeColor(217, 12, 90),
Controls = new ThemeColor(205, 62, 99),
ColorMode = PlexColorMode.Bright
};*

        public PlexColorScheme ColorScheme
        {
            get => _colorScheme;
            set
            {
                _colorScheme = value;
                RefreshColors();
            }
        }



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
                RefreshColors();


                var testResources = _themeRules.ToFixedResources(ColorScheme);
                
                var tKeys = testResources.Keys;

                foreach (string resKey in tKeys)
                {
                    Console.WriteLine($"FIXED RESOURCE KEY: {resKey}");
                    Resources[resKey] = testResources[resKey];
                }


                _childStyles = new IStyle[]
                {
                    _style
                };

                //_resources.RemoveOwner(Owner);
                //_resources.AddOwner(Owner);
            }
            _isLoading = false;
        }

        

        /*void RefreshColors(int hue)
        {
            RefreshColors(hue, hue, hue, hue);
        }


        void RefreshColors(int chromeHue = 210, int toolsMenuAreaHue = 210, int clientAreaBackgroundHue = 210, int controlsHue = 210)
        {
            //var reso = GetLegacyColorResources();
            
            
            
            RefreshColors(new ThemeColorScheme()
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
            });
            
            //foreach (IThemeRule rule in _themeRules)
        }*

        
        void RefreshColors() =>
            RefreshColors(ColorScheme);

        void RefreshColors(IThemeColorScheme colorScheme)
        {
            /*for (int rIndex = 0; rIndex < _themeRules.Count; rIndex++)
            {
                Console.WriteLine($"Rule {rIndex} is " + (_themeRules[rIndex] != null ? "NON-NULL" : "NULL") );
            }*


            var testResources = _themeRules.ToChangingResources(colorScheme);

            
            var tKeys = testResources.Keys;

            foreach (string resKey in tKeys)
            {
                Console.WriteLine($"CHANGING RESOURCE KEY: {resKey}");
                /*((Styles)_style).*
                Resources[resKey] = testResources[resKey];
            }

            //((IResourceHost)Resources).NotifyHostedResourcesChanged(ResourcesChangedEventArgs.Empty);
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



        bool IResourceNode.HasResources => true; //_resources != null); //(Loaded as IResourceProvider)?.HasResources ?? false;

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
            if (Resources.TryGetResource(key, out value))
                return true;
            

            if (!_isLoading && Loaded is IResourceProvider p)
            {
                return p.TryGetResource(key, out value);
            }
            

            value = null;
            return false;
        }

        void IResourceProvider.AddOwner(IResourceHost owner)
        {
            (Loaded as IResourceProvider)?.AddOwner(owner);
            Resources.AddOwner(owner);
        }

        void IResourceProvider.RemoveOwner(IResourceHost owner)
        {
            (Loaded as IResourceProvider)?.RemoveOwner(owner);
            Resources.RemoveOwner(owner);
        }


        
        private IResourceDictionary _resources = new ResourceDictionary();
        public IResourceDictionary Resources
        {
            get => _resources;
            set
            {
                if (Owner is object)
                {
                    _resources.RemoveOwner(Owner);
                }

                _resources = value;

                if (Owner is object)
                {
                    _resources.AddOwner(Owner);
                }
            }
        }
    }*/
}