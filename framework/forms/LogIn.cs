using demo.framework.Elements;
using demo.framework.forms;
using OpenQA.Selenium;

namespace demo.framework
{
   internal class LogIn : BaseForm 
    {
       
            private static readonly By TitleLocator = By.CssSelector("div[class='auth-box__field']");// проверили что мы на форме логина
            public LogIn() : base(TitleLocator, "Login Form") { }

            TextBox Login_Text_box = new TextBox(By.CssSelector("input[placeholder='Ник или e-mail']"), "Login textbox"); // определили поле логина
            TextBox Password_Text_box = new TextBox(By.CssSelector("input[data-bind*='$root.login.data.password']"), "Password textbox");  // определили поле пароля
            Button Enter_button = new Button(By.CssSelector("button[data-bind*='$root.login.isProcessing']"), "Login button");
            Button DoNotRemember_button = new Button(By.CssSelector("[class='auth-box__complementary auth-box__complementary--link']"), "Do not remember button"); 
            public void Login()
            {
                Browser.WaitForPageToLoad();
                Login_Text_box.SetText(RunConfigurator.GetValue("username"));
                Password_Text_box.SetText(RunConfigurator.GetValue("password"));
                Enter_button.Click();
            }

            public void DoNotRemember() // переходим по ссылке "Не помню"
            {
                Browser.WaitForPageToLoad();
                DoNotRemember_button.Click();
            }
    }
}
