using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Xamarin.Forms;

namespace HailStateTennis
{
    public class ScheduleItem
    {
        public int ID { get; set; }
        public DateTime MatchDateTime { get; set; }
        public DateTime MatchDateStart { get; set; }
        public DateTime MatchDateEnd { get; set; }
        public string Opponent { get; set; }
        public string Location { get; set; }
    }
    public class MatchDateConverter : IValueConverter
    {
        // Converter to return the match date as "m/d - m/d" if it was a date range or just "m/d" if it was a single day
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = value as ScheduleItem;
            if (item == null)
            {
                return string.Empty;
            }
            if ((item.MatchDateStart > System.DateTime.Parse("1/1/2000")) && (item.MatchDateEnd > System.DateTime.Parse("1/1/2000")))
            {
                return String.Format("{0:M/d}", item.MatchDateStart) + " - " + String.Format("{0:M/d}", item.MatchDateEnd);
            }
            else
            {
                return String.Format("{0:M/d}", item.MatchDateTime);
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
