using System;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Utilities;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Utils;

namespace AvaloniaPlexTheme
{
    public class RelativeBrushBorderRenderHelper
    {
        static readonly Point _zeroPoint = new Point(0, 0);

        private StreamGeometry _clipGeometry;
        
        private Rect _drawTo;
        private Size _size;
        private Point _topLeft;

        private Size _relativeToSize;
        private Point _relativeToTopLeft;

        private Vector _transform;
        private CornerRadius _cornerRadius;
        private bool _initialized;

        void Update(Visual relativeTo, Visual dest, CornerRadius cornerRadius)
        {
            if (relativeTo == dest)
            {
                _transform = Vector.Zero;
                _drawTo = new Rect(_zeroPoint, dest.Bounds.Size);
            }
            else
            {
                var destTopLeft = dest.Bounds.TopLeft;
                var relativeToTopLeft = relativeTo.Bounds.TopLeft;
                
                _transform = new Vector(relativeToTopLeft.X - destTopLeft.X, relativeToTopLeft.Y - destTopLeft.Y);
                
                _drawTo = new Rect(_zeroPoint, relativeTo.Bounds.Size);
            }


            Size finalSize = dest.Bounds.Size;
            _size = finalSize;
            
            _cornerRadius = cornerRadius;
            _initialized = true;

            var boundRect = new Rect(finalSize);


            if (boundRect.Width != 0 && boundRect.Height != 0)
            {
                var geometryKeypoints = new BorderGeometryKeypoints(boundRect, cornerRadius, false);
                var geometry = new StreamGeometry();

                using (var ctx = geometry.Open())
                {
                    CreateGeometry(ctx, boundRect, geometryKeypoints);
                }

                _clipGeometry = geometry;
            }
            else
            {
                _clipGeometry = null;
            }
        }

        public void Render(DrawingContext context, Visual relativeTo, Visual dest, /*Thickness borderThickness, */CornerRadius cornerRadius,
            IBrush background, /*IBrush borderBrush, */BoxShadows boxShadows)
        {
            //Size finalSize = destBounds.Size;

            var relTopLeft = relativeTo.TranslatePoint(_zeroPoint, dest);
            //var relBottomRight = relativeTo.TranslatePoint(new Point(relativeTo.Bounds.Width, relativeTo.Bounds.Height), dest);
            if (
                    (_size != dest.Bounds.Size) ||
                    (_topLeft != dest.Bounds.TopLeft) ||
                    (_relativeToSize != relativeTo.Bounds.Size) ||
                    (_relativeToTopLeft != relTopLeft) ||
                    //(_borderThickness != borderThickness) ||
                    (_cornerRadius != cornerRadius) ||
                    (!_initialized)
                )
            {
                Update(relativeTo, dest, cornerRadius);
            }
            
            RenderCore(context, dest, background, boxShadows);
        }

        void RenderCore(DrawingContext context, Visual dest, IBrush background, BoxShadows boxShadows)
        {
            using (var trfCtx = context.PushTransformContainer())
            {
                if (_clipGeometry != null)
                {
                    using (var idk = context.PushGeometryClip(_clipGeometry))
                    {
                        using (var trf = context.PushSetTransform(Matrix.CreateTranslation(_transform)))
                        {
                            context.DrawRectangle(background, null, _drawTo);
                        }
                    }
                }
            }
        }

        private static void CreateGeometry(StreamGeometryContext context, Rect boundRect, BorderGeometryKeypoints keypoints)
        {
            context.BeginFigure(keypoints.TopLeft, true);

            // Top
            context.LineTo(keypoints.TopRight);

            // TopRight corner
            var radiusX = boundRect.TopRight.X - keypoints.TopRight.X;
            var radiusY = keypoints.RightTop.Y - boundRect.TopRight.Y;
            if (radiusX != 0 || radiusY != 0)
            {
                context.ArcTo(keypoints.RightTop, new Size(radiusX, radiusY), 0, false, SweepDirection.Clockwise);
            }

            // Right
            context.LineTo(keypoints.RightBottom);

            // BottomRight corner
            radiusX = boundRect.BottomRight.X - keypoints.BottomRight.X;
            radiusY = boundRect.BottomRight.Y - keypoints.RightBottom.Y;
            if (radiusX != 0 || radiusY != 0)
            {
                context.ArcTo(keypoints.BottomRight, new Size(radiusX, radiusY), 0, false, SweepDirection.Clockwise);
            }

            // Bottom
            context.LineTo(keypoints.BottomLeft);

            // BottomLeft corner
            radiusX = keypoints.BottomLeft.X - boundRect.BottomLeft.X;
            radiusY = boundRect.BottomLeft.Y - keypoints.LeftBottom.Y;
            if (radiusX != 0 || radiusY != 0)
            {
                context.ArcTo(keypoints.LeftBottom, new Size(radiusX, radiusY), 0, false, SweepDirection.Clockwise);
            }

            // Left
            context.LineTo(keypoints.LeftTop);

            // TopLeft corner
            radiusX = keypoints.TopLeft.X - boundRect.TopLeft.X;
            radiusY = keypoints.LeftTop.Y - boundRect.TopLeft.Y;

            if (radiusX != 0 || radiusY != 0)
            {
                context.ArcTo(keypoints.TopLeft, new Size(radiusX, radiusY), 0, false, SweepDirection.Clockwise);
            }

            context.EndFigure(true);
        }

