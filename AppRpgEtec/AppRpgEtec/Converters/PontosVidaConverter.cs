using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Graphics.Converters;
using Microsoft.Maui.Graphics.Converters;

namespace AppRpgEtec.Converters
{
    internal class PontosVidaConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            ColorTypeConverter converter = new ColorTypeConverter();
            int pontosVida = (int)value;
            if (pontosVida == 100)
                return (Color)converter.ConvertFromInvariantString("Green");
            else if (pontosVida >= 75)
                return (Color)converter.ConvertFromInvariantString("Yellow");
            else if (pontosVida >= 25)
                return (Color)converter.ConvertFromInvariantString("Orange");
            else if (pontosVida >= 1)
                return (Color)converter.ConvertFromInvariantString("Red");

            throw new NotImplementedException();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
