using demo.framework.Elements;
using demo.framework.forms;
using OpenQA.Selenium;


namespace demo.framework.forms
{
   internal class DoNotRememberForm : BaseForm
    {
        private static readonly By TitleLocator = By.Id("username");// проверили что мы на форме "Не помню"
         public DoNotRememberForm() : base(TitleLocator, "Login Form") { }

         TextBox EmailTextbox = new TextBox(By.Id("username"), "email textbox"); // определили поле ввода email
         Button SendPass_button = new Button(By.CssSelector("input[alt='Выслать мне пароль']"), "Send password button");
       public void SendEmailNegative() // высылаем пароль на указаный неверный email
         {
             EmailTextbox.SetText(RunConfigurator.GetValue("donotremember"));
             SendPass_button.Click();
         }

       public void SendEmailPositive() // высылаем пароль на указаный правильный email
       {
           EmailTextbox.SetText(RunConfigurator.GetValue("username"));
           SendPass_button.Click();
       }
    }
}
