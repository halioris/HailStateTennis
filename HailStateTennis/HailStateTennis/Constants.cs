using System;

namespace HailStateTennis
{
	public static class Constants
	{
        public static string ScheduleUrl = "http://halioris.onlinewebshop.net/MSUschedule.json";
        public static string StaticSchedule = "HailStateTennis.StaticData.MSUschedule.json"
        public static string ResultUrl = "http://halioris.onlinewebshop.net/Match{0}.json";
        public static string StaticResult = "HailStateTennis.StaticData.Match{0}.json";
        public static string StandingUrl = "http://halioris.onlinewebshop.net/Standings.json";
        public static string StaticStanding = "HailStateTennis.StaticData.Standings.json";
        public static string RosterUrl = "http://halioris.onlinewebshop.net/Roster.json";
        public static string StaticRoster = "HailStateTennis.StaticData.Roster.json";
        public static string NewsUrl = "http://halioris.onlinewebshop.net/News.json";
        public static string StaticNews = "HailStateTennis.StaticData.News.json";
        public static string PlayerPic = "HailStateTennis.Images.{0}";
        public static string NewsPic = "HailStateTennis.Images.{0}";
        public static string ProxyServer = "http://proxy.air.ups.com";
        public static string ProxyPort = "8080";
        public static string ProxyUser = "myuserid";
        public static string ProxyPassword = "mypassword";
    }
}
