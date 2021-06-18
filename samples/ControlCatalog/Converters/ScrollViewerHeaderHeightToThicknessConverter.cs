using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.LogicalTree;
using Avalonia.Markup;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Data.Converters;
using Avalonia.Data;
using System.Globalization;
using Avalonia;

namespace ControlCatalog.Converters
{
    public class zScrollViewerOffsetToIsNotVisibleBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ScrollContentPresenter presenter)
            {
                Vector offset = presenter.Offset; //(Vector)values[0];
                Size extent = presenter.Extent; //(Size)values[1];

                if (Enum.TryParse<Dock>(parameter.ToString(), out Dock dock))
                {
                    switch (dock)
                    {
                        case (Dock.Top):
                            return offset.Y > 0;
                            break;
                        case (Dock.Right):
                            return offset.X < extent.Width;
                        case (Dock.Bottom):
                            return offset.Y < extent.Height;
                            break;
                        default:
                            return offset.X > 0;
                    }
                }
            }
            throw new Exception("WHAT\nHOW");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class ScrollViewerOffsetToIsNotVisibleBoolConverter : IMultiValueConverter
    {
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            Vector offset = (values[0] as Vector?).GetValueOrDefault();
            Size extent = (values[1] as Size?).GetValueOrDefault();

            if ((offset != null) && (extent != null) && Enum.TryParse<Dock>(parameter.ToString(), out Dock dock))
            {
                switch (dock)
                {
                    case (Dock.Top):
                        return offset.Y > 0;
                        break;
                    case (Dock.Right):
                        return offset.X < extent.Width;
                    case (Dock.Bottom):
                        return offset.Y < extent.Height;
                        break;
                    default:
                        return offset.X > 0;
                }
            }
            throw new Exception("WHAT\nHOW");
        }
    }


    //ScrollViewerOffsetFromTop
    public class ScrollViewerHeaderHeightToThicknessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new Thickness(0, (double)value, 0, 0);


            /*double val = (double)value;
            Console.WriteLine($"val: {val}");
            /*object obj = new object();

            Console.WriteLine($"obj: {obj}\nnull: {null}");
            if (val > 0)
                return obj;
            else
                return null;*
            return Math.Max(Math.Min(val, 15), 0);*/
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}