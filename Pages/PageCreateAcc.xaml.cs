using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SemestrV.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageCreateAcc.xaml
    /// </summary>
    public partial class PageCreateAcc : Page
    {
        AppContext db;

        public PageCreateAcc()
        {
            InitializeComponent();

            db = new AppContext();

            List<User> users = db.Users.ToList();
            string str = "";
            foreach (User user in users)
                str += "Login: " + user.Login + " | ";


            exampleText.Text = str;
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string fioReg = textBoxRegFIO.Text.Trim();
            string loginReg = textBoxRegLogin.Text.Trim().ToLower();
            string passReg = passBoxReg.Password.Trim();
            string passReg_2 = passBoxReg_2.Password.Trim();

            if (fioReg.Length < 2)
            {
                textBoxRegFIO.ToolTip = "ФИО не может содержать меньше 2 символов!";
                textBoxRegFIO.Background = Brushes.DarkRed;
            }
            else if (loginReg == passReg || !loginReg.Contains("@") || !loginReg.Contains("."))
            {
                textBoxRegLogin.ToolTip = "Это поле введено некорректно!";
                textBoxRegLogin.Background = Brushes.DarkRed;
            }
            else if (passReg.Length < 5)
            {
                passBoxReg.ToolTip = "Пароль не может содержать меньше 5 символов!";
                passBoxReg.Background = Brushes.DarkRed;
            }
            else if (passReg != passReg_2)
            {
                passBoxReg_2.ToolTip = "Пароли не совпадают!";
                passBoxReg_2.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxRegFIO.ToolTip = "";
                textBoxRegFIO.Background = Brushes.Transparent;
                textBoxRegLogin.ToolTip = "";
                textBoxRegLogin.Background = Brushes.Transparent;
                passBoxReg.ToolTip = "";
                passBoxReg.Background = Brushes.Transparent;
                passBoxReg_2.ToolTip = "";
                passBoxReg_2.Background = Brushes.Transparent;


                using (AppContext db = new AppContext()) // Обращение к БД
                {
                    User newUser = new User()
                    {
                        Login = textBoxRegLogin.Text,
                        Fio = textBoxRegFIO.Text,
                        Pass = passBoxReg.Password.ToString(),
                        Role = "Ученик"
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                }


                MessageBox.Show("Успешно!");
                Manager.MainFrame.Navigate(new AuthPage());
            }
        }


    }
}
