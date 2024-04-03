using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void PolycBD_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(string.Format("Data Source = {0}; Initial Catalog = master; Integrated Security = True;", CB.Text));
            SqlCommand command = new SqlCommand("select name from sys.databases", connection);
            DataTable ressTable = new DataTable();
            connection.Open();
            ressTable.Load(command.ExecuteReader());
            foreach (DataRow dataRow in ressTable.Rows)
            {
                DBCB.Items.Add(dataRow[0]);
            }
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            string Con = string.Format("Server = {0}; Initial Catalog = {1}; Integrated Security=true", CB.Text, DBCB.Text);
            SqlConnection connection = new SqlConnection(Con);
            try
            {
                connection.Open();
                Dataclass.ConnectionString = Con;
                Auth authorize = new Auth();
                authorize.Show();
                this.Close();
            }
            catch

            {
                connection.Close();
                MessageBox.Show("Что то пошло не так");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            System.Data.DataTable table = instance.GetDataSources();
            foreach (System.Data.DataRow row in table.Rows)
            {
                DBCB.Items.Add(string.Format("{0} = {1}", row[0], row[1]));
            }

        }
    }


}

