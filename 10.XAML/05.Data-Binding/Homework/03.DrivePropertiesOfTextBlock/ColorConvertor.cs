using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace _03.DrivePropertiesOfTextBlock
{
    public class ColorConvertor:IValueConverter
    {
        public object Convert(
            object value, 
            Type targetType, 
            object parameter, 
            CultureInfo culture)
        {
            if (targetType != typeof(Brush) || value == null)
            {
                return null;
            }
            else 
            {
                if (value is System.Reflection.PropertyInfo)
                {
                    var colorAccessor = (value as System.Reflection.PropertyInfo).GetValue(value);
                    return new SolidColorBrush((Color)colorAccessor);
                }
                else 
                {
                    return null;
                }
            }
        }
        
        public object ConvertBack(
            object value, 
            Type targetType, 
            object parameter, 
            CultureInfo culture)
        {
            if (value is SolidColorBrush)
            {
                return (value as SolidColorBrush).Color;
            }
            else 
            {
                return null;
            }
        }
    }
}
