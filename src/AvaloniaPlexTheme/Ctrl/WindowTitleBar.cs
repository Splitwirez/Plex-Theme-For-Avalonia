using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Utils;
using Avalonia.Data;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Visuals;
using Avalonia.VisualTree;
using Avalonia.Reactive;
using System;
using System.Runtime.InteropServices;
using System.Reactive.Linq;
using Avalonia.Controls.Generators;
using System.Collections;

namespace AvaloniaPlexTheme
{
    public class WindowTitleBar : ItemsControl
    {
        public const string TitleEmphasisStart = "[b]";
        public const string TitleEmphasisEnd = "[/b]";

        static bool DefaultToLeftSideButtons => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        public static readonly StyledProperty<bool> LeftSideButtonsProperty =
            AvaloniaProperty.Register<WindowTitleBar, bool>(nameof(LeftSideButtons), defaultValue: DefaultToLeftSideButtons);
        
        public bool LeftSideButtons
        {
            get => GetValue(LeftSideButtonsProperty);
            set => SetValue(LeftSideButtonsProperty, value);
        }


        
        /*public static readonly StyledProperty<double> DefaultHeightProperty =
            AvaloniaProperty.Register<WindowTitleBar, double>(nameof(DefaultHeight), validate: ValidateDefaultHeight);
        static bool ValidateDefaultHeight(double inValue)
        {
            return inValue >= 0;
        }
        public double DefaultHeight
        {
            get => GetValue(DefaultHeightProperty);
            set => SetValue(DefaultHeightProperty, value);
        }


        public static readonly StyledProperty<double> ExtendTitleBarHeightHintProperty =
            AvaloniaProperty.Register<WindowTitleBar, double>(nameof(ExtendTitleBarHeightHint));
        public double ExtendTitleBarHeightHint
        {
            get => GetValue(ExtendTitleBarHeightHintProperty);
            set => SetValue(ExtendTitleBarHeightHintProperty, value);
        }*/

        
        public static readonly StyledProperty<string> UnformattedTitleProperty =
            AvaloniaProperty.Register<WindowTitleBar, string>(nameof(UnformattedTitle));
        public string UnformattedTitle
        {
            get => GetValue(UnformattedTitleProperty);
            set => SetValue(UnformattedTitleProperty, value);
        }


        public static readonly StyledProperty<bool> HasEmphasizeableTitleProperty =
            AvaloniaProperty.Register<WindowTitleBar, bool>(nameof(HasEmphasizeableTitle));
        public bool HasEmphasizeableTitle
        {
            get => GetValue(HasEmphasizeableTitleProperty);
            protected set => SetValue(HasEmphasizeableTitleProperty, value);
        }


        public static readonly StyledProperty<bool> HasTitleProperty =
            AvaloniaProperty.Register<WindowTitleBar, bool>(nameof(HasTitle));
        public bool HasTitle
        {
            get => GetValue(HasTitleProperty);
            protected set => SetValue(HasTitleProperty, value);
        }
        

        public static readonly AttachedProperty<EmphasizeableTextSequence> TitleProperty =
            AvaloniaProperty.RegisterAttached<WindowTitleBar, Window, EmphasizeableTextSequence>("Title");
        public static EmphasizeableTextSequence GetTitle(Window window)
        {
            return window.GetValue(WindowTitleBar.TitleProperty);
        }
        public static void SetTitle(Window window, EmphasizeableTextSequence newTitle)
        {
            window.SetValue(WindowTitleBar.TitleProperty, newTitle);
        }

        static WindowTitleBar()
        {
            //HeightProperty.OverrideMetadata<WindowTitleBar>(new StyledPropertyMetadata<double>(defaultValue: double.NaN, coerce: CoerceHeight));

            //ItemsProperty.Changed.AddClassHandler<WindowTitleBar>(TitlePropertiesChanged);
            //UnformattedTitleProperty.Changed.AddClassHandler<WindowTitleBar>(TitlePropertiesChanged);

            WindowTitleBar.TitleProperty.Changed.AddClassHandler<Window>((sender, e) =>
            {
                if ((e.NewValue != null))
                {
                    sender.Title = e.NewValue.ToString();
                }
            });
        }

