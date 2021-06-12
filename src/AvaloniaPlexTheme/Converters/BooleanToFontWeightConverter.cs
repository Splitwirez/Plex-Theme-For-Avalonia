using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace AvaloniaPlexTheme
{
    public class BooleanToFontWeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool invert = false;
            string valStr = string.Empty;
            
            if (value != null)
                valStr = value.ToString();

            if (valStr.StartsWith('!'))
            {
                invert = true;
                valStr = valStr.Substring(1);
            }

            if (bool.TryParse(valStr, out bool val))
            {
                string[] weightStrings = new string[]
                {
                    string.Empty,
                    string.Empty
                };
                FontWeight[] weights = new FontWeight[2]; /*new FontWeight[]
                {
                    (FontWeight)0,
                    (FontWeight)0
                };*/

                string paramStr = string.Empty;
                
                if (parameter != null)
                    paramStr = parameter.ToString();
                
                if (paramStr.Contains(','))
                    weightStrings = paramStr.Split(',');
                else if (paramStr.Contains(' '))
                    weightStrings = paramStr.Split(' ');
                else
                    throw new Exception("Could not separate 'ConverterParameter' into two comma-separated or space-separated parts.");
                
                for (int weightIndex = 0; weightIndex < 2; weightIndex++)
                {
                    string weightString = weightStrings[weightIndex];
                    if (Enum.TryParse<FontWeight>(weightString, false, out FontWeight weight))
                        weights[weightIndex] = weight;
                    else if (int.TryParse(weightString, out int weightI))
                        weights[weightIndex] = (FontWeight)weightI;
                }


                if (val == invert)
                    return weights[0];
                else
                    return weights[1];

                /*if (val)
                {
                    if (invert)
                        return weights[0];
                    else
                        return weights[1];
                }
                else
                {
                    if (invert)
                        return weights[1];
                    else
                        return weights[0];
                }*/
            }
            else
                throw new Exception("Input value was not a boolean.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}