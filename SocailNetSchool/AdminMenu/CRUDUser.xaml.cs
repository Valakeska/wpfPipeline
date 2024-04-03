using SocialNetSchool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
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
    /// Логика взаимодействия для CRUDUser.xaml
    /// </summary>
    public partial class CRUDUser : Window
    {
        public CRUDUser()
        {
            InitializeComponent();
            FillDataGrid();
        }

        public void FillDataGrid()
        {
            Dataclass dataClass = new Dataclass();
            dataClass.sqlCommands($"select * from [dbo].[User] ", Dataclass.act.select);

            DGadmin.ItemsSource = dataClass.resultTable.DefaultView;


        }

        private void CBRole_Loaded(object sender, RoutedEventArgs e)
        {
            Dataclass dataClass = new Dataclass();
            dataClass.sqlCommands("select [ID_Role],[Tittle] from [dbo].[Role]", Dataclass.act.select);
            CBRole.ItemsSource = dataClass.resultTable.DefaultView;
            CBRole.SelectedValuePath = dataClass.resultTable.Columns[0].ColumnName;
            CBRole.DisplayMemberPath = dataClass.resultTable.Columns[1].ColumnName;
        }

        private void AddDataDGbtn(object sender, RoutedEventArgs e)
        {
            try
            {
                Dataclass dataClass = new Dataclass();
                dataClass.sqlCommands($"insert into [dbo].[User] ([Phone_Number],[Email],[Surname], [First_name],  [Middle_name], [Role_ID],[Login],[Password]) values ('{PhoneTB.Text}','{MailTB.Text}','{SurnameTB.Text}','{NameTB.Text}','{MidnameTB.Text}',{CBRole.SelectedValue},'{LoginTB.Text}','{PasswordTB.Text}')", Dataclass.act.manipulation);
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
                    dataClass.sqlCommands($"update [dbo].[User] set [Phone_Number] = '{PhoneTB.Text}',[Email] = '{MailTB.Text}',[Surname] = '{SurnameTB.Text}',[First_name] = '{NameTB.Text}',[Middle_name] = '{MidnameTB.Text}',[Role_ID] = {CBRole.SelectedValue},[Login] = '{LoginTB.Text}',[Password] = '{PasswordTB.Text}' where [ID_User] = {dataRow[0]}", Dataclass.act.manipulation);
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
                    dataClass.sqlCommands($"delete from [dbo].[User] where [ID_User] = {dataRow[0]}", Dataclass.act.manipulation);
                    FillDataGrid();
                }
                catch
                {
                    MessageBox.Show("Данную запись пока что нельзя удалить");
                }
            }
        }

        private void ExitBTN(object sender, RoutedEventArgs e)
        {
            AdminMainWindow window1 = new AdminMainWindow();
            window1.Show(); Close();
        }
    }
}
