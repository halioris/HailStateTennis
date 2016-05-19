using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HailStateTennis
{
    public partial class RosterPage : ContentPage
    {
        public RosterPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (App.SettingsStaticData)
            {
                rosterListView.ItemsSource = App.RosterManager.ReadLocalFile();
            }
            else
            {
                rosterListView.ItemsSource = await App.RosterManager.GetTasksAsync();
            }
        }
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var roster = e.SelectedItem as Roster;
            if (roster == null) return;
            var playerPage = new PlayerPage();
            playerPage.BindingContext = roster;
            Navigation.PushAsync(playerPage);

            // set the selected item to null so it is not highlighted
            rosterListView.SelectedItem = null;
        }

    }
}
