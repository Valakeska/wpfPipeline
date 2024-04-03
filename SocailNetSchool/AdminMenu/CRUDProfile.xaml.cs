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
using static System.Net.Mime.MediaTypeNames;

namespace SocailNetSchool.AdminMenu
{
    /// <summary>
    /// Логика взаимодействия для CRUDProfile.xaml
    /// </summary>
    public partial class CRUDProfile : Window
    {
        public CRUDProfile()
        {
            InitializeComponent();
            FillDataGrid();
        }

        public void FillDataGrid()
        {
            Dataclass dataClass = new Dataclass();
            dataClass.sqlCommands($"select [ID_Profile],[Profile_picture],[Description],[First_name]+' '+[Surname]+' '+[Middle_name] from [dbo].[Profile]  inner join [dbo].[User] on [User_ID] = [ID_User] inner join [dbo].[Role] on [Role_ID] = [ID_Role] where [Tittle] = 'Учитель' or [Tittle] = 'Ученик'", Dataclass.act.select);

            DGadmin.ItemsSource = dataClass.resultTable.DefaultView;


        }
        private void CBUser_Loaded(object sender, RoutedEventArgs e)
        {
            Dataclass dataClass = new Dataclass();
            dataClass.sqlCommands("select [ID_User],[First_name]+' '+[Surname]+' '+[Middle_name] from [dbo].[User]  inner join [dbo].[Role] on [Role_ID] = [ID_Role] where [Tittle] = 'Учитель' or [Tittle] = 'Ученик' ", Dataclass.act.select);
            CBUser.ItemsSource = dataClass.resultTable.DefaultView;
            CBUser.SelectedValuePath = dataClass.resultTable.Columns[0].ColumnName;
            CBUser.DisplayMemberPath = dataClass.resultTable.Columns[1].ColumnName;
        }
        private void ExitBTN(object sender, RoutedEventArgs e)
        {
            AdminMainWindow window1 = new AdminMainWindow();
            window1.Show(); Close();
        }

        private void AddDataDGbtn(object sender, RoutedEventArgs e)
        {
            try
            {
                string Str = new TextRange(OpisanieProfile.Document.ContentStart, OpisanieProfile.Document.ContentEnd).Text;

                Dataclass dataClass = new Dataclass();
                dataClass.sqlCommands($"insert into [dbo].[Profile] ([Profile_picture],[Description],[User_ID]) values ('{ImageTb.Text}','{Str}',{CBUser.SelectedValue})", Dataclass.act.manipulation);
                FillDataGrid();
            }
            catch
            {
                MessageBox.Show("В каком-то из полей ошибка!");
            }
        }

        private void UpdateDataDGbtn(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DGadmin.Items.Count != 0 & DGadmin.SelectedItems.Count != 0)
                {
                    string Str = new TextRange(OpisanieProfile.Document.ContentStart, OpisanieProfile.Document.ContentEnd).Text;
                    DataRowView dataRow = (DataRowView)DGadmin.SelectedItems[0];

                    Dataclass UpdateUser = new Dataclass();
                UpdateUser.sqlCommands($"update [dbo].[Profile] set [Profile_picture] = '{ImageTb.Text}',[Description] = '{Str}',[User_ID] = {CBUser.SelectedValue} where [ID_Profile] = {dataRow[0]}", Dataclass.act.manipulation);
                MessageBox.Show("Данные успешно изменены!");

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

        private void DeleteDataDGbtn(object sender, RoutedEventArgs e)
        {
            if (DGadmin.Items.Count != 0 & DGadmin.SelectedItems.Count != 0)
            {
                try
                {
                    DataRowView dataRow = (DataRowView)DGadmin.SelectedItems[0];
                    Dataclass dataClass = new Dataclass();
                    dataClass.sqlCommands($"delete from [dbo].[Profile] where [ID_Profile] = {dataRow[0]}", Dataclass.act.manipulation);
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
