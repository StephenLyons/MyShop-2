using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MySHop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategoryList;

        public ProductCategoryRepository()
        {
            productCategoryList = cache["productCatogories"] as List<ProductCategory>;
            if (productCategoryList == null)
            {
                productCategoryList = new List<ProductCategory>();
            }

        }

        public void Commit()
        {
            cache["productCatogories"] = productCategoryList;
        }

        public void Insert(ProductCategory p)
        {
            productCategoryList.Add(p);
        }

        public void Update(ProductCategory p)
        {
            ProductCategory productCategoryToUpdate = productCategoryList.Find(x => x.Id == p.Id);

            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = p;
            }
            else
            {
                throw new Exception("Product Category not Found");
            }
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory productToFind = productCategoryList.Find(x => x.Id == Id);

            if (productToFind != null)
            {
                return productToFind;
            }
            else
            {
                throw new Exception("Product not Found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCategoryList.AsQueryable();
        }

        public void DeleteProductCategory(string Id)
        {
            ProductCategory productCategoryToDelete = productCategoryList.Find(x => x.Id == Id);

            if (productCategoryToDelete != null)
            {
                productCategoryList.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("Product Category not Found");
            }
        }
    }
}
