using System.Diagnostics;
using System.Runtime.InteropServices;
using demo.framework.forms;
using OpenQA.Selenium;

namespace demo.framework.Asserts
{
   internal class AssertEditPass : BaseForm
    {
        private static readonly By TitleLocator = By.CssSelector("[id='old_password']");// проверили что мы на форме изменения паролля
        public AssertEditPass() : base(TitleLocator, "Edit Password Form") { }
        public bool CheckEditPass() // проверка что мы залогинены 
        {
            Browser.WaitForPageToLoad();
            var test=false;

            try
            {
                bool xxx = Browser.GetDriver().FindElement(By.CssSelector("[id='tab-password'] [class='fieldErrorMsg']")).Displayed;
                if (xxx)
                {
                    return test = false;
                }
            }
            catch (WebDriverException)
            {
                return test = true;
            }
            return test;
        }
    }
}
