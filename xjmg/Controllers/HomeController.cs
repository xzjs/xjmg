using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xjmg.Models;

namespace xjmg.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        //首页
        public ActionResult Index()
        {
            var data = new List<ProductCategory>()
            {
                new ProductCategory(){Id=1,Name="文具"},
                new ProductCategory(){Id=2,Name="礼品"},
                new ProductCategory(){Id=3,Name="书籍"},
                new ProductCategory(){Id=4,Name="美劳用品"}
            };
            return View(data);
        }

        //商品列表
        public ActionResult ProductList(int id)
        {
            var productCategory = new ProductCategory()
            {
                Id = id,
                Name = "类别" + id
            };

            var data = new List<Product>()
            {
                new Product()
                {
                    Id=1,
                    ProductCategory=productCategory,
                    Name="原子笔",
                    Description="N/A",
                    Price=30,
                    PublishOn=DateTime.Now,
                    Color=Color.Black
                },
                new Product
                {
                    Id=1,
                    ProductCategory=productCategory,
                    Name="铅笔",
                    Description="N/A",
                    Price=5,
                    PublishOn=DateTime.Now,
                    Color=Color.Black
                }
            };
            return View(data);
        }

        //商品明细
        public ActionResult ProductDatail(int id)
        {
            var productCategory = new ProductCategory()
            {
                Id = 1,
                Name = "文具"
            };

            var data = new Product()
            {
                Id = id,
                ProductCategory = productCategory,
                Name = "商品" + id,
                Description = "N/A",
                Price = 30,
                PublishOn = DateTime.Now,
                Color = Color.Black
            };

            return View(data);
        }
    }
}
