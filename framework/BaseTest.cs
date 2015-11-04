using System;
using System.Diagnostics;
using NUnit.Framework;

namespace demo.framework
{
    [TestFixture]
    public class BaseTest : BaseEntity
    {
       private String _baseUrl;

        [SetUp]
        public void SetUp()
       {
           _baseUrl = "http://onliner.by/";
            Browser.GetInstance();
            Browser.GetDriver().Navigate().GoToUrl(_baseUrl);
        }


        [TearDown]
        public static void TearDown()
        {
            var processes = Process.GetProcessesByName(RunConfigurator.GetValue("browser"));
            foreach (var process in processes)
            {
                process.Kill();
            }
            Browser.GetDriver().Quit();
           // Browser.GetDriver().Close();
        }
    }
}
