
using demo.framework.Elements;
using OpenQA.Selenium;
namespace demo.framework.forms
{
    class EditUserDataForm : BaseForm
    {


        private static readonly By TitleLocator = By.CssSelector("a[href='#edit/password']");// проверили что мы на форме учетных данных 
        public EditUserDataForm() : base(TitleLocator, "Edit user data") { }
        
      
        Link openPassForm = new Link(By.CssSelector("a[href='#edit/password']"), "Edit pass link"); 
      
        public void OpenPasswordForm() // переходим по ссылке "Не помню"
        {
           openPassForm.Click();
        }

    }
}
