using System;
using Xamarin.Forms;

namespace HailStateTennis
{
    public partial class SchedulePage : ContentPage
    {
        public SchedulePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (App.SettingsStaticData)
            {
                listView.ItemsSource = await App.ScheduleManager.ReadLocalFile();
            }
            else
            {
                listView.ItemsSource = await App.ScheduleManager.GetTasksAsync();
            }
        }

        //void OnAddItemClicked(object sender, EventArgs e)
        //{
        //    var todoItem = new ScheduleItem()
        //    {
        //        ID = Guid.NewGuid().ToString()
        //    };
        //    var todoPage = new UpcomingAppointmentsPage();
        //    todoPage.BindingContext = todoItem;
        //    Navigation.PushAsync(todoPage);
        //}

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var scheduleItem = e.SelectedItem as ScheduleItem;
            if (scheduleItem == null) return;
            var scheduleResultsPage = new ScheduleResultsPage();

            // put this section in to try to bind to result instead of schedule item
            var scheduleResult = new ScheduleResult();
            scheduleResult.ID = scheduleItem.ID;
            scheduleResultsPage.BindingContext = scheduleResult;

//            scheduleResultsPage.BindingContext = scheduleItem;
            Navigation.PushAsync(scheduleResultsPage);
            // set the list's SelectedItem to null so it isn't highlighted
            listView.SelectedItem = null;
        }

        //async void OnUpcomingAppointmentsButtonClicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new ScheduleResultsPage());
        //}
    }
}
