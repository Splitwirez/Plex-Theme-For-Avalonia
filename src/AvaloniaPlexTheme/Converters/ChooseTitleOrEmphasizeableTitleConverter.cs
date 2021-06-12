using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Avalonia.Data.Converters;

namespace AvaloniaPlexTheme
{
    public class ChooseTitleOrEmphasizeableTitleConverter : IMultiValueConverter
    {
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            EmphasizeableTextSequence segTitle = values.OfType<EmphasizeableTextSequence>().FirstOrDefault();
            string strTitle = values.OfType<string>().FirstOrDefault();
            if ((segTitle == null) || (segTitle.Count <= 0))
                return strTitle;
            else
                return segTitle;
        }
    }
}