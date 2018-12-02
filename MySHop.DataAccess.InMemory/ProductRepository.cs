using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MySHop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> productsList;

        public ProductRepository()
        {
            productsList = cache["products"] as List<Product>;
            if (productsList == null)
            {
                productsList = new List<Product>();
            }
          
        }

        public void Commit()
        {
            cache["products"] = productsList;
        }

        public void Insert(Product p)
        {
            productsList.Add(p);
        }

        public void Update(Product p)
        {
            Product productToUpdate = productsList.Find(x => x.Id == p.Id);

            if (productToUpdate != null)
            {
                productToUpdate = p;
            }
            else
            {
                throw new Exception("Product not Found");
            }
        }

        public Product Find(string Id)
        {
            Product productToFind = productsList.Find(x => x.Id == Id);

            if (productToFind != null)
            {
                return productToFind;
            }
            else
            {
                throw new Exception("Product not Found");
            }
        }

        public IQueryable<Product> Collection()
        {
            return productsList.AsQueryable();
        }

        public void DeleteProduct(string Id)
        {
            Product productToDelete = productsList.Find(x => x.Id == Id);

            if (productToDelete != null)
            {
                productsList.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not Found");
            }
        }
}
}
