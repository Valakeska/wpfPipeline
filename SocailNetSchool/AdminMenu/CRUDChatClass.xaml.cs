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
    /// Логика взаимодействия для CRUDChatClass.xaml
    /// </summary>
    public partial class CRUDChatClass : Window
    {
        public CRUDChatClass()
        {
            InitializeComponent();
            FillDataGrid();
        }

        public void FillDataGrid()
        {
            Dataclass dataClass = new Dataclass();
            dataClass.sqlCommands($"select * from [dbo].[Class_Chat]", Dataclass.act.select);

            DGadmin.ItemsSource = dataClass.resultTable.DefaultView;


        }
        private void CBUser_Loaded(object sender, RoutedEventArgs e)
        {
            Dataclass dataClass = new Dataclass();
            dataClass.sqlCommands("select [ID_Member_School_Class],[First_name]+' '+[Surname]+' '+[Middle_name]+' '+CAST([Number] as VARCHAR(10))+' '+[Letter] from [dbo].[Member_School_Class]  inner join [dbo].[User] on [User_ID] = [ID_User] inner join [dbo].[Class] on [Class_ID] = [ID_Class]  ", Dataclass.act.select);
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
                Dataclass dataClass = new Dataclass();
                dataClass.sqlCommands($"insert into [dbo].[Class_Chat] ([Content],[Time],[Member_School_Class_ID]) values ('{SoderjTb.Text}','{DateTime.Now.ToString()}',{CBUser.SelectedValue})", Dataclass.act.manipulation);
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
                    dataClass.sqlCommands($"update [dbo].[Class_Chat] set [Content] = '{SoderjTb.Text}',[Member_School_Class_ID] = {CBUser.SelectedValue}  where [ID_Class_Chat] =  {dataRow[0]}", Dataclass.act.manipulation);
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
                    dataClass.sqlCommands($"delete from [dbo].[Class_Chat] where [ID_Class_Chat] = {dataRow[0]}", Dataclass.act.manipulation);
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
