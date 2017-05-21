using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_CRM_MoiseevR
{
    class Company_Protected
    {
        public int Comp_ID { get; set; }
        public string Comp_Name { get; set; }
        public string Comp_Website { get; set; }
        public string Comp_Email { get; set; }
        public int Comp_ID_City { get; set; }
        public string Comp_Adress { get; set; }
        public int Comp_Contact_Telephone { get; set; }
        public string Comp_Additional_Info { get; set; }

        
    }

    class User
    {
        public int Empl_User_ID { get; set; }
        public int Empl_ID { get; set; }
        public string Login { get; set; }
        public string Hash_Pwd { get; set; }
        public bool Active { get; set; }
        public bool Admin { get; set; }

        List<Company_Protected> CompanyList;
    }

    class Employee
    {
        public int Empl_ID { get; set; }
        public string FIO { get; set; }
        public string Position { get; set; }
    }
}
