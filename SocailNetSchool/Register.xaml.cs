using SocialNetSchool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SocailNetSchool
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void RegBTN_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    string Str = new TextRange(Desc.Document.ContentStart, Desc.Document.ContentEnd).Text;
            //    if (Login.Text != "" && Password.Text != "" && Ima.Text != "" && Familia.Text != "" && Otchestvo.Text != "" && Tag.Text != "" && Str != "" && AvaLink.Text != "")
            //    {
            //        if (Login.Text.Length <= 20)
            //        {
            //            if (Login.Text.Length >= 8)

            //            {

            //                bool enUpper = false;
            //                bool enLower = false;

            //                for (int i = 0; i < Password.Text.Length; i++)

            //                {

            //                    if (Password.Text[i] >= 'A' && Password.Text[i] <= 'Z') enUpper = true;
            //                    if (Password.Text[i] >= 'a' && Password.Text[i] <= 'z') enLower = true;
            //                }

            //                if (enUpper == true && enLower == true)
            //                {

            //                    if (Password.Text.Contains("%") ||
            //                    Password.Text.Contains("!") || Password.Text.Contains("@") ||
            //                    Password.Text.Contains("#") || Password.Text.Contains("$") ||
            //                    Password.Text.Contains("^") || Password.Text.Contains("&") ||
            //                    Password.Text.Contains("*") || Password.Text.Contains("(") ||
            //                    Password.Text.Contains(")"))
            //                    {
            //                        Dataclass AddUser = new Dataclass();

            //                        AddUser.sqlCommands($"insert into [dbo].[User] ([Login],[Password],[First_name],[Surname],[Middle_name],[Tag],[Role_ID]) values ('{Login.Text}', '{Password.Text}', '{Ima.Text}', '{Familia.Text}', '{Otchestvo.Text}', '{Tag.Text}',3 )", Dataclass.act.manipulation);
            //                        DataTable IdUser = sql.Commands($"SELECT TOP(1) [ID_User] FROM [User] ORDER BY [ID_User] DESC");
            //                        sql.Commands($"insert into [dbo].[Profile] ([Profile_picture],[Description],[User_ID]) values ('{AvaLink.Text}', '{Str}', {Convert.ToInt32(IdUser.Rows[0][0])})");


            //                        MessageBox.Show("Вы зарегестрированны!");
            //                        MainWindow userw = new MainWindow();
            //                        userw.Show(); Close();
            //                    }

            //                    else MessageBox.Show("Пароль должен содержать хотя бы один специальный символ!");
            //                }

            //                else MessageBox.Show("Пароль должен содержать хотя бы один символ верхнего регистра и хотя бы один символ нижнего регистра!");
            //            }

            //            else MessageBox.Show("Логин слишком маленький! Введите минимум 8 символов.");
            //        }
            //        else MessageBox.Show("Логин слишком большой! Введите максимум 20 символов.");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Одно из полей не заполнено!");
            //    }
            //}
            //catch (Exception mess) { MessageBox.Show(mess.ToString()); }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            Auth window = new Auth();
            window.Show(); Close();
        }
    }
}
