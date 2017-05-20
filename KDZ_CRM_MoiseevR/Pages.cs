using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_CRM_MoiseevR
{

    // Singleton

    static class KDZ_CRM_Pages
    {

        private static LoginPage _loginPage = new LoginPage();

        public static LoginPage LoginPage
        {
            get
            {
                return _loginPage;
            }
        }

        private static User_Menu _user_Menu = new User_Menu();

        public static User_Menu User_Menu
        {
            get
            {
                return _user_Menu;
            }
        }

        private static Administrator_Menu _administrator_Menu = new Administrator_Menu();

        public static Administrator_Menu Administrator_Menu
        {
            get
            {
                return _administrator_Menu;
            }
        }
    }
}
