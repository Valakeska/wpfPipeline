using SocailNetSchool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace SocialNetSchool
{
    /// <summary>
    /// Логика взаимодействия для GlavMenu.xaml
    /// </summary>
    public partial class GlavMenu : Window
    {
        public GlavMenu()
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
                Dataclass IDPost = new Dataclass();
                IDPost.sqlCommands($"SELECT [ID_News] FROM [dbo].[News] order by [ID_News] DESC", Dataclass.act.select);

                Dataclass IDContentPost = new Dataclass();
                IDContentPost.sqlCommands($"SELECT [Content] FROM [dbo].[News]  order by [ID_News] DESC", Dataclass.act.select);

                Dataclass IDTitlePost = new Dataclass();
                IDTitlePost.sqlCommands($"SELECT [Title] FROM [dbo].[News]  order by [ID_News] DESC", Dataclass.act.select);

                Dataclass IDTimePost = new Dataclass();
                IDTimePost.sqlCommands($"SELECT [Time] FROM [dbo].[News] order by [ID_News] DESC", Dataclass.act.select);

                Dataclass IDPicturePost = new Dataclass();
                IDPicturePost.sqlCommands($"SELECT [Picture] FROM [dbo].[News] order by [ID_News] DESC", Dataclass.act.select);

                for (int i = 0; i < IDPost.resultTable.Rows.Count; i++)
                {
                    string LinkPucture = IDPicturePost.resultTable.Rows[i][0].ToString();
                    int idPost = Convert.ToInt32(IDPost.resultTable.Rows[i][0]);

                    StackPanel Razdelit = new StackPanel();
                    StackPanel stackPanel2 = new StackPanel();
                    stackPanel2.Orientation = Orientation.Horizontal;
                    Grid dridd = new Grid();
                    StackPanel stackPanel1 = new StackPanel();
                    WrapPanel ForPicture = new WrapPanel();
                    Label time = new Label();
                    TextBlock Title = new TextBlock();
                    TextBlock Countain = new TextBlock();
                    Grid image = new Grid();
                    Label Otstyp = new Label();


                    Label Otstyp2 = new Label();
                    Otstyp2.Width = 300;

                    ForPicture.HorizontalAlignment = HorizontalAlignment.Center;
                    time.Content = IDTimePost.resultTable.Rows[i][0].ToString();
                    time.FontSize = 15;
                    time.FontFamily = new FontFamily("Cambri");
                    time.HorizontalContentAlignment = HorizontalAlignment.Left;

                    image.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), LinkPucture)));
                    image.Width = 200;
                    image.Height = 200;
                    Otstyp.Width = 270;

                    Title.Text = IDTitlePost.resultTable.Rows[i][0].ToString();
                    Title.TextWrapping = TextWrapping.Wrap;
                    Title.FontSize = 16;
                    Title.FontFamily = new FontFamily("Cambri");
                    Title.Width = 550;
                    Title.Background = new SolidColorBrush(Color.FromRgb(144, 168, 214));

                    Countain.Text = IDContentPost.resultTable.Rows[i][0].ToString();
                    Countain.TextWrapping = TextWrapping.Wrap;
                    Countain.FontSize = 14;
                    Countain.FontFamily = new FontFamily("Cambri");
                    Countain.Width = 550;
                    Countain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 214));

                    Razdelit.Background = new SolidColorBrush(Color.FromRgb(144, 193, 214));

                    stackPanel.Children.Add(Razdelit);
                    stackPanel.Children.Add(Otstyp2);
                    Razdelit.Children.Add(stackPanel2);
                    Razdelit.Children.Add(stackPanel1);
                    Razdelit.Children.Add(ForPicture);
                    stackPanel1.Children.Add(Title);
                    stackPanel1.Children.Add(dridd);
                    stackPanel2.Children.Add(time);
                    ForPicture.Children.Add(image);
                    dridd.Children.Add(Countain);
                }
            }
            else
            {
                Dataclass IDPost = new Dataclass();
                IDPost.sqlCommands($"SELECT [ID_News] FROM [dbo].[News] where [Content] LIKE '%{PoiskPostov.Text}%' or  [Title] LIKE '%{PoiskPostov.Text}%' order by [ID_News] DESC", Dataclass.act.select);

                Dataclass IDContentPost = new Dataclass();
                IDContentPost.sqlCommands($"SELECT [Title] FROM [dbo].[News] where [Content] LIKE '%{PoiskPostov.Text}%' or  [Title] LIKE '%{PoiskPostov.Text}%' order by [ID_News] DESC", Dataclass.act.select);

                Dataclass IDTitlePost = new Dataclass();
                IDTitlePost.sqlCommands($"SELECT [Content] FROM [dbo].[News] where [Content] LIKE '%{PoiskPostov.Text}%'or  [Title] LIKE '%{PoiskPostov.Text}%'  order by [ID_News] DESC", Dataclass.act.select);

                Dataclass IDTimePost = new Dataclass();
                IDTimePost.sqlCommands($"SELECT [Time] FROM [dbo].[News] where [Content] LIKE '%{PoiskPostov.Text}%'or  [Title] LIKE '%{PoiskPostov.Text}%' order by [ID_News] DESC", Dataclass.act.select);

                Dataclass IDPicturePost = new Dataclass();
                IDPicturePost.sqlCommands($"SELECT [Picture] FROM [dbo].[News] where [Content] LIKE '%{PoiskPostov.Text}%'or  [Title] LIKE '%{PoiskPostov.Text}%' order by [ID_News] DESC", Dataclass.act.select);





                for (int i = 0; i < IDPost.resultTable.Rows.Count; i++)
                {
                    string LinkPucture = IDPicturePost.resultTable.Rows[i][0].ToString();
                    int idPost = Convert.ToInt32(IDPost.resultTable.Rows[i][0]);

                    StackPanel Razdelit = new StackPanel();
                    StackPanel stackPanel2 = new StackPanel();
                    stackPanel2.Orientation = Orientation.Horizontal;
                    Grid dridd = new Grid();
                    StackPanel stackPanel1 = new StackPanel();
                    WrapPanel ForPicture = new WrapPanel();
                    Label time = new Label();
                    TextBlock Countain = new TextBlock();
                    TextBlock Title = new TextBlock();

                    Grid image = new Grid();
                    Label Otstyp = new Label();

                   

                    Label Otstyp2 = new Label();
                    Otstyp2.Width = 300;

                    ForPicture.HorizontalAlignment = HorizontalAlignment.Center;
                    time.Content = IDTimePost.resultTable.Rows[i][0].ToString();
                    time.FontSize = 15;
                    time.FontFamily = new FontFamily("Cambri");
                    time.HorizontalContentAlignment = HorizontalAlignment.Left;

                    image.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), LinkPucture)));
                    image.Width = 200;
                    image.Height = 200;
                    Otstyp.Width = 270;

                    Title.Text = IDTitlePost.resultTable.Rows[i][0].ToString();
                    Title.TextWrapping = TextWrapping.Wrap;
                    Title.FontSize = 16;
                    Title.FontFamily = new FontFamily("Cambri");
                    Title.Width = 550;
                    Title.Background = new SolidColorBrush(Color.FromRgb(144, 168, 214));

                    Countain.Text = IDContentPost.resultTable.Rows[i][0].ToString();
                    Countain.TextWrapping = TextWrapping.Wrap;
                    Countain.FontSize = 14;
                    Countain.FontFamily = new FontFamily("Cambri");
                    Countain.Width = 550;
                    Countain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 214));

                    Razdelit.Background = new SolidColorBrush(Color.FromRgb(144, 193, 214));

                    stackPanel.Children.Add(Razdelit);
                    stackPanel.Children.Add(Otstyp2);
                    Razdelit.Children.Add(stackPanel2);
                    Razdelit.Children.Add(stackPanel1);
                    Razdelit.Children.Add(ForPicture);
                    stackPanel1.Children.Add(Title);
                    stackPanel1.Children.Add(dridd);
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
        
       
        private void PoiskBTN_Click(object sender, RoutedEventArgs e)
        {
            ClearDynamic();
            poisk();
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

        private void ExitBTN(object sender, RoutedEventArgs e)
        {
            Auth window1 = new Auth();
            window1.Show(); Close();
        }
    }
}
