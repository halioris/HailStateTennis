using System;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace HailStateTennis
{
    public partial class ScheduleResultsPage : ContentPage
    {
        public ScheduleResultsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            // SchedulePage will have bound a ScheduleResult object that is empty except for the ID of the match being selected
            // Use the ScheduleResultManager to get the result for the match
            var scheduleResult = (ScheduleResult)BindingContext;
            ScheduleResult result;
            if (App.SettingsStaticData)
            {
                result = App.ScheduleResultManager.ReadLocalFile(scheduleResult.ID);
            }
            else
            {
                result = await App.ScheduleResultManager.GetTasksAsync(scheduleResult.ID);
            }

            StackLayout stackLayout = new StackLayout();

            if (result == null)
            {
                stackLayout.Children.Add(
                    new Label
                    {
                        Text = "No Data Available for selected match",
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        FontAttributes = FontAttributes.Bold,
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                    });
            }
            else
            {
                // Result Header
                stackLayout.Children.Add(
                    new Label
                    {
                        Text = result.Result,
                        HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.Start,
                        FontAttributes = FontAttributes.Bold,
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                    });
                // loop throught each day result and display the Day and all of the section results for each day
                foreach (DayResult dayResult in result.DayResults)
                {
                    // Day Header
                    stackLayout.Children.Add(
                        new Label
                        {
                            Text = dayResult.Day,
                            HorizontalOptions = LayoutOptions.Start,
                            VerticalOptions = LayoutOptions.Start,
                            FontAttributes = FontAttributes.Bold | FontAttributes.Italic,
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                        });
                    // loop through each section in the day and display the Title and all the match results for each section
                    foreach (SectionResult sectionResult in dayResult.Section)
                    {
                        // Section Title
                        stackLayout.Children.Add(
                            new Label
                            {
                                Text = sectionResult.Title,
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                VerticalOptions = LayoutOptions.Start,
                                FontAttributes = FontAttributes.Bold,
                                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                                BackgroundColor = Color.Maroon
                            });
                        // display each match results in the section "Line - Result"
                        foreach (MatchResult matchResult in sectionResult.Results)
                        {
                            stackLayout.Children.Add(
                                new Label
                                {
                                    Text = matchResult.Line + (matchResult.Line == String.Empty ? String.Empty : " - ") + matchResult.Result,
                                    HorizontalOptions = LayoutOptions.Start,
                                    VerticalOptions = LayoutOptions.Start,
                                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
                                });
                        }
                    }
                    // add order of finish if it was present
                    if (!String.IsNullOrEmpty(dayResult.Order))
                    {
                        stackLayout.Children.Add(
                            new Label
                            {
                                Text = dayResult.Order,
                                HorizontalOptions = LayoutOptions.Start,
                                VerticalOptions = LayoutOptions.Start,
                                FontAttributes = FontAttributes.Italic,
                                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
                            });
                    }
                }

                //Result.Text = result.Result;
                //Dubs1.Text = (string)result.Doubles[0].Line + " " + result.Doubles[0].Result;
                //Dubs2.Text = (string)result.Doubles[1].Line + " " + result.Doubles[1].Result;
                //Dubs3.Text = (string)result.Doubles[2].Line + " " + result.Doubles[2].Result;
                //Singles1.Text = (string)result.Singles[0].Line + " " + result.Singles[0].Result;
                //Singles2.Text = (string)result.Singles[1].Line + " " + result.Singles[1].Result;
                //Singles3.Text = (string)result.Singles[2].Line + " " + result.Singles[2].Result;
                //Singles4.Text = (string)result.Singles[3].Line + " " + result.Singles[3].Result;
                //Singles5.Text = (string)result.Singles[4].Line + " " + result.Singles[4].Result;
                //Singles6.Text = (string)result.Singles[5].Line + " " + result.Singles[5].Result;
            }
            Padding = new Thickness(5, Device.OnPlatform(20, 5, 5), 5, 5);
            Content = new ScrollView
            {
                Content = stackLayout
            };
        }

        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}