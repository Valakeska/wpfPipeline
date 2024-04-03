using SocialNetSchool;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace SocailNetSchool
{
    /// <summary>
    /// Логика взаимодействия для ChatClass.xaml
    /// </summary>
    public partial class ChatClass : Window
    {
        public ChatClass()
        {
            InitializeComponent();
            Chat();
        }
        public void Chat()
        {
            ClearDynamic();
            StackPanel stackPanel = new StackPanel();
            StackMain.Children.Add(stackPanel);
            try
            {
                Dataclass classs = new Dataclass();
                classs.sqlCommands($"SELECT [Class_ID] FROM [dbo].[Member_School_Class]  where [ID_Member_School_Class] = {App.ClassUserIdd}", Dataclass.act.select);
                Dataclass IdMess = new Dataclass();
                IdMess.sqlCommands($"SELECT [ID_Class_Chat] FROM [dbo].[Class_Chat]  inner join [dbo].[Member_School_Class] on [Member_School_Class_ID] = [ID_Member_School_Class] where [Class_ID] = {Convert.ToInt32(classs.resultTable.Rows[0][0])}", Dataclass.act.select);
                Dataclass ContentMess = new Dataclass();
                ContentMess.sqlCommands($"SELECT [Content] FROM [dbo].[Class_Chat]  inner join [dbo].[Member_School_Class] on [Member_School_Class_ID] = [ID_Member_School_Class] where [Class_ID] = {Convert.ToInt32(classs.resultTable.Rows[0][0])}", Dataclass.act.select);
                Dataclass UserLogin = new Dataclass();
                UserLogin.sqlCommands($"select [Surname]+' '+[First_name]+' '+[Middle_name] from [dbo].[Class_Chat] inner join [dbo].[Member_School_Class] on [Member_School_Class_ID] = [ID_Member_School_Class]  inner join [dbo].[User] on [User_ID] = [ID_User] where [Class_ID] = {Convert.ToInt32(classs.resultTable.Rows[0][0])} ", Dataclass.act.select);
                Dataclass TimeMess = new Dataclass();
                TimeMess.sqlCommands($"SELECT [Time] FROM [dbo].[Class_Chat]  inner join [dbo].[Member_School_Class] on [Member_School_Class_ID] = [ID_Member_School_Class]  where [Class_ID] = {Convert.ToInt32(classs.resultTable.Rows[0][0])}", Dataclass.act.select);
                Dataclass UserRole = new Dataclass();
                UserRole.sqlCommands($"select [Tittle] from [dbo].[Class_Chat] inner join [dbo].[Member_School_Class] on [Member_School_Class_ID] = [ID_Member_School_Class] inner join [dbo].[User] on [User_ID] = [ID_User]  inner join [dbo].[Role] on [Role_ID] = [ID_Role]  where [Class_ID] = {Convert.ToInt32(classs.resultTable.Rows[0][0])}", Dataclass.act.select);

                for (int i = 0; i < IdMess.resultTable.Rows.Count; i++)
                {

                    StackPanel StackPanelMain = new StackPanel();
                    Grid Palka = new Grid();
                    StackPanel UserAndContent = new StackPanel();
                    Label Otstyp = new Label();
                    Label Otstyp2 = new Label();
                    TextBlock Opisanie = new TextBlock();
                    Label Time = new Label();
                    Label UserName = new Label();
                    StackPanel stackforLabel = new StackPanel();

                    if (UserRole.resultTable.Rows[i][0].ToString() == "Учитель")
                    {
                        UserName.Background = new SolidColorBrush(Color.FromRgb(255, 200, 80));
                        UserName.Content = UserLogin.resultTable.Rows[i][0].ToString() + "♛";

                    }
                    else if (UserRole.resultTable.Rows[i][0].ToString() == "Ученик")
                    {
                        UserName.Content = UserLogin.resultTable.Rows[i][0].ToString();
                    }

                    UserName.FontSize = 30;
                    UserName.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    UserName.FontWeight = FontWeights.Bold;
                    UserName.FontStyle = FontStyles.Italic;
                    UserName.HorizontalContentAlignment = HorizontalAlignment.Left;
                    UserName.Margin = new Thickness(0, 0, 0, 0);

                    Opisanie.Text = ContentMess.resultTable.Rows[i][0].ToString();
                    Opisanie.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    Opisanie.FontSize = 26;
                    Opisanie.TextWrapping = TextWrapping.Wrap;
                    if (UserRole.resultTable.Rows[i][0].ToString() == "Оператор")
                    {
                        Opisanie.HorizontalAlignment = HorizontalAlignment.Left;
                        UserAndContent.HorizontalAlignment = HorizontalAlignment.Left;
                        stackforLabel.HorizontalAlignment = HorizontalAlignment.Left;
                    }
                    else if (UserRole.resultTable.Rows[i][0].ToString() == "Клиент")
                    {
                        Opisanie.HorizontalAlignment = HorizontalAlignment.Right;
                        UserAndContent.HorizontalAlignment = HorizontalAlignment.Right;
                        stackforLabel.HorizontalAlignment = HorizontalAlignment.Right;
                    }

                    stackforLabel.Orientation = Orientation.Horizontal;
                    UserAndContent.Orientation = Orientation.Vertical;

                    Time.Content = TimeMess.resultTable.Rows[i][0].ToString();
                    Time.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    Time.FontSize = 22;
                    Time.HorizontalContentAlignment = HorizontalAlignment.Center;
                    Time.Margin = new Thickness(0, 12, 0, 0);


                    Palka.Height = 50;
                    Palka.Width = 1;
                    Palka.Background = new SolidColorBrush(Color.FromRgb(237, 237, 237));
                    Palka.Margin = new Thickness(10, 0, 0, 0);

                    Otstyp2.Height = 20;

                    stackPanel.Children.Add(StackPanelMain);
                    stackPanel.Children.Add(Otstyp2);
                    StackPanelMain.Children.Add(stackforLabel);
                    stackforLabel.Children.Add(Time);
                    stackforLabel.Children.Add(Palka);
                    stackforLabel.Children.Add(UserAndContent);
                    UserAndContent.Children.Add(UserName);
                    UserAndContent.Children.Add(Opisanie);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        public void ClearDynamic()//очистить результаты поиска
        {
            StackMain.Children.Clear();
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if (TextBoxComment.Text != "")
            {
                try
                {
                    Dataclass sql = new Dataclass();
                    sql.sqlCommands($"insert into [dbo].[Class_Chat] ([Content],[Time],[Member_School_Class_ID]) values ('{TextBoxComment.Text}','{DateTime.Now}',{App.ClassUserIdd})", Dataclass.act.select);

                    ClearDynamic();
                    Chat();
                }
                catch (Exception mess) { MessageBox.Show(mess.ToString()); }

            }
        }

        private void ExitBTN(object sender, RoutedEventArgs e)
        {
            Auth window1 = new Auth();
            window1.Show(); Close();
        }
    }
}
