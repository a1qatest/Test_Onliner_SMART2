using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.framework.Elements;
using OpenQA.Selenium;

namespace demo.framework.forms
{
   internal class PasswordForm : BaseForm
    {

       private static readonly By TitleLocator = By.CssSelector("[id='password_confirm']");// проверили что мы на форме изменения паролля
       public PasswordForm() : base(TitleLocator, "Edit Password Form") { }
       
       TextBox oldPass = new TextBox(By.CssSelector("input[name='old_password']"), "Old password text-box");
       TextBox newPass = new TextBox(By.CssSelector("input[name='password']"), "New password text-box");
       TextBox confirmPass = new TextBox(By.CssSelector("input[name='password_confirm']"), "Confirm password text-box");
       Button changePass = new Button(By.XPath(".//*[contains(text(),'Изменить пароль')]"), "Submit button");

       public void EditPassIncorrectOldPass() // Заполняем поля  формы измененя пароля с неправильным старым паролем
        {
            Browser.WaitForPageToLoad(); 
            oldPass.SetText(RunConfigurator.GetValue("incorrectpass"));
            newPass.SetText(RunConfigurator.GetValue("newpass"));
            confirmPass.SetText(RunConfigurator.GetValue("newpass"));
            changePass.Click();
        }

       public void EditPassIncorrectConfPass() // Заполняем поля  формы измененя пароля с неправильным подтверждением нового пароля

        {
            Browser.WaitForPageToLoad();
            oldPass.SetText(RunConfigurator.GetValue("password"));
            newPass.SetText(RunConfigurator.GetValue("newpass"));
            confirmPass.SetText(RunConfigurator.GetValue("incorrectpass"));
            changePass.Click();
        }

       public void EditPassEmptyField() // Заполняем поля формы измененя пароля правильными данными
       {
           Browser.WaitForPageToLoad();
           changePass.Click();
       }
       
       
       public void EditPass() // Заполняем поля формы измененя пароля правильными данными
       {
           Browser.WaitForPageToLoad();
           oldPass.SetText(RunConfigurator.GetValue("password"));
           newPass.SetText(RunConfigurator.GetValue("newpass"));
           confirmPass.SetText(RunConfigurator.GetValue("newpass"));
           changePass.Click();
       }

    }
}
