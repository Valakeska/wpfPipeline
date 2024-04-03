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
    /// Логика взаимодействия для CRUDRole.xaml
    /// </summary>
    public partial class CRUDRole : Window
    {
        public CRUDRole()
        {
            InitializeComponent();
            FillDataGrid();
        }

        public void FillDataGrid()
        {
            Dataclass dataClass = new Dataclass();
            dataClass.sqlCommands($"select * from [dbo].[Role]", Dataclass.act.select);

            DGadmin.ItemsSource = dataClass.resultTable.DefaultView;


        }
        private void AddDataDGbtn(object sender, RoutedEventArgs e)
        {
            try
            {
                Dataclass dataClass = new Dataclass();
                dataClass.sqlCommands($"insert into [dbo].[Role] ([Tittle]) values ('{RoleTB.Text}')", Dataclass.act.manipulation);
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
                    dataClass.sqlCommands($"update [dbo].[Role] set [Tittle] = '{RoleTB.Text}' where [ID_Role] = {dataRow[0]}", Dataclass.act.manipulation);
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
                    dataClass.sqlCommands($"delete from [dbo].[Role] where [ID_Role] = {dataRow[0]}", Dataclass.act.manipulation);
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
