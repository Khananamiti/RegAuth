using SemestrV.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SemestrV
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }



        private void Button_AuthReg_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageCreateAcc());
        }
            
            
        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {            
            string login = textBoxLogin.Text.Trim().ToLower();
            string pass = passBox.Password.Trim();

            if (login == pass || !login.Contains("@") || !login.Contains("."))
            {
                textBoxLogin.ToolTip = "Это поле введено некорректно!";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Пароль не может содержать меньше 5 символов!";
                passBox.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                User authUser = null;
                using (AppContext appContext = new AppContext())
                {
                    authUser = appContext.Users.Where(b => b.Login == login 
                                                        && b.Pass == pass).FirstOrDefault();
                }

                

                if (authUser != null)
                {
                    MessageBox.Show("Успешно!");
                    Manager.MainFrame.Navigate(new UserPage());
                }
                else
                    MessageBox.Show("Вы ввели что-то некорректно!");
            }
        }

    }
}
