using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocailNetSchool
{
    class Dataclass
    {



        public static string ConnectionString;
        public SqlConnection connection = new SqlConnection(ConnectionString);
        public SqlCommand command = new SqlCommand();
        public SqlDependency dependency = new SqlDependency();
        public DataTable resultTable = new DataTable();
        public enum act { select, manipulation };
        /// <summary>
        /// Метод для подключения к базе данных и работы с запросами к базе
        /// </summary>
        public void sqlCommands(string quety, act act)
        {
            command.Connection = connection;
            command.CommandText = quety;
            command.Notification = null;
            switch (act)
            {
                case act.select:
                    dependency.AddCommandDependency(command);
                    SqlDependency.Start(connection.ConnectionString);
                    connection.Open();
                    resultTable.Load(command.ExecuteReader());
                    connection.Close();
                    break;

                case act.manipulation:
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    break;
            }
        }



    }
}
