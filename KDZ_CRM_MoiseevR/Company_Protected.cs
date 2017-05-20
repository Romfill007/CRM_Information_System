using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_CRM_MoiseevR
{
    class Company_Protected
    {
        public int Comp_id { get; set; }
        public int Comp_id_region { get; set; }
        public int Comp_id_owner { get; set; } //форма собственности
        public int Comp_id_business_area { get; set; } //сфера деятельности
        public int Comp_id_segment { get; set; } //сегмент сфферы деятельности
        public int Comp_id_city { get; set; }
        public string Comp_adress { get; set; }
        public string Comp_name { get; set; }
        public string Comp_website { get; set; }
        public string Comp_email { get; set; }
        public int Comp_start_year { get; set; } //год начала работы компании
        public int Comp_inn { get; set; } //индивидуальный номер налогоплательщика
        public int Comp_employee_amount { get; set; }
        public double Comp_revenue { get; set; }
        public int Comp_zip_code { get; set; } //почтовый идекс
        public int Comp_id__client_category { get; set; }
        public string Comp_founders { get; set; }
        public int Comp_contact_telephone { get; set; }
        public string Comp_additional_info { get; set; }
    }
}
