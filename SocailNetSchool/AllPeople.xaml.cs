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
using System.Windows.Shapes;

namespace SocailNetSchool
{
    /// <summary>
    /// Логика взаимодействия для AllPeople.xaml
    /// </summary>
    public partial class AllPeople : Window
    {
        public AllPeople()
        {
            InitializeComponent();
            AllStudentSearch();


        }

        public void AllStudentSearch()
        {
            ClearDynamic();
           
            
            StackPanel stackPanel = new StackPanel();

            StackMain.Children.Add(stackPanel);
            try
            {
                if (PoiskPostov.Text == "")
                {
                    Dataclass IDStudentClass = new Dataclass();
                    IDStudentClass.sqlCommands($"SELECT [ID_Member_School_Class] FROM [dbo].[Member_School_Class]  ", Dataclass.act.select);
                    Dataclass FIOstud = new Dataclass();
                    FIOstud.sqlCommands($"SELECT [Surname]+' '+[First_name]+' '+[Middle_name] FROM [dbo].[Member_School_Class] inner join [dbo].[User] on [User_ID] = [ID_User] inner join [dbo].[Class] on [Class_ID] = [ID_Class]", Dataclass.act.select);

                    Dataclass ClassNumStud = new Dataclass();
                    ClassNumStud.sqlCommands($"SELECT [Number] FROM [dbo].[Member_School_Class]  inner join [dbo].[Class] on [Class_ID] = [ID_Class]", Dataclass.act.select);
                    Dataclass ClasbykStud = new Dataclass();
                    ClasbykStud.sqlCommands($"SELECT [Letter] FROM [dbo].[Member_School_Class]  inner join [dbo].[Class] on [Class_ID] = [ID_Class]", Dataclass.act.select);
                    Dataclass RoleUser = new Dataclass();
                    RoleUser.sqlCommands($"SELECT [Tittle] FROM [dbo].[Member_School_Class]  inner join [dbo].[User] on [User_ID] = [ID_User] inner join [dbo].[Role] on [Role_ID] = [ID_Role]", Dataclass.act.select);


                    Dataclass MailPhoneStud = new Dataclass();
                    MailPhoneStud.sqlCommands($"SELECT 'Почта: '+[Email]+' '+'Номер телефона: '+'+'+[Phone_Number] FROM [dbo].[Member_School_Class] inner join [dbo].[User] on [User_ID] = [ID_User] ", Dataclass.act.select);


                    for (int i = 0; i < IDStudentClass.resultTable.Rows.Count; i++)
                    {
                        Label Otstyp = new Label();
                        Label Linia = new Label();
                        WrapPanel ForBtn = new WrapPanel();

                        Label fiostudents = new Label();
                        Label mailphonestudents = new Label();

                        StackPanel stackforLabel = new StackPanel();

                        fiostudents.Content = FIOstud.resultTable.Rows[i][0].ToString() + " " + ClassNumStud.resultTable.Rows[i][0].ToString() + ClasbykStud.resultTable.Rows[i][0].ToString() + "                                " + RoleUser.resultTable.Rows[i][0].ToString();
                        fiostudents.FontWeight = FontWeights.Bold;
                        fiostudents.FontSize = 20;
                        fiostudents.HorizontalContentAlignment = HorizontalAlignment.Center;

                        mailphonestudents.Content = MailPhoneStud.resultTable.Rows[i][0].ToString();
                        mailphonestudents.FontSize = 17;
                        mailphonestudents.HorizontalContentAlignment = HorizontalAlignment.Left;
                        mailphonestudents.Margin = new Thickness(190, 0, 0, 0);

                        stackforLabel.Orientation = Orientation.Horizontal;
                        stackforLabel.Margin = new Thickness(0, 20, 0, 0);
                        Otstyp.Width = 170;

                        ForBtn.HorizontalAlignment = HorizontalAlignment.Center;
                        Linia.Content = "――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――";
                        Linia.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        Linia.HorizontalContentAlignment = HorizontalAlignment.Center;
                        Linia.FontSize = 30;
                        Linia.FontWeight = FontWeights.Bold;


                        stackPanel.Children.Add(stackforLabel);
                        stackPanel.Children.Add(mailphonestudents);
                        stackPanel.Children.Add(ForBtn);
                        stackforLabel.Children.Add(Otstyp);
                        stackforLabel.Children.Add(fiostudents);

                        ForBtn.Children.Add(Linia);

                    }
                }
                else
                {
                    Dataclass IDStudentClass = new Dataclass();
                    IDStudentClass.sqlCommands($"SELECT [ID_Member_School_Class] FROM [dbo].[Member_School_Class] inner join [dbo].[User] on [User_ID] = [ID_User] inner join [dbo].[Class] on [Class_ID] = [ID_Class] where  [Surname] LIKE '%{PoiskPostov.Text}%' or   [First_name] LIKE '%{PoiskPostov.Text}%'or   [Middle_name] LIKE '%{PoiskPostov.Text}%'or   [Number] LIKE '%{PoiskPostov.Text}%' or [Letter] LIKE '%{PoiskPostov.Text}%' ", Dataclass.act.select);
                    Dataclass FIOstud = new Dataclass();
                    FIOstud.sqlCommands($"SELECT [Surname]+' '+[First_name]+' '+[Middle_name] FROM [dbo].[Member_School_Class]inner join [dbo].[User] on [User_ID] = [ID_User] inner join [dbo].[Class] on [Class_ID] = [ID_Class] where  [Surname] LIKE '%{PoiskPostov.Text}%' or   [First_name] LIKE '%{PoiskPostov.Text}%'or   [Middle_name] LIKE '%{PoiskPostov.Text}%'or   [Number] LIKE '%{PoiskPostov.Text}%' or [Letter] LIKE '%{PoiskPostov.Text}%' ", Dataclass.act.select);
                    Dataclass MailPhoneStud = new Dataclass();
                    MailPhoneStud.sqlCommands($"SELECT 'Почта: '+[Email]+' '+'Номер телефона: '+'+'+[Phone_Number] FROM [dbo].[Member_School_Class] inner join [dbo].[User] on [User_ID] = [ID_User] inner join [dbo].[Class] on [Class_ID] = [ID_Class] where  [Surname] LIKE '%{PoiskPostov.Text}%' or   [First_name] LIKE '%{PoiskPostov.Text}%'or   [Middle_name] LIKE '%{PoiskPostov.Text}%'or   [Number] LIKE '%{PoiskPostov.Text}%' or [Letter] LIKE '%{PoiskPostov.Text}%'", Dataclass.act.select);

                    Dataclass ClassNumStud = new Dataclass();
                    ClassNumStud.sqlCommands($"SELECT [Number] FROM [dbo].[Member_School_Class] inner join [dbo].[User] on [User_ID] = [ID_User] inner join [dbo].[Class] on [Class_ID] = [ID_Class] where  [Surname] LIKE '%{PoiskPostov.Text}%' or   [First_name] LIKE '%{PoiskPostov.Text}%'or   [Middle_name] LIKE '%{PoiskPostov.Text}%'or   [Number] LIKE '%{PoiskPostov.Text}%' or [Letter] LIKE '%{PoiskPostov.Text}%'", Dataclass.act.select);
                    Dataclass ClasbykStud = new Dataclass();
                    ClasbykStud.sqlCommands($"SELECT [Letter] FROM [dbo].[Member_School_Class]  inner join [dbo].[User] on [User_ID] = [ID_User] inner join [dbo].[Class] on [Class_ID] = [ID_Class] where  [Surname] LIKE '%{PoiskPostov.Text}%' or   [First_name] LIKE '%{PoiskPostov.Text}%'or   [Middle_name] LIKE '%{PoiskPostov.Text}%'or   [Number] LIKE '%{PoiskPostov.Text}%' or [Letter] LIKE '%{PoiskPostov.Text}%'", Dataclass.act.select);
                    Dataclass RoleUser = new Dataclass();
                    RoleUser.sqlCommands($"SELECT [Tittle] FROM [dbo].[Member_School_Class]  inner join [dbo].[User] on [User_ID] = [ID_User] inner join [dbo].[Role] on [Role_ID] = [ID_Role]  inner join [dbo].[Class] on [Class_ID] = [ID_Class] where  [Surname] LIKE '%{PoiskPostov.Text}%' or   [First_name] LIKE '%{PoiskPostov.Text}%'or   [Middle_name] LIKE '%{PoiskPostov.Text}%'or   [Number] LIKE '%{PoiskPostov.Text}%' or [Letter] LIKE '%{PoiskPostov.Text}%'", Dataclass.act.select);

                    for (int i = 0; i < IDStudentClass.resultTable.Rows.Count; i++)
                    {
                        Label Otstyp = new Label();
                        Label Linia = new Label();
                        WrapPanel ForBtn = new WrapPanel();

                        Label fiostudents = new Label();
                        Label mailphonestudents = new Label();

                        StackPanel stackforLabel = new StackPanel();

                        fiostudents.Content = FIOstud.resultTable.Rows[i][0].ToString() + " " + ClassNumStud.resultTable.Rows[i][0].ToString() + ClasbykStud.resultTable.Rows[i][0].ToString() + "                                " + RoleUser.resultTable.Rows[i][0].ToString();
                        fiostudents.FontWeight = FontWeights.Bold;
                        fiostudents.FontSize = 20;
                        fiostudents.HorizontalContentAlignment = HorizontalAlignment.Center;

                        mailphonestudents.Content = MailPhoneStud.resultTable.Rows[i][0].ToString();
                        mailphonestudents.FontSize = 17;
                        mailphonestudents.HorizontalContentAlignment = HorizontalAlignment.Left;
                        mailphonestudents.Margin = new Thickness(190, 0, 0, 0);

                        stackforLabel.Orientation = Orientation.Horizontal;
                        stackforLabel.Margin = new Thickness(0, 20, 0, 0);
                        Otstyp.Width = 170;

                        ForBtn.HorizontalAlignment = HorizontalAlignment.Center;
                        Linia.Content = "――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――";
                        Linia.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        Linia.HorizontalContentAlignment = HorizontalAlignment.Center;
                        Linia.FontSize = 30;
                        Linia.FontWeight = FontWeights.Bold;


                        stackPanel.Children.Add(stackforLabel);
                        stackPanel.Children.Add(mailphonestudents);
                        stackPanel.Children.Add(ForBtn);
                        stackforLabel.Children.Add(Otstyp);
                        stackforLabel.Children.Add(fiostudents);

                        ForBtn.Children.Add(Linia);

                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


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

        private void PoiskBTN(object sender, RoutedEventArgs e)
        {
            ClearDynamic();
            AllStudentSearch();
        }

        private void ExitBTN(object sender, RoutedEventArgs e)
        {
            Auth window1 = new Auth();
            window1.Show(); Close();
        }
    }
}
