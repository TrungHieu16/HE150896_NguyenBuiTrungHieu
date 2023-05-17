using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(Products p) => ProductDAO.DeleteProduct(p);
        

        public List<Category> GetCategories() => CategoryDAO.GetCategories();
       

        public List<Products> GetProducts() => ProductDAO.GetProducts();
        

        public Products GetProductsById(int id) => ProductDAO.FindProductById(id);


        public void SaveProduct(Products p) => ProductDAO.SaveProduct(p);
       

        public void UpdateProduct(Products p) => ProductDAO.UpdateProduct(p);
        
    }
}
