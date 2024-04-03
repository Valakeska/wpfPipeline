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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SocailNetSchool
{
    /// <summary>
    /// Логика взаимодействия для Event.xaml
    /// </summary>
    public partial class Event : Window
    {
        public Event()
        {
            InitializeComponent();
            poisk();
        }

        public void poisk()
        {
            StackPanel stackPanel = new StackPanel();

            StackMain.Children.Add(stackPanel);

            if (PoiskPostov.Text == "")
            {
                Dataclass IDEvent = new Dataclass();
                IDEvent.sqlCommands($"SELECT [ID_Event] FROM [dbo].[Event] order by [ID_Event] DESC", Dataclass.act.select);

                Dataclass IDContentEvent = new Dataclass();
                IDContentEvent.sqlCommands($"SELECT [Content] FROM [dbo].[Event]  order by [ID_Event] DESC", Dataclass.act.select);

                Dataclass IDTitleEvent = new Dataclass();
                IDTitleEvent.sqlCommands($"SELECT [Title] FROM [dbo].[Event]  order by [ID_Event] DESC", Dataclass.act.select);

                Dataclass IDTimeEvent = new Dataclass();
                IDTimeEvent.sqlCommands($"SELECT [Time] FROM [dbo].[Event] order by [ID_Event] DESC", Dataclass.act.select);

                Dataclass IDPictureEvent = new Dataclass();
                IDPictureEvent.sqlCommands($"SELECT [Picture] FROM [dbo].[Event] order by [ID_Event] DESC", Dataclass.act.select);

               
                for (int i = 0; i < IDEvent.resultTable.Rows.Count; i++)
                {
                    string LinkPucture = IDPictureEvent.resultTable.Rows[i][0].ToString();
                    int idevent = Convert.ToInt32(IDEvent.resultTable.Rows[i][0]);

                    StackPanel Razdelit = new StackPanel();
                    StackPanel stackPanel2 = new StackPanel();
                    stackPanel2.Orientation = Orientation.Horizontal;
                    Grid dridd = new Grid();
                    StackPanel stackPanel1 = new StackPanel();
                    WrapPanel ForPicture = new WrapPanel();
                    Label time = new Label();
                    TextBlock Title = new TextBlock();
                    TextBlock Countain = new TextBlock();
                    Label CountPeople = new Label();
                    Grid image = new Grid();
                    Label Otstyp = new Label();
                    Button joineventBTN = new Button();

                    joineventBTN.Content = "Я пойду!";
                    joineventBTN.Width = 400;
                    joineventBTN.Height = 50;
                    joineventBTN.Margin = new Thickness(0, 20, 0, 0);
                    joineventBTN.Click += new RoutedEventHandler(joineventBTN_Click);
                    void joineventBTN_Click(object sender, RoutedEventArgs e)
                    {
                        int strok = 1;
                        Dataclass SearchZapis = new Dataclass();
                        SearchZapis.sqlCommands($"SELECT [User_ID] FROM [dbo].[Visiting_event] where [Event_ID] = {idevent} and [User_ID] = {App.UserIdd}", Dataclass.act.select);
                        if (SearchZapis.resultTable.Rows.Count >= strok)
                        {
                            MessageBox.Show("Вы уже записались");
                        }
                        else
                        {
                            Dataclass Zapis = new Dataclass();

                            Zapis.sqlCommands($"insert into [dbo].[Visiting_event] ([Event_ID],[User_ID]) values ({idevent}, {App.UserIdd})", Dataclass.act.manipulation);
                            MessageBox.Show("Вы успешно записаны");
                        }


                    }


                    Label Otstyp2 = new Label();
                    Otstyp2.Width = 300;

                    ForPicture.HorizontalAlignment = HorizontalAlignment.Center;
                    time.Content = IDTimeEvent.resultTable.Rows[i][0].ToString();
                    time.FontSize = 15;
                    time.FontFamily = new FontFamily("Cambri");
                    time.HorizontalContentAlignment = HorizontalAlignment.Left;

                    image.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), LinkPucture)));
                    image.Width = 350;
                    image.Height = 350;
                    Otstyp.Width = 270;

                    Title.Text = IDTitleEvent.resultTable.Rows[i][0].ToString();
                    Title.TextWrapping = TextWrapping.Wrap;
                    Title.FontSize = 20;
                    Title.FontFamily = new FontFamily("Cambri");
                    Title.Width = 550;
                    Title.Background = new SolidColorBrush(Color.FromRgb(144, 168, 214));

                    Countain.Text = IDContentEvent.resultTable.Rows[i][0].ToString();
                    Countain.TextWrapping = TextWrapping.Wrap;
                    Countain.FontSize = 18;
                    Countain.FontFamily = new FontFamily("Cambri");
                    Countain.Width = 550;
                    Countain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 214));



                    try
                    {
                        Dataclass IdCountPeopelEvent = new Dataclass();

                        IdCountPeopelEvent.sqlCommands($"SELECT * FROM [dbo].[Visiting_event] where [Event_ID] = {idevent}", Dataclass.act.select);
                        CountPeople.Content = "Пойдет - " + IdCountPeopelEvent.resultTable.Rows.Count.ToString() + " человек";
                        CountPeople.FontSize = 18;
                        CountPeople.FontFamily = new FontFamily("Cambri");
                        CountPeople.Width = 550;
                    }
                    catch
                    {
                        CountPeople.Content = "Пойдет - 0 человек";
                        CountPeople.FontSize = 18;
                        CountPeople.FontFamily = new FontFamily("Cambri");
                        CountPeople.Width = 550;
                    }
                    

                    Razdelit.Background = new SolidColorBrush(Color.FromRgb(144, 193, 214));

                    stackPanel.Children.Add(Razdelit);
                    stackPanel.Children.Add(Otstyp2);
                    Razdelit.Children.Add(stackPanel2);
                    Razdelit.Children.Add(stackPanel1);
                    Razdelit.Children.Add(ForPicture);
                    Razdelit.Children.Add(joineventBTN);
                    stackPanel1.Children.Add(Title);
                    stackPanel1.Children.Add(dridd);
                    stackPanel1.Children.Add(CountPeople);
                    stackPanel2.Children.Add(time);
                    ForPicture.Children.Add(image);
                    
                    dridd.Children.Add(Countain);
                    
                }
            }
            else
            {
                Dataclass IDEvent = new Dataclass();
                IDEvent.sqlCommands($"SELECT [ID_Event] FROM [dbo].[Event] where [Content] LIKE '%{PoiskPostov.Text}%' or  [Title] LIKE '%{PoiskPostov.Text}%' order by [ID_Event] DESC", Dataclass.act.select);

                Dataclass IDContentEvent = new Dataclass();
                IDContentEvent.sqlCommands($"SELECT [Title] FROM [dbo].[Event] where [Content] LIKE '%{PoiskPostov.Text}%' or  [Title] LIKE '%{PoiskPostov.Text}%' order by [ID_Event] DESC", Dataclass.act.select);

                Dataclass IDTitleEvent = new Dataclass();
                IDTitleEvent.sqlCommands($"SELECT [Content] FROM [dbo].[Event] where [Content] LIKE '%{PoiskPostov.Text}%'or  [Title] LIKE '%{PoiskPostov.Text}%'  order by [ID_Event] DESC", Dataclass.act.select);

                Dataclass IDTimeEvent = new Dataclass();
                IDTimeEvent.sqlCommands($"SELECT [Time] FROM [dbo].[Event] where [Content] LIKE '%{PoiskPostov.Text}%'or  [Title] LIKE '%{PoiskPostov.Text}%' order by [ID_Event] DESC", Dataclass.act.select);

                Dataclass IDPictureEvent = new Dataclass();
                IDPictureEvent.sqlCommands($"SELECT [Picture] FROM [dbo].[Event] where [Content] LIKE '%{PoiskPostov.Text}%'or  [Title] LIKE '%{PoiskPostov.Text}%' order by [ID_Event] DESC", Dataclass.act.select);



                for (int i = 0; i < IDEvent.resultTable.Rows.Count; i++)
                {
                    string LinkPucture = IDPictureEvent.resultTable.Rows[i][0].ToString();
                    int idevent = Convert.ToInt32(IDEvent.resultTable.Rows[i][0]);

                    StackPanel Razdelit = new StackPanel();
                    StackPanel stackPanel2 = new StackPanel();
                    stackPanel2.Orientation = Orientation.Horizontal;
                    Grid dridd = new Grid();
                    StackPanel stackPanel1 = new StackPanel();
                    WrapPanel ForPicture = new WrapPanel();
                    Label time = new Label();
                    TextBlock Countain = new TextBlock();
                    Label CountPeople = new Label();

                    TextBlock Title = new TextBlock();
                    Button joineventBTN = new Button();

                    joineventBTN.Content = "Я пойду!";
                    joineventBTN.Width = 400;
                    joineventBTN.Height = 50;
                    joineventBTN.Margin = new Thickness(0, 20, 0, 0);
                    joineventBTN.Click += new RoutedEventHandler(joineventBTN_Click);
                    void joineventBTN_Click(object sender, RoutedEventArgs e)
                    {
                         int strok = 1;
                            Dataclass SearchZapis = new Dataclass();
                            SearchZapis.sqlCommands($"SELECT [User_ID] FROM [dbo].[Visiting_event] where [Event_ID] = {idevent} and [User_ID] = {App.UserIdd}", Dataclass.act.select);
                            if(SearchZapis.resultTable.Rows.Count >= strok)
                            {
                                MessageBox.Show("Вы уже записались");
                            }
                            else
                            {
                                Dataclass Zapis = new Dataclass();

                                Zapis.sqlCommands($"insert into [dbo].[Visiting_event] ([Event_ID],[User_ID]) values ({idevent}, {App.UserIdd})", Dataclass.act.manipulation);
                                MessageBox.Show("Вы успешно записаны");
                            }
                        


                    }


                    Grid image = new Grid();
                    Label Otstyp = new Label();



                    Label Otstyp2 = new Label();
                    Otstyp2.Width = 300;

                    ForPicture.HorizontalAlignment = HorizontalAlignment.Center;
                    time.Content = IDTimeEvent.resultTable.Rows[i][0].ToString();
                    time.FontSize = 15;
                    time.FontFamily = new FontFamily("Cambri");
                    time.HorizontalContentAlignment = HorizontalAlignment.Left;

                    image.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), LinkPucture)));
                    image.Width = 350;
                    image.Height = 350;
                    Otstyp.Width = 270;

                    Title.Text = IDTitleEvent.resultTable.Rows[i][0].ToString();
                    Title.TextWrapping = TextWrapping.Wrap;
                    Title.FontSize = 16;
                    Title.FontFamily = new FontFamily("Cambri");
                    Title.Width = 550;
                    Title.Background = new SolidColorBrush(Color.FromRgb(144, 168, 214));

                    Countain.Text = IDContentEvent.resultTable.Rows[i][0].ToString();
                    Countain.TextWrapping = TextWrapping.Wrap;
                    Countain.FontSize = 14;
                    Countain.FontFamily = new FontFamily("Cambri");
                    Countain.Width = 550;
                    Countain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 214));


                    try
                    {
                        Dataclass IdCountPeopelEvent = new Dataclass();

                        IdCountPeopelEvent.sqlCommands($"SELECT * FROM [dbo].[Visiting_event] where [Event_ID] = {idevent}", Dataclass.act.select);
                        CountPeople.Content = "Пойдет - " + IdCountPeopelEvent.resultTable.Rows.Count.ToString() + " человек";
                        CountPeople.FontSize = 18;
                        CountPeople.FontFamily = new FontFamily("Cambri");
                        CountPeople.Width = 550;
                    }
                    catch
                    {
                        CountPeople.Content = "Пойдет - 0 человек";
                        CountPeople.FontSize = 18;
                        CountPeople.FontFamily = new FontFamily("Cambri");
                        CountPeople.Width = 550;
                    }


                    Razdelit.Background = new SolidColorBrush(Color.FromRgb(144, 193, 214));

                    stackPanel.Children.Add(Razdelit);
                    stackPanel.Children.Add(Otstyp2);
                    Razdelit.Children.Add(stackPanel2);
                    Razdelit.Children.Add(stackPanel1);
                    Razdelit.Children.Add(ForPicture);
                    Razdelit.Children.Add(joineventBTN);

                    stackPanel1.Children.Add(Title);
                    stackPanel1.Children.Add(dridd);
                    stackPanel1.Children.Add(CountPeople);

                    stackPanel2.Children.Add(time);
                    ForPicture.Children.Add(image);
                    dridd.Children.Add(Countain);
                }
            }
        }
        public void ClearDynamic()//очистить результаты поиска
        {
            StackMain.Children.Clear();
        }


        private void Poisk_Click_1(object sender, RoutedEventArgs e)
        {
            ClearDynamic();
            poisk();
        }
        

        private void EventBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void News_Click(object sender, RoutedEventArgs e)
        {
            GlavMenu window1 = new GlavMenu();
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

        private void ProfileBtn_click(object sender, RoutedEventArgs e)
        {
            ProfileUser window1 = new ProfileUser();
            window1.Show(); Close();
        }

        private void ExitBTN(object sender, RoutedEventArgs e)
        {
            Auth window1 = new Auth();
            window1.Show(); Close();
        }
    }
}
