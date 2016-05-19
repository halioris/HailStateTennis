using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Xamarin.Forms;

namespace HailStateTennis
{
    public class Roster
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string Hometown { get; set; }
        public string BigPhotoFile { get; set; }
        public string PhotoFile { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Experience { get; set; }
        public string HighSchool { get; set; }
        public string Position { get; set; }
        public string AlmaMater { get; set; }
        public string GradYear { get; set; }

    }
    public class StringToResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var filePathString = (string)value;
            if (!string.IsNullOrEmpty(filePathString))
            {
                return ImageSource.FromResource(String.Format(Constants.PlayerPic,filePathString));
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class DetailConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var roster = (Roster)value;
            if (roster != null)
            {
                string fullYear = "";
                if (roster.Year == null)
                {
                    fullYear = roster.Position;
                }
                else
                {
                    switch (roster.Year)
                    {
                        case "Fr.": fullYear = "Freshman"; break;
                        case "So.": fullYear = "Sophomore"; break;
                        case "Jr.": fullYear = "Junior"; break;
                        case "Sr.": fullYear = "Senior"; break;
                        default: fullYear = roster.Year; break;
                    }
                }
                return fullYear + " - " + roster.Hometown;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class AttributePresentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = (string)value;
            if (str == null) return 0;
            if (str.Length == 0) return 0;
            else return GridLength.Auto;
 //           return GridLength.Auto;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
