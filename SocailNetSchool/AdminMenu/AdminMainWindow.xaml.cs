using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public AdminMainWindow()
        {
            InitializeComponent();
        }

        private void ExitBTN(object sender, RoutedEventArgs e)
        {
            Auth window1 = new Auth();
            window1.Show(); Close();
        }

        private void RoleCRUDbtn(object sender, RoutedEventArgs e)
        {
            CRUDRole window1 = new CRUDRole();
            window1.Show(); Close();
        }

        private void UserCRUDbtn(object sender, RoutedEventArgs e)
        {
            CRUDUser window1 = new CRUDUser();
            window1.Show(); Close();
        }

        private void ClassCRUDbtn(object sender, RoutedEventArgs e)
        {
            CRUDClass window1 = new CRUDClass();
            window1.Show(); Close();
        }

        private void ProfilesCRUDbtn(object sender, RoutedEventArgs e)
        {
            CRUDProfile window1 = new CRUDProfile();
            window1.Show(); Close();
        }

        private void MembertClassCRUDDbtn(object sender, RoutedEventArgs e)
        {
            CRUDMemberSchoolClass window1 = new CRUDMemberSchoolClass();
            window1.Show(); Close();

        }

        private void VisitingEventCRUDbtn(object sender, RoutedEventArgs e)
        {
            CRUDVisitingEvent window1 = new CRUDVisitingEvent();
            window1.Show(); Close();
        }

        private void ChatClassCRUDbtn(object sender, RoutedEventArgs e)
        {
            CRUDChatClass window1 = new CRUDChatClass();
            window1.Show(); Close();
        }
    }
}
