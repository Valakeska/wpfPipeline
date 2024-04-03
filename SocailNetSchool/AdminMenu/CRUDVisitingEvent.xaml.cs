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

namespace SocailNetSchool.AdminMenu
{
    /// <summary>
    /// Логика взаимодействия для CRUDVisitingEvent.xaml
    /// </summary>
    public partial class CRUDVisitingEvent : Window
    {
        public CRUDVisitingEvent()
        {
            InitializeComponent();
            FillDataGrid();
        }

        public void FillDataGrid()
        {
            Dataclass dataClass = new Dataclass();
            dataClass.sqlCommands($"select * from [dbo].[Visiting_event]", Dataclass.act.select);

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

        private void CBEvent_Loaded(object sender, RoutedEventArgs e)
        {
            Dataclass dataClass = new Dataclass();
            dataClass.sqlCommands("select [ID_Event], [Title] from [dbo].[Event] ", Dataclass.act.select);
            CBEvent.ItemsSource = dataClass.resultTable.DefaultView;
            CBEvent.SelectedValuePath = dataClass.resultTable.Columns[0].ColumnName;
            CBEvent.DisplayMemberPath = dataClass.resultTable.Columns[1].ColumnName;
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
                Dataclass dataClass = new Dataclass();
                dataClass.sqlCommands($"insert into [dbo].[Visiting_event] ([Event_ID],[User_ID]) values ({CBEvent.SelectedValue},{CBUser.SelectedValue})", Dataclass.act.manipulation);
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
                    DataRowView dataRow = (DataRowView)DGadmin.SelectedItems[0];
                    Dataclass dataClass = new Dataclass();
                    dataClass.sqlCommands($"update [dbo].[Visiting_event] set [Event_ID] = {CBEvent.SelectedValue},[User_ID] = {CBUser.SelectedValue}  where [ID_Visiting_event] =  {dataRow[0]}", Dataclass.act.manipulation);
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
                    dataClass.sqlCommands($"delete from [dbo].[Visiting_event] where [ID_Visiting_event] = {dataRow[0]}", Dataclass.act.manipulation);
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
