using SocialNetSchool;
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

namespace SocailNetSchool
{
    /// <summary>
    /// Логика взаимодействия для ProfileUser.xaml
    /// </summary>
    public partial class ProfileUser : Window
    {
        public ProfileUser()
        {
            InitializeComponent();
            FillProfile();
        }

        public void FillProfile()
        {
            Dataclass UserData = new Dataclass();
            UserData.sqlCommands($"SELECT [Login],[Password], [First_name], [Surname], [Middle_name],[Phone_Number],[Email] FROM [dbo].[User] where [ID_User] = {App.UserIdd}", Dataclass.act.select);
            LoginTB.Text = UserData.resultTable.Rows[0][0].ToString();
            PasswordTB.Text = UserData.resultTable.Rows[0][1].ToString();
            NameTb.Text = UserData.resultTable.Rows[0][2].ToString();
            SurnameTb.Text = UserData.resultTable.Rows[0][3].ToString();
            MidnameTb.Text = UserData.resultTable.Rows[0][4].ToString();
            PhoneTb.Text = UserData.resultTable.Rows[0][5].ToString();
            MailTb.Text = UserData.resultTable.Rows[0][6].ToString();
            try
            {
                Dataclass UserDataa = new Dataclass();
                UserDataa.sqlCommands($"SELECT * FROM [dbo].[Profile] where [User_ID] = {Convert.ToInt32(App.UserIdd)}", Dataclass.act.select);
                ImageProfile.Background = new ImageBrush(new BitmapImage(new Uri(UserDataa.resultTable.Rows[0][1].ToString())));
                OpisanieProfile.AppendText(UserDataa.resultTable.Rows[0][2].ToString());
                ImageTb.Text = UserDataa.resultTable.Rows[0][1].ToString();

            }
            catch
            {
                ImageProfile.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "/Av6.jpg")));
            }
           


        }


        private void ProfileBtn_click(object sender, RoutedEventArgs e)
        {
            ProfileUser window1 = new ProfileUser();
            window1.Show(); Close();
        }



        private void EventBTN_Click(object sender, RoutedEventArgs e)
        {
            Event window1 = new Event();
            window1.Show(); Close();
        }

        private void ChatBTN_click(object sender, RoutedEventArgs e)
        {
            ChatClass window1 = new ChatClass();
            window1.Show(); Close();
        }

        private void People_Click(object sender, RoutedEventArgs e)
        {
            AllPeople window1 = new AllPeople();
            window1.Show(); Close();
        }

        private void News_Click(object sender, RoutedEventArgs e)
        {
            GlavMenu window1 = new GlavMenu();
            window1.Show(); Close();
        }

        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dataclass UpdateUser = new Dataclass();
                UpdateUser.sqlCommands($"update [dbo].[User] set [Login] = '{LoginTB.Text}',[Password] = '{PasswordTB.Text}',[Surname] = '{SurnameTb.Text}',[First_name] = '{NameTb.Text}',[Middle_name] = '{MidnameTb.Text}', [Phone_Number] = '{PhoneTb.Text}',[Email] = '{MailTb.Text}' where [ID_User] = {App.UserIdd}", Dataclass.act.manipulation);
                MessageBox.Show("Данные успешно изменены!");

                FillProfile();
            }
            catch
            {
                MessageBox.Show("Данные неверного формата!");
            }
        }

        private void UpdateProfile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Str = new TextRange(OpisanieProfile.Document.ContentStart, OpisanieProfile.Document.ContentEnd).Text;

                Dataclass UpdateUser = new Dataclass();
                UpdateUser.sqlCommands($"update [dbo].[Profile] set [Profile_picture] = '{ImageTb.Text}',[Description] = '{Str}' where [User_ID] = {App.UserIdd}", Dataclass.act.manipulation);
                MessageBox.Show("Данные успешно изменены!");

                FillProfile();
            }
            catch
            {
                MessageBox.Show("Данные неверного формата!");
            }
        }

        private void ExitBTN(object sender, RoutedEventArgs e)
        {
            Auth window1 = new Auth();
            window1.Show(); Close();
        }
    }
}
