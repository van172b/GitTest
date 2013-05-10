using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace Organics.Models
{
    public class ProductModels
    {
        public int ID { get; set; }
        public string name { get; set; }
        [AllowHtml]
        public string description { get; set; }
        public DateTime addDate { get; set; }
        public DateTime updatedDate { get; set; }
        public Decimal price { get; set; }

        /*public ProductModels()
        {
            addDate = DateTime.Now;

        }*/
    }
}