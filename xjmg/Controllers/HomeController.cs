using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xjmg.Models;
using PagedList;

namespace xjmg.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        //首页
        public ActionResult Index()
        {
            var data = db.ProductCategories.ToList();
#if DEBUG
            //插入演示信息
            if (data.Count == 0)
            {
                db.ProductCategories.Add(new ProductCategory() { Id = 1, Name = "文具" });
                db.ProductCategories.Add(new ProductCategory() { Id = 2, Name = "礼品" });
                db.ProductCategories.Add(new ProductCategory() { Id = 3, Name = "书籍" });
                db.ProductCategories.Add(new ProductCategory() { Id = 4, Name = "美劳用具" });

                db.SaveChanges();

                data = db.ProductCategories.ToList();
            }
#endif
            return View(data);
        }

        //商品列表
        public ActionResult ProductList(int id, int p = 1)
        {
            try
            {
                var productCategory = db.ProductCategories.Find(id);

                if (productCategory != null)
                {
                    var data = productCategory.Products.ToList();

#if DEBUG
                    //插入演示信息
                    if (data.Count == 0)
                    {
                        productCategory.Products.Add(new Product()
                        {
                            Name = productCategory.Name + "类别下的商品1",
                            Description = "N/A",
                            Price = 10,
                            PublishOn = DateTime.Now,
                            ProductCategory = productCategory
                        });
                        productCategory.Products.Add(new Product()
                        {
                            Name = productCategory.Name + "类别下的商品2",
                            Description = "N/A",
                            Price = 12,
                            PublishOn = DateTime.Now,
                            ProductCategory = productCategory
                        });
                        db.SaveChanges();

                        data = productCategory.Products.ToList();
                    }
#endif
                    var pageData = data.ToPagedList(pageNumber: p, pageSize: 10);
                    return View(pageData);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            catch (DbEntityValidationException ex)
            {
                return HttpNotFound();
            }

        }

        //商品明细
        public ActionResult ProductDatail(int id)
        {
            var data = db.Products.Find(id);
            return View(data);
        }
    }
}
