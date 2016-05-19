using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HailStateTennis
{
    public partial class NewsPage : ContentPage
    {
        public NewsPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (App.SettingsStaticData)
            {
                newsListView.ItemsSource = App.NewsManager.ReadLocalFile();
            }
            else
            {
                newsListView.ItemsSource = await App.NewsManager.GetTasksAsync();
            }
        }
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var newsItem = e.SelectedItem as NewsItem;

            // set the list's SelectedItem to null so it isn't highlighted
            newsListView.SelectedItem = null;
        }
    }
}
