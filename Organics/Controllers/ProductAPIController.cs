using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Organics.Models;
using System.Collections;
using System.Data;
using System.Data.Entity;

namespace Organics.Controllers
{
    public class ProductAPIController : ApiController
    {
        private OrganicsDBContext db = new OrganicsDBContext();
        // GET api/productapi
        public IEnumerable<Models.ProductModels> Get()
        {
            return db.Products.ToList();
        }

        // GET api/productapi/5
        public Models.ProductModels Get(int id)
        {
            Models.ProductModels productmodel = db.Products.Find(id);
            /*if (productmodel == null)
            {
                return HttpNotFound();
            }*/
            return productmodel;
        }

        // POST api/productapi
        public Models.ProductModels Post([FromBody]Models.ProductModels value)
        {
            
            if (ModelState.IsValid)
            {
                db.Products.Add(value);
                db.SaveChanges();
            }
            return value;
            //ToDo: decide whether to send CU through post or just C.
            //ToDo: how to protect this method
            //ToDo: how should this be tested
        }

        // PUT api/productapi/5
        public void Put(int id, [FromBody]Models.ProductModels value)
        {
            if (ModelState.IsValid)
            {
                //ProductModels pm = db.Products.Find(id);
                db.Entry(value).State = EntityState.Modified;
                db.SaveChanges();
            }
         
        }

        // DELETE api/productapi/5
        public void Delete(int id)
        {
            ProductModels productmodels = db.Products.Find(id);
            if (productmodels != null)
            {
                db.Entry(productmodels).State = EntityState.Deleted;
                db.SaveChanges();
                
            }
           
        }
    }
}
