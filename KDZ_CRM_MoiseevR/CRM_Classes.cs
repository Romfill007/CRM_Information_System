using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_CRM_MoiseevR
{
    public class User
    {
        public string Empl_User_ID { get; set; }
        public string Empl_ID { get; set; }
        public string Login { get; set; }
        public string Hash_Pwd { get; set; }
        public bool Active { get; set; }
        public bool Admin { get; set; }
        public Company_Protected CurComp { get; set; }
        public List<Company_Protected> User_CompanyList { get; set; }
        public List<Employee> EmployeeList { get; set; }

    }
    public class Company_Protected
    {
        public string Comp_ID { get; set; } //код компании-клиента
        public string Comp_Name { get; set; } //наименование компании-клиента
        public string Comp_Website { get; set; } // Website компании-клиента
        public string Comp_Email { get; set; }
        public string Comp_ID_City { get; set; } // код города
        public string City_Name { get; set; } //наименование города
        public string Comp_Adress { get; set; } // адрес компании
        public string Comp_Contact_Telephone { get; set; } //контактный телефон
        public string Comp_Additional_Info { get; set; } // краткое описание

        public List<Person> Company_PersonList { get; set; } // реестр контактных лиц
        public List<Contact> Company_ContactList { get; set; } // реестр контактов
        public List<Equipment> Company_EquipmentList { get; set; } // реестр оборудования
    }

    public class Employee
    {
        public string Empl_ID { get; set; } // код сотрудника
        public string FIO { get; set; } // ФИО сотрудника
        public string Position { get; set; } // должность сотрудника
    }

    public class Person
    {
        public string Person_ID { get; set; } // код контактного лица
        public string Person_FIO { get; set; } //ФИО контактного лица
        public string Person_Position { get; set; } // должность контактного лица
        public string Comp_ID { get; set; } // код компании
    }

    public class Contact
    {
        public string Date { get; set; } // дата проведения встречи

        public List<Person> PersonList { get; set; } // участники встречи от компании-клиента
        public List<Employee> EmployeeList { get; set; } // участники встречи- сотрудники
        public List<Equipment> Contact_EquipmentList { get; set; } //оборудование, обсуждавшееся на встрече
    }

    public class Equipment
    {
        public string Equipment_ID { get; set; } // код оборудования
        public string Equipment_Name { get; set; } //наименование оборудования
        public string Equipment_Type{ get; set; } //тип оборудования
    }
    
}
