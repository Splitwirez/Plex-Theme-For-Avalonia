using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaPlexTheme
{
    public class RelativeBrushDecorator : Decorator
    {
        /// <summary>
        /// Defines the <see cref="Background"/> property.
        /// </summary>
        public static readonly StyledProperty<IBrush> BackgroundProperty =
            Border.BackgroundProperty.AddOwner<RelativeBrushDecorator>();
        
        /// <summary>
        /// Gets or sets a brush with which to paint the background.
        /// </summary>
        public IBrush Background
        {
            get => GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }



        /// <summary>
        /// Defines the <see cref="BoxShadow"/> property.
        /// </summary>
        public static readonly StyledProperty<BoxShadows> BoxShadowProperty =
            Border.BoxShadowProperty.AddOwner<RelativeBrushDecorator>();
        
        /// <summary>
        /// Gets or sets the box shadow effect parameters
        /// </summary>
        public BoxShadows BoxShadow
        {
            get => GetValue(BoxShadowProperty);
            set => SetValue(BoxShadowProperty, value);
        }



        /// <summary>
        /// Defines the <see cref="CornerRadius"/> property.
        /// </summary>
        public static readonly StyledProperty<CornerRadius> CornerRadiusProperty =
            Border.CornerRadiusProperty.AddOwner<RelativeBrushDecorator>();
        
        /// <summary>
        /// Gets or sets the radius of the border rounded corners.
        /// </summary>
        public CornerRadius CornerRadius
        {
            get => GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }


        
        /// <summary>
        /// Defines the <see cref="DrawRelativeTo"/> property.
        /// </summary>
        public static readonly StyledProperty<Visual> DrawRelativeToProperty =
            AvaloniaProperty.Register<RelativeBrushDecorator, Visual>(nameof(DrawRelativeTo));
        
        /// <summary>
        /// Gets or sets a visual to position the border's brushes relative to when rendering.
        /// </summary>
        public Visual DrawRelativeTo
        {
            get => GetValue(DrawRelativeToProperty);
            set => SetValue(DrawRelativeToProperty, value);
        }

        private readonly RelativeBrushBorderRenderHelper _renderHelper = new RelativeBrushBorderRenderHelper();


        static RelativeBrushDecorator()
        {
            AffectsRender<RelativeBrushDecorator>(BackgroundProperty, CornerRadiusProperty, BoxShadowProperty, DrawRelativeToProperty);
        }

        
        /// <summary>
        /// Renders the control.
        /// </summary>
        /// <param name="context">The drawing context.</param>
        public override void Render(DrawingContext context)
        {
            var relTo = DrawRelativeTo;
            var visRoot = VisualRoot;
            //.TranslatePoint(new Point(0, 0), visRoot), DrawRelativeTo.TranslatePoint(new Point(DrawRelativeTo.Bounds.Size), visRoot)
            if ((relTo != null) && (visRoot != null) && (visRoot == Avalonia.VisualTree.VisualExtensions.GetVisualRoot(relTo)))
            {
                _renderHelper.Render(context, relTo, this, CornerRadius, Background, BoxShadow);
            }
            else
            {
                _renderHelper.Render(context, this, this, CornerRadius, Background, BoxShadow);
                //base.Render(context);
            }
        }
    }
}