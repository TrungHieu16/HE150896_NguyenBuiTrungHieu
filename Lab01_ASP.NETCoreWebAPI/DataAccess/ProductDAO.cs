using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        public static List<Products> GetProducts() 
        {
            var listProducts = new List<Products>();
            try
            {
                using (var context = new MyDBContext())
                {
                    listProducts = context.Products.ToList(); 
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listProducts;
        }

        public static Products FindProductById(int prodId)
        {
            Products p = new Products();
            try
            {
                using (var context = new MyDBContext())
                {
                    p = context.Products.SingleOrDefault(x=> x.ProductId == prodId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }
        public static void SaveProduct(Products p)
        {
            try
            {
                using (var context = new MyDBContext())
                {
                    context.Products.Add(p);
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateProduct(Products p)
        {
            try
            {
                using (var context = new MyDBContext())
                {
                    context.Entry<Products>(p).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteProduct(Products p)
        {
            try
            {
                using (var context = new MyDBContext())
                {
                    var p1 = context.Products.SingleOrDefault(c => c.ProductId == p.ProductId);
                    context.Products.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
