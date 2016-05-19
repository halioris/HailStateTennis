using System;
using Xamarin.Forms;

namespace HailStateTennis
{
	public class App : Application
	{
		public static ScheduleItemManager ScheduleManager { get; private set; }
        public static ScheduleResultManager ScheduleResultManager { get; private set; }
        public static StandingManager StandingManager { get; private set; }
        public static RosterManager RosterManager { get; private set; }
        public static NewsManager NewsManager { get; private set; }
        public static HttpClientManager HttpClientManager { get; private set; }
        public static bool SettingsStaticData { get; set; }
        public static bool SettingsUseProxy { get; set; }
        public static ITextToSpeech Speech { get; set; }

		public App ()
		{
            HttpClientManager = new HttpClientManager();
			ScheduleManager = new ScheduleItemManager (new ScheduleRestService ());
            ScheduleResultManager = new ScheduleResultManager(new ScheduleResultRestService());
            StandingManager = new StandingManager(new StandingRestService());
            RosterManager = new RosterManager(new RosterRestService());
            NewsManager = new NewsManager(new NewsRestService());
            SettingsStaticData = true;
            SettingsUseProxy = false;
            MainPage = new HailStateTennis.MainPage();
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

