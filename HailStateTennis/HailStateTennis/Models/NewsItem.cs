using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Xamarin.Forms;

namespace HailStateTennis
{
    public class NewsItem
    {
        public int ID { get; set; }
        public string PicUrl { get; set; }
        public string PicFile { get; set; }
        public string Headline { get; set; }
        public string TextDetail { get; set; }

    }
    public class NewsPicToResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var filePathString = (string)value;
            if (!string.IsNullOrEmpty(filePathString))
            {
                return ImageSource.FromResource(String.Format(Constants.NewsPic, filePathString));
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}