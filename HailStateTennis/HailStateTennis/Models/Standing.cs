using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Xamarin.Forms;

namespace HailStateTennis
{
    public class Standing
    {
        public int ID { get; set; }
        public string Team { get; set; }
        public int WinsSEC { get; set; }
        public int LossesSEC { get; set; }
        public int WinsOverall { get; set; }
        public int LossesOverall { get; set; }
        public int WinsHome { get; set; }
        public int LossesHome { get; set; }
        public int WinsAway { get; set; }
        public int LossesAway { get; set; }
        public int WinsNeutral { get; set; }
        public int LossesNeutral { get; set; }
        public string Streak { get; set; }
    }
    public class SECRecordConverter : IValueConverter
    {
        // Converter to return the SEC record as W-L
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = value as Standing;
            if (item == null) return String.Empty;
            return item.WinsSEC + "-" + item.LossesSEC;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class OverallRecordConverter : IValueConverter
    {
        // Converter to return the SEC record as W-L
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = value as Standing;
            if (item == null) return String.Empty;
            return item.WinsOverall + "-" + item.LossesOverall;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}