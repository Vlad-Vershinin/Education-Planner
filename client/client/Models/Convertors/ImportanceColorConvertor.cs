using Avalonia.Data.Converters;
using client.Models.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Models.Convertors
{
    public class ImportanceColorConvertor : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is CurriculumImportance cr)
            {
                if (cr == CurriculumImportance.NECESSARY)
                {
                    return Color.Red;
                }
                else if (cr == CurriculumImportance.IMPORTANT)
                {
                    return Color.Yellow;
                }
                else if (cr == CurriculumImportance.CIRCUMSTANTIAL)
                {
                    return Color.White;
                }
                else
                {
                    return Color.Gray;
                }
            }
            else
            {
                return Color.White;
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