        private class BorderGeometryKeypoints
        {
            /*internal BorderGeometryKeypoints(Rect boundRect, Thickness borderThickness, CornerRadius cornerRadius, bool inner)
            {
                double safeRight = ((borderThickness.Left + borderThickness.Right) / 2);
                double safeBottom = ((borderThickness.Top + borderThickness.Bottom) / 2);
                double safeLeft = boundRect.Width - ((borderThickness.Left + borderThickness.Right) / 2);
                double safeTop = boundRect.Height - ((borderThickness.Top + borderThickness.Bottom) / 2);

                //CornerRadius cornerRadius = new CornerRadius(Math.Min(cornerRadiusa.TopLeft, safeWidth), , , );
                var left = 0.5 * borderThickness.Left;
                var top = 0.5 * borderThickness.Top;
                var right = 0.5 * borderThickness.Right;
                var bottom = 0.5 * borderThickness.Bottom;

                double leftTopY;
                double topLeftX;
                double topRightX;
                double rightTopY;
                double rightBottomY;
                double bottomRightX;
                double bottomLeftX;
                double leftBottomY;

                if (inner)
                {
                    leftTopY = Math.Max(0, cornerRadius.TopLeft - top) + boundRect.TopLeft.Y;
                    topLeftX = Math.Max(0, cornerRadius.TopLeft - left) + boundRect.TopLeft.X;
                    topRightX = boundRect.Width - Math.Max(0, cornerRadius.TopRight - top) + boundRect.TopLeft.X;
                    rightTopY = Math.Max(0, cornerRadius.TopRight - right) + boundRect.TopLeft.Y;
                    rightBottomY = boundRect.Height - Math.Max(0, cornerRadius.BottomRight - bottom) + boundRect.TopLeft.Y;
                    bottomRightX = boundRect.Width - Math.Max(0, cornerRadius.BottomRight - right) + boundRect.TopLeft.X;
                    bottomLeftX = Math.Max(0, cornerRadius.BottomLeft - left) + boundRect.TopLeft.X;
                    leftBottomY = boundRect.Height - Math.Max(0, cornerRadius.BottomLeft - bottom) + boundRect.TopLeft.Y;
                }
                else
                {
                    leftTopY = cornerRadius.TopLeft + top + boundRect.TopLeft.Y;
                    topLeftX = cornerRadius.TopLeft + left + boundRect.TopLeft.X;
                    topRightX = boundRect.Width - (cornerRadius.TopRight + right) + boundRect.TopLeft.X;
                    rightTopY = cornerRadius.TopRight + top + boundRect.TopLeft.Y;
                    rightBottomY = boundRect.Height - (cornerRadius.BottomRight + bottom) + boundRect.TopLeft.Y;
                    bottomRightX = boundRect.Width - (cornerRadius.BottomRight + right) + boundRect.TopLeft.X;
                    bottomLeftX = cornerRadius.BottomLeft + left + boundRect.TopLeft.X;
                    leftBottomY = boundRect.Height - (cornerRadius.BottomLeft + bottom) + boundRect.TopLeft.Y;
                }

                var leftTopX = boundRect.TopLeft.X;
                var topLeftY = boundRect.TopLeft.Y;
                var topRightY = boundRect.TopLeft.Y;
                var rightTopX = boundRect.Width + boundRect.TopLeft.X;
                var rightBottomX = boundRect.Width + boundRect.TopLeft.X;
                var bottomRightY = boundRect.Height + boundRect.TopLeft.Y;
                var bottomLeftY = boundRect.Height + boundRect.TopLeft.Y;
                var leftBottomX = boundRect.TopLeft.X;

                LeftTop = new Point(leftTopX, leftTopY);
                TopLeft = new Point(topLeftX, topLeftY);
                TopRight = new Point(topRightX, topRightY);
                RightTop = new Point(rightTopX, rightTopY);
                RightBottom = new Point(rightBottomX, rightBottomY);
                BottomRight = new Point(bottomRightX, bottomRightY);
                BottomLeft = new Point(bottomLeftX, bottomLeftY);
                LeftBottom = new Point(leftBottomX, leftBottomY);

                // Fix overlap
                if (TopLeft.X > TopRight.X)
                {
                    var scaledX = topLeftX / (topLeftX + topRightX) * boundRect.Width;
                    TopLeft = new Point(scaledX, TopLeft.Y);
                    TopRight = new Point(scaledX, TopRight.Y);
                }

                if (RightTop.Y > RightBottom.Y)
                {
                    var scaledY = rightBottomY / (rightTopY + rightBottomY) * boundRect.Height;
                    RightTop = new Point(RightTop.X, scaledY);
                    RightBottom = new Point(RightBottom.X, scaledY);
                }

                if (BottomRight.X < BottomLeft.X)
                {
                    var scaledX = bottomLeftX / (bottomLeftX + bottomRightX) * boundRect.Width;
                    BottomRight = new Point(scaledX, BottomRight.Y);
                    BottomLeft = new Point(scaledX, BottomLeft.Y);
                }

                if (LeftBottom.Y < LeftTop.Y)
                {
                    var scaledY = leftTopY / (leftTopY + leftBottomY) * boundRect.Height;
                    LeftBottom = new Point(LeftBottom.X, scaledY);
                    LeftTop = new Point(LeftTop.X, scaledY);
                }

                if (false)
                {
                    Point WithSafeLeft(Point point) =>
                        point.WithX(Math.Max(point.X, safeLeft));
                    
                    Point WithSafeTop(Point point) =>
                        point.WithY(Math.Max(point.Y, safeTop));
                    
                    Point WithSafeRight(Point point) =>
                        point.WithX(Math.Min(point.X, safeRight));
                    
                    Point WithSafeBottom(Point point) =>
                        point.WithY(Math.Min(point.Y, safeBottom));



                    
                    
                    TopLeft = WithSafeTop(WithSafeLeft(TopLeft));
                    LeftTop = WithSafeTop(WithSafeLeft(LeftTop));
                    
                    TopRight = WithSafeTop(WithSafeRight(TopRight));
                    RightTop = WithSafeTop(WithSafeRight(RightTop));

                    BottomRight = WithSafeBottom(WithSafeRight(BottomRight));
                    RightBottom = WithSafeBottom(WithSafeRight(RightBottom));

                    BottomLeft = WithSafeBottom(WithSafeLeft(BottomLeft));
                    LeftBottom = WithSafeBottom(WithSafeLeft(LeftBottom));
                }
            }*/

