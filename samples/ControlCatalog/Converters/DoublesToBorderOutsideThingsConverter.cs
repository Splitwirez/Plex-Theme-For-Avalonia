using Avalonia.Controls;
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
    public class DoublesToBorderOutsideThingsConverter : IMultiValueConverter
    {
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            double l = (double)values[0];
            double t = (double)values[1];
            double r = (double)values[2];
            double b = (double)values[3];


            if (targetType == typeof(Thickness))
                return new Thickness(l, t, r, b);
            else if (targetType == typeof(CornerRadius))
                return new CornerRadius(l, t, r, b);
            else
                throw new Exception("Don't do that.");
        }
    }
}