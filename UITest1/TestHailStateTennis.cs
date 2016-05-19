using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest1
{

    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class TestHailStateTennis
    {
        IApp app;
        Platform platform;

        public TestHailStateTennis(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            //app.Screenshot("First screen.");
            //app.Repl();
        }
        [Test]
        public void ShowStandings()
        {
            app.Tap(c => c.Marked("Standings"));
        }
        [Test]
        public void ShowSchedule()
        {
            app.Tap(c => c.Marked("Schedule"));
        }
        [Test]
        public void ShowRoster()
        {
            app.Tap(c => c.Marked("Roster"));
        }
        [Test]
        public void ShowNews()
        {
            app.Tap(c => c.Marked("News"));
        }
        [Test]
        public void ViewResult1()
        {
            app.Tap(c => c.Marked("Schedule"));
            app.WaitForElement(c => c.Marked("MatchDateId").Index(0));
            app.Tap(c => c.Marked("MatchDateId").Index(0));
        }
        [Test]
        public void ViewResult1Result2Result3()
        {
            app.Tap(c => c.Marked("Schedule"));
            app.WaitForElement(c => c.Marked("MatchDateId").Index(0));
            app.Tap(c => c.Marked("MatchDateId").Index(0));
            app.Back();
            app.WaitForElement(c => c.Marked("MatchDateId").Index(1));
            app.Tap(c => c.Marked("MatchDateId").Index(1));
            app.Back();
            app.WaitForElement(c => c.Marked("MatchDateId").Index(2));
            app.Tap(c => c.Marked("MatchDateId").Index(2));
        }
    }
}

