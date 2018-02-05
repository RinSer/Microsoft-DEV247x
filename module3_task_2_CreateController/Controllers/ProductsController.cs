using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        // #1 GET api/products
        [HttpGet]
        public ActionResult GetAll()
        {
            if (FakeData.Products.Count > 0)
                return Ok(FakeData.Products);
            else
                return NotFound();
        }

        // #2 GET api/products/:id
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            Product product = null;
            FakeData.Products.TryGetValue(id, out product);
            if (product != null)
                return Ok(product);
            else
                return NotFound();
        }

        // #3 GET api/products/price/:from/:to
        [HttpGet("price/{from}/{to}")]
        public ActionResult GetFiltered(int from, int to)
        {
            var filteredProducts = FakeData.Products.Values
                .Where(v => v.Price >= from && v.Price <= to).ToArray();
            if (filteredProducts.Count() > 0)
                return Ok(filteredProducts);
            else
                return NotFound();
        }

        // #5 POST api/products
        [HttpPost]
        public ActionResult Post([FromBody]Product product)
        {
            int newId = FakeData.Products.Keys.Max() + 1;
            product.ID = newId;
            FakeData.Products.Add(newId, product);
            return Created($"api/products/{newId}", product);
        }

        // #6 PUT api/products/:id
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Product product)
        {
            if (FakeData.Products.ContainsKey(id))
            {
                product.ID = id;
                FakeData.Products[id] = product;
                return Ok(product);
            }
            else
                return NotFound();
        }

        // #7 PUT api/products/raise/:by
        [HttpPut("raise/{by}")]
        public ActionResult RaiseAllPrices(int by)
        {
            if (FakeData.Products.Count > 0) 
            {
                IDictionary<int, Product> updated = FakeData.Products.Values
                    .Select(v => { v.Price += by; return v; })
                    .ToDictionary(p => p.ID, p => p);
                FakeData.Products = updated;
                return Ok(FakeData.Products.Count);    
            }
            else
                return NotFound();
        }

        // #4 DELETE api/products/:id
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (FakeData.Products.ContainsKey(id)) 
            {
                FakeData.Products.Remove(id);
                return Ok(id);
            }
            return NotFound();
        }
    }
}
