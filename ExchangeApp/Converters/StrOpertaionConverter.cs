using System.Globalization;

namespace ExchangeApp.Converters;

public class StrOpertaionConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var model = (string)value;

        if (model.Length >= 13)
            return model.Substring(0, 13) + "...";

        return model;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
