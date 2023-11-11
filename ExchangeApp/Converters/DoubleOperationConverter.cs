using System.Globalization;

namespace ExchangeApp.Converters;

public class DoubleOperationConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (double.TryParse(value.ToString(), out double result))
            return result.ToString("0.00") + " ₺";

        return "0";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
