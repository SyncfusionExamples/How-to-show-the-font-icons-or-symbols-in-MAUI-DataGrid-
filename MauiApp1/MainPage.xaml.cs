

using System.Globalization;

namespace MauiApp1
{

    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }
    }

    public class CustomValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = value.ToString();
            if (val == "circle")
            {
                return IconCodes.Circle;
            }
            else if (val == "square")
            {
                
                return IconCodes.Square; 
            }
            else if (val == "triangle")
            {
                return IconCodes.TriangleExclamation;
            }
            else
            {
                return IconCodes.CircleUp;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)

        {
            throw new NotImplementedException();
        }
    }

}



