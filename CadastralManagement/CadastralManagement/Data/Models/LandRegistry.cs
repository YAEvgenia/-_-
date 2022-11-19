 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastralManagement.Data.Models
{
    public class LandRegistry//земляной кадастр
    {
        public int id { set; get; }

        public int area { set; get; }//площадь учатска

        public string address { set; get; }//адресс участка

        public DateTime approvalDate { set; get; }//дата регистрации учатска

        public string passport { set; get; }//паспортные данные владельца

        public int price { set; get; }//кадастровая стоимость

        public double taxCoefficint { set; get; }//коэффициент налогооблажения
    }
}