        static void TitlePropertiesChanged(WindowTitleBar sender, AvaloniaPropertyChangedEventArgs args)
        {
            sender.RefreshTitleProperties();
        }

        void RefreshTitleProperties()
        {
            /*string regularTitle = UnformattedTitle;
            //EmphasizeableTextSequence seqTitle = null;
            bool hasEmphTitle = false;

            if ((Items != null) && (Items is EmphasizeableTextSequence seqTitle))
                hasEmphTitle = (seqTitle != null) && (seqTitle.Count > 0);
                //seqTitle = seq;

            //bool hasEmphTitle = (seqTitle != null) && (seqTitle.Count > 0);

            HasEmphasizeableTitle = hasEmphTitle;
            HasTitle = hasEmphTitle || ((!string.IsNullOrEmpty(regularTitle)) && (!string.IsNullOrWhiteSpace(regularTitle)));*/
            HasEmphasizeableTitle = true;
            HasTitle = true;
        }
        
        /*static double CoerceHeight(IAvaloniaObject sender, double inValue)
        {
            WindowTitleBar sned = (WindowTitleBar)sender;
            if (inValue < 0)
                return sned.DefaultHeight;
            else
                return inValue;
        }*/

        public WindowTitleBar() : base()
        {
            /*this[!HeightProperty] = this.GetObservable(CaptionHeightProperty).Select(x => 
            {
                if (x < 0)
                    
            });*/

            /*if ((Items != null) && (Items is EmphasizeableTextSequence seq))
                TitlePropertiesChanged(this, new AvaloniaPropertyChangedEventArgs<IEnumerable>(this, ItemsProperty, null, seq, BindingPriority.TemplatedParent));*/
            
            RefreshTitleProperties();
        }

        Window? _rootWindow = null;
        protected Window RootWindow 
        {
            get => _rootWindow;
            set
            {
                if (value != null)
                {
                    //this[!HeightProperty] = value[!Window.ExtendClientAreaTitleBarHeightHintProperty];
                    //this[!ItemsProperty] = value.GetObservable(TitleProperty).Select(x => (IEnumerable)x).ToBinding();
                    //this[!UnformattedTitleProperty] = value[!Window.TitleProperty];
                }
                
                _rootWindow = value;
            }
        }


        /*protected override IItemContainerGenerator CreateItemContainerGenerator()
        {
            return new ItemContainerGenerator<EmphasizeableTextSegment>(this, EmphasizeableTextSegment.TextProperty, ItemTemplateProperty); //EmphasizeableTextSegmentGenerator(this, EmphasizeableTextSegment.TextProperty, ItemTemplateProperty);
        }*/

        /*protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnAttachedToVisualTree(e);
            if ((e.Root != null) && (e.Root is Window win))
                RootWindow = win;
        }

        protected override void OnDetachedFromVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnDetachedFromVisualTree(e);

            if (RootWindow != null)
                RootWindow = null;
        }*/

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            e.NameScope.Find<Button>("PART_CloseButton").Click += (s, a) =>
            {
                if (VisualRoot.GetVisualRoot() is Window win)
                    win.Close();
            };

            e.NameScope.Find<Button>("PART_MaximizeButton").Click += (s, a) => ToggleMaximize();

            e.NameScope.Find<Button>("PART_MinimizeButton").Click += (s, a) =>
            {
                if (VisualRoot.GetVisualRoot() is Window win)
                    win.WindowState = WindowState.Minimized;
            };

            var dragGrip = e.NameScope.Find<TemplatedControl>("PART_DragGrip");
            
            dragGrip.PointerPressed += (s, a) =>
            {
                if (a.ClickCount <= 1)
                {
                    if (VisualRoot.GetVisualRoot() is Window win)
                        win.BeginMoveDrag(a);
                }
            };

            dragGrip.DoubleTapped += (s, a) => ToggleMaximize();
        }

        void ToggleMaximize()
        {
            if (VisualRoot.GetVisualRoot() is Window win)
            {
                if (win.WindowState == WindowState.Maximized)
                    win.WindowState = WindowState.Normal;
                else
                    win.WindowState = WindowState.Maximized;
            }
        }
    }
}