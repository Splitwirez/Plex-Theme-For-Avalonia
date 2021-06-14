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
using Avalonia.Controls.Chrome;

namespace AvaloniaPlexTheme
{
    public class WindowTitleBar : ItemsControl
    {
        public const string TitleEmphasisStart = "[b]";
        public const string TitleEmphasisEnd = "[/b]";

        
        //condition ? condition==true : condition==false
        static HorizontalAlignment DefaultCaptionButtonsAlignment => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? HorizontalAlignment.Left : HorizontalAlignment.Right;
        public static readonly StyledProperty<HorizontalAlignment> DesiredCaptionButtonsAlignmentProperty =
            AvaloniaProperty.Register<WindowTitleBar, HorizontalAlignment>(nameof(DesiredCaptionButtonsAlignment), defaultValue: DefaultCaptionButtonsAlignment);
        
        public HorizontalAlignment DesiredCaptionButtonsAlignment
        {
            get => GetValue(DesiredCaptionButtonsAlignmentProperty);
            set => SetValue(DesiredCaptionButtonsAlignmentProperty, value);
        }



        public static readonly StyledProperty<CaptionButtons> WindowCaptionButtonsProperty =
            AvaloniaProperty.Register<WindowTitleBar, CaptionButtons>(nameof(WindowCaptionButtons), defaultValue: null);
        
        public CaptionButtons WindowCaptionButtons
        {
            get => GetValue(WindowCaptionButtonsProperty);
            set => SetValue(WindowCaptionButtonsProperty, value);
        }



        public static readonly AttachedProperty<double> LeftCaptionButtonsWidthProperty =
            AvaloniaProperty.RegisterAttached<WindowTitleBar, Window, double>("LeftCaptionButtonsWidth");
        public static double GetLeftCaptionButtonsWidth(Window window)
        {
            return window.GetValue(WindowTitleBar.LeftCaptionButtonsWidthProperty);
        }
        internal static void SetLeftCaptionButtonsWidth(Window window, double newLeftCaptionButtonsWidth)
        {
            window.SetValue(WindowTitleBar.LeftCaptionButtonsWidthProperty, newLeftCaptionButtonsWidth);
        }
        double _leftCaptionButtonsWidth = 0;


        public static readonly AttachedProperty<double> RightCaptionButtonsWidthProperty =
            AvaloniaProperty.RegisterAttached<WindowTitleBar, Window, double>("RightCaptionButtonsWidth");
        public static double GetRightCaptionButtonsWidth(Window window)
        {
            return window.GetValue(WindowTitleBar.RightCaptionButtonsWidthProperty);
        }
        internal static void SetRightCaptionButtonsWidth(Window window, double newRightCaptionButtonsWidth)
        {
            window.SetValue(WindowTitleBar.RightCaptionButtonsWidthProperty, newRightCaptionButtonsWidth);
        }
        double _rightCaptionButtonsWidth = 0;


        
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
            WindowTitleBar.WindowCaptionButtonsProperty.Changed.AddClassHandler<WindowTitleBar>((s, e) =>
            {
                CaptionButtons oldValue = null;
                CaptionButtons newValue = null;
                
                if ((e.OldValue != null) && (e.OldValue is CaptionButtons oldVal))
                    oldValue = oldVal;
                
                if ((e.NewValue != null) && (e.NewValue is CaptionButtons newVal))
                    newValue = newVal;

                s.OnWindowCaptionButtonsPropertyChanged(oldValue, newValue);
            });


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



        Window _rootWindow = null;
        /*protected Window RootWindow 
        {
            //get => _rootWindow;
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
        }*/

        /*protected Window RootWindow
        {
            get
            {
                if ((VisualRoot != null) && (VisualRoot is Window win))
                    return win;
                else
                    return null;
            }
        }*/


        public virtual void OnWindowCaptionButtonsPropertyChanged(CaptionButtons oldButtons, CaptionButtons newButtons)
        {
            if (oldButtons != null)
                DetachCaptionButtons(oldButtons);
            
            if ((newButtons != null) && (_rootWindow != null))
                AttachCaptionButtons(newButtons);
        }

        void AttachCaptionButtons(CaptionButtons newButtons)
        {
            newButtons.Attach(_rootWindow);
            newButtons.LayoutUpdated += CaptionButtons_LayoutUpdated;
            RefreshCaptionButtonWidthProperties(newButtons);
        }

        void DetachCaptionButtons(CaptionButtons oldButtons)
        {
            oldButtons.Detach();
            oldButtons.LayoutUpdated -= CaptionButtons_LayoutUpdated;
            RefreshCaptionButtonWidthProperties(null);
        }



        void CaptionButtons_LayoutUpdated(object sender, EventArgs e)
        {
            if ((_rootWindow != null) && (sender != null) && (sender is CaptionButtons captionButtons))
                RefreshCaptionButtonWidthProperties(captionButtons);
            else
                RefreshCaptionButtonWidthProperties(null);
        }

        
        //void RefreshCaptionButtonWidthProperties() => RefreshCaptionButtonWidthProperties(WindowCaptionButtons);
        void RefreshCaptionButtonWidthProperties(CaptionButtons captionButtons)
        {
            if (_rootWindow.ExtendClientAreaToDecorationsHint && (captionButtons != null))
            {
                if (DesiredCaptionButtonsAlignment == HorizontalAlignment.Left)
                {
                    SetLeftCaptionButtonsWidth(_rootWindow, captionButtons.Bounds.Width);
                    SetRightCaptionButtonsWidth(_rootWindow, 0);
                }
                else
                {
                    SetRightCaptionButtonsWidth(_rootWindow, captionButtons.Bounds.Width);
                    SetLeftCaptionButtonsWidth(_rootWindow, 0);
                }
            }
            else
            {
                SetRightCaptionButtonsWidth(_rootWindow, 0);
                SetLeftCaptionButtonsWidth(_rootWindow, 0);
            }
        }


        protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnAttachedToVisualTree(e);
            var captionButtons = WindowCaptionButtons;

            if (e.Root is Window window)
                _rootWindow = window;

            if (captionButtons != null)
                AttachCaptionButtons(captionButtons);
        }

        protected override void OnDetachedFromVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnDetachedFromVisualTree(e);
            var captionButtons = WindowCaptionButtons;

            if (captionButtons != null)
                DetachCaptionButtons(captionButtons);

            _rootWindow = null;
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

            /*e.NameScope.Find<Button>("PART_CloseButton").Click += (s, a) =>
            {
                if (VisualRoot.GetVisualRoot() is Window win)
                    win.Close();
            };

            e.NameScope.Find<Button>("PART_MaximizeButton").Click += (s, a) => ToggleMaximize();

            e.NameScope.Find<Button>("PART_MinimizeButton").Click += (s, a) =>
            {
                if (VisualRoot.GetVisualRoot() is Window win)
                    win.WindowState = WindowState.Minimized;
            };*/

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