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
    /// Логика взаимодействия для CRUDMemberSchoolClass.xaml
    /// </summary>
    public partial class CRUDMemberSchoolClass : Window
    {
        public CRUDMemberSchoolClass()
        {
            InitializeComponent();
            FillDataGrid();
        }

        public void FillDataGrid()
        {
            Dataclass dataClass = new Dataclass();
            dataClass.sqlCommands($"select * from [dbo].[Member_School_Class]", Dataclass.act.select);

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

        private void CBClass_Loaded(object sender, RoutedEventArgs e)
        {
            Dataclass dataClass = new Dataclass();
            dataClass.sqlCommands("select [ID_Class],CAST([Number] as VARCHAR(10))+' '+[Letter] from [dbo].[Class] ", Dataclass.act.select);
            CBClass.ItemsSource = dataClass.resultTable.DefaultView;
            CBClass.SelectedValuePath = dataClass.resultTable.Columns[0].ColumnName;
            CBClass.DisplayMemberPath = dataClass.resultTable.Columns[1].ColumnName;
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
                dataClass.sqlCommands($"insert into [dbo].[Member_School_Class] ([Class_ID],[User_ID]) values ({CBClass.SelectedValue},{CBUser.SelectedValue})", Dataclass.act.manipulation);
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
                    dataClass.sqlCommands($"update [dbo].[Member_School_Class] set [Class_ID] = {CBClass.SelectedValue},[User_ID] = {CBUser.SelectedValue}  where [ID_Member_School_Class] =  {dataRow[0]}", Dataclass.act.manipulation);
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
                    dataClass.sqlCommands($"delete from [dbo].[Member_School_Class] where [ID_Member_School_Class] = {dataRow[0]}", Dataclass.act.manipulation);
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
