using MVCWebAPIDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCWebAPIDemo.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly ProdDbContext context;

        public ProductsController()
        {
            context = new ProdDbContext();
        }

        //GET /api/products
        public IEnumerable<Product> GetProducts()
        {
            var products = context.Products.ToList();
            return products;
        }

        //GET /api/products/id
        public Product GetDetails(int id)
        {
            var product = context.Products.SingleOrDefault(p => p.ProductId == id);
            return product;
        }

        //POST /api/products
        //data  should be sent from the url as querystring when [FormUri] attribute is used
        //data shoudl be sent from the request body when [FromBody] attribute is used
        public Product Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                 throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                context.Products.Add(product);
                context.SaveChanges();
                return product;
            }
        }

        //PUT /api/products
        public Product Put(Product product, int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var modProduct = context.Products.SingleOrDefault(p => p.ProductId == id);

                modProduct.Name = product.Name;
                modProduct.Price = product.Price;
                modProduct.Quantiy = product.Quantiy;

                context.SaveChanges();
                return modProduct;

            }
        }

        //DELETE /api/products/id
        public Product Delete(int id)
        {
            var delProduct = context.Products.SingleOrDefault(p => p.ProductId == id);
            context.Products.Remove(delProduct);
            context.SaveChanges();
            return delProduct;
        }
    }
}
