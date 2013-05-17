using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Organics.Models
{
    public class ProductDTOModel
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime addDate { get; set; }
        public DateTime updatedDate { get; set; }
        public Decimal price { get; set; }
    }
}