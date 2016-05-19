using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HailStateTennis
{
    public partial class StandingsPage : ContentPage
    {
        public StandingsPage()
        {
            InitializeComponent();
        }
        private void AddGridRow(Grid grid, int i, string team, string sec, string overall, string home, string away, string neutral)
        {
            grid.Children.Add(new Label
            {
                Text = team,
                TextColor = (i == 0 ? Color.Accent : Color.Default)
            }, 0, i);
            grid.Children.Add(new Label
            {
                Text = sec,
                TextColor = (i == 0 ? Color.Accent : Color.Default),
                HorizontalOptions = LayoutOptions.Center
            }, 1, i);
            grid.Children.Add(new Label
            {
                Text = overall,
                TextColor = (i == 0 ? Color.Accent : Color.Default),
                HorizontalOptions = LayoutOptions.Center
            }, 2, i);
            grid.Children.Add(new Label
            {
                Text = home,
                TextColor = (i == 0 ? Color.Accent : Color.Default),
                HorizontalOptions = LayoutOptions.Center
            }, 3, i);
            grid.Children.Add(new Label
            {
                Text = away,
                TextColor = (i == 0 ? Color.Accent : Color.Default),
                HorizontalOptions = LayoutOptions.Center
            }, 4, i);
            grid.Children.Add(new Label
            {
                Text = neutral,
                TextColor = (i == 0 ? Color.Accent : Color.Default),
                HorizontalOptions = LayoutOptions.Center
            }, 5, i);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            List<Standing> result;

            if (App.SettingsStaticData)
            {
                result = App.StandingManager.ReadLocalFile();
            }
            else
            {
                result = await App.StandingManager.GetTasksAsync();
            }

            StackLayout stackLayout = new StackLayout();
            if (result == null)
            {
                stackLayout.Children.Add(
                    new Label
                    {
                        Text = "No Data Available...",
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        FontAttributes = FontAttributes.Bold,
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                    });
                Content = stackLayout;
            }
            else
            {
                Grid grid = new Grid
                {
                    RowDefinitions =
                    {
                        new RowDefinition {Height = GridLength.Auto },
                        new RowDefinition {Height = GridLength.Auto },
                        new RowDefinition {Height = GridLength.Auto },
                        new RowDefinition {Height = GridLength.Auto },
                        new RowDefinition {Height = GridLength.Auto },
                        new RowDefinition {Height = GridLength.Auto },
                        new RowDefinition {Height = GridLength.Auto },
                        new RowDefinition {Height = GridLength.Auto },
                        new RowDefinition {Height = GridLength.Auto },
                        new RowDefinition {Height = GridLength.Auto },
                        new RowDefinition {Height = GridLength.Auto },
                        new RowDefinition {Height = GridLength.Auto },
                        new RowDefinition {Height = GridLength.Auto },
                        new RowDefinition {Height = GridLength.Auto }
                    },
                    ColumnDefinitions =
                    {
                        //new ColumnDefinition {Width = GridLength.Auto },
                        new ColumnDefinition {Width = GridLength.Auto },
                        new ColumnDefinition {Width = GridLength.Auto },
                        new ColumnDefinition {Width = GridLength.Auto },
                        new ColumnDefinition {Width = GridLength.Auto },
                        new ColumnDefinition {Width = GridLength.Auto },
                        new ColumnDefinition {Width = GridLength.Auto }
                    }
                };
                AddGridRow(grid, 0, "Team", "SEC", "Overall", "Home", "Away", "Neutral");
                var i = 1;
                foreach (Standing standing in result)
                {
                    AddGridRow(grid, i, 
                        standing.Team,
                        standing.WinsSEC + "-" + standing.LossesSEC,
                        standing.WinsOverall + "-" + standing.LossesOverall,
                        standing.WinsHome + "-" + standing.LossesHome,
                        standing.WinsAway + "-" + standing.LossesAway,
                        standing.WinsNeutral + "-" + standing.LossesNeutral);
                    //grid.Children.Add(new Label
                    //{
                    //    Text = (i==0 ? "Team" : standing.Team),
                    //    TextColor = (i==0 ? Color.Accent : Color.Default)
                    //}, 0, i);
                    //grid.Children.Add(new Label
                    //{
                    //    Text = (i==0 ? "SEC" : standing.WinsSEC + "-" + standing.LossesSEC),
                    //    TextColor = (i == 0 ? Color.Accent : Color.Default),
                    //    HorizontalOptions = LayoutOptions.Center
                    //}, 1, i);
                    //grid.Children.Add(new Label
                    //{
                    //    Text = (i==0 ? "Overall" : standing.WinsOverall + "-" + standing.LossesOverall),
                    //    TextColor = (i == 0 ? Color.Accent : Color.Default),
                    //    HorizontalOptions = LayoutOptions.Center
                    //}, 2, i);
                    //grid.Children.Add(new Label
                    //{
                    //    Text = (i==0 ? "Home" : standing.WinsHome + "-" + standing.LossesHome),
                    //    TextColor = (i == 0 ? Color.Accent : Color.Default),
                    //    HorizontalOptions = LayoutOptions.Center
                    //}, 3, i);
                    //grid.Children.Add(new Label
                    //{
                    //    Text = (i == 0 ? "Away" : standing.WinsAway + "-" + standing.LossesAway),
                    //    TextColor = (i == 0 ? Color.Accent : Color.Default),
                    //    HorizontalOptions = LayoutOptions.Center
                    //}, 4, i);
                    //grid.Children.Add(new Label
                    //{
                    //    Text = (i == 0 ? "Neutral" : standing.WinsNeutral + "-" + standing.LossesNeutral),
                    //    TextColor = (i == 0 ? Color.Accent : Color.Default),
                    //    HorizontalOptions = LayoutOptions.Center
                    //}, 5, i);
                    //grid.Children.Add(new Label
                    //{
                    //    Text = (i == 0 ? "Streak" : standing.Streak),
                    //    TextColor = (i == 0 ? Color.Accent : Color.Default),
                    //    HorizontalOptions = LayoutOptions.Center
                    //}, 6, i);
                    i++;
                }
                stackLayout.Children.Add(grid);
                //stackLayout.Children.Add(
                //    new Label
                //    {
                //        Text = String.Format("Screen: {0} \u00D7 {1}", Width, Height)
                //    });
                //stackLayout.Children.Add(
                //    new Label
                //    {
                //        Text = String.Format("Team Width: {0}", grid.ColumnDefinitions[0].Width)
                //    });
                Content = new ScrollView
                {
                    Content = stackLayout
                    //    Content = grid
                };
            }
            Padding = new Thickness(5, Device.OnPlatform(20, 5, 5), 5, 5);

            //if (App.SettingsStaticData)
            //{
            //    standingsListView.ItemsSource = App.StandingManager.ReadLocalFile();
            //}
            //else
            //{
            //    standingsListView.ItemsSource = await App.StandingManager.GetTasksAsync();
            //}
        }

    }
}
