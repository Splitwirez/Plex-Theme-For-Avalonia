using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media;
using Avalonia.Platform;

namespace AvaloniaPlexTheme
{
    public class RectAndCornerRadiusToRoundedRectConverter : IMultiValueConverter
    {
        static readonly double reduceRadiusBy = 0.75;

        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            Rect bounds = (Rect)values[0];
            double width = bounds.Width;
            double height = bounds.Height;

            CornerRadius radii = (CornerRadius)values[1];
            double topLeft = radii.TopLeft - reduceRadiusBy;
            double topRight = radii.TopRight - reduceRadiusBy;
            double bottomRight = radii.BottomRight - reduceRadiusBy;
            double bottomLeft = radii.BottomLeft - reduceRadiusBy;

            StreamGeometry retVal = new StreamGeometry();
            using (StreamGeometryContext ctx = retVal.Open())
            {
                ctx.BeginFigure(new Point(0, topLeft), false);
                ctx.ArcTo(new Point(topLeft, 0), new Size(topLeft, topLeft), 90, false, SweepDirection.Clockwise);
                
                ctx.LineTo(new Point(width - topRight, 0));
                ctx.ArcTo(new Point(width, topRight), new Size(topRight, topRight), 90, false, SweepDirection.Clockwise);
                
                ctx.LineTo(new Point(width, height - bottomRight));
                ctx.ArcTo(new Point(width - bottomRight, height), new Size(bottomRight, bottomRight), 90, false, SweepDirection.Clockwise);
                
                ctx.LineTo(new Point(bottomLeft, height));
                ctx.ArcTo(new Point(0, height - bottomLeft), new Size(bottomLeft, bottomLeft), 90, false, SweepDirection.Clockwise);

                ctx.EndFigure(true); //LineTo(new Point(width, height - bottomRight));
            }
            
            return retVal;
        }
    }
}