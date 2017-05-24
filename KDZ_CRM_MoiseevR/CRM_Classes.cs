using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_CRM_MoiseevR
{
    public class User
    {
        public int Empl_User_ID { get; set; }
        public int Empl_ID { get; set; }
        public string Login { get; set; }
        public string Hash_Pwd { get; set; }
        public bool Active { get; set; }
        public bool Admin { get; set; }

        public List<Company_Protected> User_CompanyList { get; set; }
        public List<Employee> EmployeeList { get; set; }

    }
    public class Company_Protected
    {
        public int Comp_ID { get; set; }
        public string Comp_Name { get; set; }
        public string Comp_Website { get; set; }
        public string Comp_Email { get; set; }
        public int Comp_ID_City { get; set; }
        public string Comp_Adress { get; set; }
        public int Comp_Contact_Telephone { get; set; }
        public string Comp_Additional_Info { get; set; }

        public List<Contact> Company_ContactList { get; set; }
        public List<Equipment> Company_EquipmentList { get; set; }
    }

    public class Employee
    {
        public int Empl_ID { get; set; }
        public string FIO { get; set; }
        public string Position { get; set; }
    }

    public class Person
    {
        public int Person_ID { get; set; }
        public string Person_FIO { get; set; }
        public string Person_Position { get; set; }
        public string Person_Company { get; set; }
    }

    public class Contact
    {
        public string Date { get; set; }

        public List<Person> PersonList { get; set; }
        public List<Employee> EmployeeList { get; set; }
        public List<Equipment> Contact_EquipmentList { get; set; }
    }

    public class Equipment
    {
        public int Equipment_ID { get; set; }
        public string Equipment_Name { get; set; }
    }
    
}
