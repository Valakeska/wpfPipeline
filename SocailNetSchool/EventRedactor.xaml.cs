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
    /// Логика взаимодействия для EventRedactor.xaml
    /// </summary>
    public partial class EventRedactor : Window
    {
        public EventRedactor()
        {
            InitializeComponent();
            FillDataGrid();
        }

        public void FillDataGrid()
        {
            Dataclass dataClass = new Dataclass();
            dataClass.sqlCommands($"select * from [dbo].[Event]", Dataclass.act.select);

            DGadmin.ItemsSource = dataClass.resultTable.DefaultView;


        }

        private void News_Click(object sender, RoutedEventArgs e)
        {
            RedactorWindow window1 = new RedactorWindow();
            window1.Show(); Close();
        }

        private void ExitBTN(object sender, RoutedEventArgs e)
        {
            Auth window1 = new Auth();
            window1.Show(); Close();
        }

        private void EventBTN_Click(object sender, RoutedEventArgs e)
        {
            EventRedactor window1 = new EventRedactor();
            window1.Show(); Close();
        }

        private void UpdateDataDGbtn(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DGadmin.Items.Count != 0 & DGadmin.SelectedItems.Count != 0)
                {
                    string Str = new TextRange(OpisanieTB.Document.ContentStart, OpisanieTB.Document.ContentEnd).Text;

                    DataRowView dataRow = (DataRowView)DGadmin.SelectedItems[0];
                    Dataclass dataClass = new Dataclass();
                    dataClass.sqlCommands($"update [dbo].[Event] set [Title] = '{TitleTB.Text}', [Content] = '{Str}', [Picture] = '{ImageTB.Text}' where [ID_Event] = {dataRow[0]}", Dataclass.act.manipulation);
                    FillDataGrid();
                }
                else
                {
                    MessageBox.Show("Выберите запись!");
                }
            }
            catch
            {
                MessageBox.Show("В каком-то из полей ошибка!");
            }

        }

        private void AddDataDGbtn(object sender, RoutedEventArgs e)
        {
            try
            {
                string Str = new TextRange(OpisanieTB.Document.ContentStart, OpisanieTB.Document.ContentEnd).Text;

                Dataclass dataClass = new Dataclass();
                dataClass.sqlCommands($"insert into [dbo].[Event] ([Title],[Time],[Content],[Picture]) values ('{TitleTB.Text}','{DateTime.Now.ToString()}', '{Str}', '{ImageTB.Text}')", Dataclass.act.manipulation);
                FillDataGrid();
            }
            catch
            {
                MessageBox.Show("В каком-то из полей ошибка!");
            }
        }

        private void DeleteDataDGbtn(object sender, RoutedEventArgs e)
        {
            if (DGadmin.Items.Count != 0 & DGadmin.SelectedItems.Count != 0)
            {
                try
                {
                    DataRowView dataRow = (DataRowView)DGadmin.SelectedItems[0];
                    Dataclass dataClass = new Dataclass();
                    dataClass.sqlCommands($"delete from [dbo].[Visiting_event]  where [Event_ID] = {dataRow[0]}", Dataclass.act.manipulation);
                    dataClass.sqlCommands($"delete from [dbo].[Event] where [ID_Event] = {dataRow[0]}", Dataclass.act.manipulation);
                    
                    FillDataGrid();
                }
                catch
                {
                    MessageBox.Show("Данную запись пока что нельзя удалить");
                }
            }
        }
    }
}
