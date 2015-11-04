
using demo.framework.Elements;
using OpenQA.Selenium;

namespace demo.framework.forms
{
   internal class UserAccountForm :BaseForm
    {
        private static readonly By TitleLocator = By.CssSelector("div[class='uprofile-long']");// проверили что мы на форме учетных данных 
        public UserAccountForm() : base(TitleLocator, "Login Form") { }

        Link editProfile = new Link(By.CssSelector("a[class='active']"), "Edit profile link");
        //Link openPassForm = new Link(By.CssSelector("a[href='#edit/password']"), "Edit pass link"); 
       
        public void EditPersonalData() // переходим по ссылке "Не помню"
            {
            Browser.WaitForPageToLoad();
            editProfile.Click();
            }

        //public void OpenPasswordForm() // переходим по ссылке "Не помню"
        //{
        //    Browser.WaitForPageToLoad();
        //    openPassForm.Click();
        //   // Browser.WaitForPageToLoad();
        //}


    }
}
