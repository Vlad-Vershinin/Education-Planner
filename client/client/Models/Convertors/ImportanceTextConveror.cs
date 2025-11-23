using Avalonia.Data.Converters;
using client.Models.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Models.Convertors
{
    public class ImportanceTextConveror : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is CurriculumImportance cr)
            {
                if (cr == CurriculumImportance.NECESSARY)
                {
                    return "Необходим";
                }
                else if (cr == CurriculumImportance.IMPORTANT)
                {
                    return "Рекомендован";
                }
                else if (cr == CurriculumImportance.CIRCUMSTANTIAL)
                {
                    return "Опционален";
                }
                else
                {
                    return "Не важен";
                }
            }
            else
            {
                return "-";
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