            internal BorderGeometryKeypoints(Rect boundRect, CornerRadius cornerRadius, bool inner)
            {
                TopLeft = boundRect.TopLeft;
                LeftTop = boundRect.TopLeft;

                TopRight = boundRect.TopRight;
                RightTop = boundRect.TopRight;

                BottomRight = boundRect.BottomRight;
                RightBottom = boundRect.BottomRight;

                BottomLeft = boundRect.BottomLeft;
                LeftBottom = boundRect.BottomLeft;



                TopLeft = TopLeft.WithX(TopLeft.X + Math.Min(cornerRadius.TopLeft, boundRect.Width));
                LeftTop = LeftTop.WithY(LeftTop.Y + Math.Min(cornerRadius.TopLeft, boundRect.Height));

                TopRight = TopRight.WithX(TopRight.X - Math.Min(cornerRadius.TopRight, boundRect.Width));
                RightTop = RightTop.WithY(RightTop.Y + Math.Min(cornerRadius.TopRight, boundRect.Height));

                BottomRight = BottomRight.WithX(BottomRight.X - Math.Min(cornerRadius.BottomRight, boundRect.Width));
                RightBottom = RightBottom.WithY(RightBottom.Y - Math.Min(cornerRadius.BottomRight, boundRect.Height));

                BottomLeft = BottomLeft.WithX(BottomLeft.X + Math.Min(cornerRadius.BottomLeft, boundRect.Width));
                LeftBottom = LeftBottom.WithY(LeftBottom.Y - Math.Min(cornerRadius.BottomLeft, boundRect.Height));
            }

            internal Point LeftTop { get; }

            internal Point TopLeft { get; }

            internal Point TopRight { get; }

            internal Point RightTop { get; }

            internal Point RightBottom { get; }

            internal Point BottomRight { get; }

            internal Point BottomLeft { get; }

            internal Point LeftBottom { get; }
        }
    }
}
