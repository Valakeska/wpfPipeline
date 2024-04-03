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
using SocailNetSchool.AdminMenu;
using System.Windows.Shapes;
using SocialNetSchool;

namespace SocailNetSchool
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void Voity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dataclass db = new Dataclass();
                Dataclass dbb = new Dataclass();
                db.sqlCommands($"Select [Tittle] from dbo.[User] inner join [dbo].[Role] on [Role_ID] = [ID_Role] where [Login] = '{Login.Text}' and [Password] = '{Password.Text}'", Dataclass.act.select);
                dbb.sqlCommands($"Select [ID_Role] from dbo.[Role] where [Tittle] = '{db.resultTable.Rows[0][0].ToString()}'", Dataclass.act.select);
                App.UserRole = db.resultTable.Rows[0][0].ToString();
                if (db.resultTable.Rows.Count > 0)
                {

                    switch (db.resultTable.Rows[0][0].ToString())
                    {
                       
                        case "Учитель":
                            Dataclass iduser = new Dataclass();
                            iduser.sqlCommands($"select [ID_User] from [dbo].[User] where [Login] = '{Login.Text}' and [Password] = '{Password.Text}'", Dataclass.act.select);
                            Dataclass Idclass = new Dataclass();

                            App.UserIdd = Convert.ToInt32(iduser.resultTable.Rows[0][0]);
                            App.RoleIdd = Convert.ToInt32(dbb.resultTable.Rows[0][0]);

                            Idclass.sqlCommands($"select [ID_Member_School_Class] from [dbo].[Member_School_Class] where [User_ID] = '{App.UserIdd}' ", Dataclass.act.select);
                            App.ClassUserIdd = Convert.ToInt32(Idclass.resultTable.Rows[0][0]);
                            GlavMenu ycitel = new GlavMenu();
                            ycitel.Show(); Close();
                            break;
                        case "Ученик":
                            Dataclass idusers = new Dataclass();
                            idusers.sqlCommands($"select [ID_User] from [dbo].[User] where [Login] = '{Login.Text}' and [Password] = '{Password.Text}'", Dataclass.act.select);
                            App.UserIdd = Convert.ToInt32(idusers.resultTable.Rows[0][0]);
                            App.RoleIdd = Convert.ToInt32(dbb.resultTable.Rows[0][0]);
                            Dataclass Idclasss = new Dataclass();

                            Idclasss.sqlCommands($"select [ID_Member_School_Class] from [dbo].[Member_School_Class] where [User_ID] = '{App.UserIdd}' ", Dataclass.act.select);
                            App.ClassUserIdd = Convert.ToInt32(Idclasss.resultTable.Rows[0][0]);
                            GlavMenu ychenik = new GlavMenu();
                            ychenik.Show(); Close();
                            break;
                       
                        case "Редактор":
                            Dataclass idusersss = new Dataclass();
                            idusersss.sqlCommands($"select [ID_User] from [dbo].[User] where [Login] = '{Login.Text}' and [Password] = '{Password.Text}'", Dataclass.act.select);
                            App.UserIdd = Convert.ToInt32(idusersss.resultTable.Rows[0][0]);
                            App.RoleIdd = Convert.ToInt32(dbb.resultTable.Rows[0][0]);
                            RedactorWindow redactor = new RedactorWindow();
                            redactor.Show(); Close();
                            break;
                        case "Админ БД":
                            Dataclass iduserssss = new Dataclass();
                            iduserssss.sqlCommands($"select [ID_User] from [dbo].[User] where [Login] = '{Login.Text}' and [Password] = '{Password.Text}'", Dataclass.act.select);
                            App.UserIdd = Convert.ToInt32(iduserssss.resultTable.Rows[0][0]);
                            App.RoleIdd = Convert.ToInt32(dbb.resultTable.Rows[0][0]);
                            AdminMainWindow adminmenu = new AdminMainWindow();
                            adminmenu.Show(); Close();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь не найден!");
                }


            }
            catch (Exception mess)
            {
                MessageBox.Show("Пользователь не найден!");
            }
        }
    }
}
