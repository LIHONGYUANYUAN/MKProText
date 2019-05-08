using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NET.EF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            DBEntities DB = new DBEntities();

            //查询
            List<tbl_order> list = DB.tbl_order.Where(t => true).ToList();

            //修改
            list.ForEach(model =>
            {
                model.user_id = 55;

                DB.Entry(model).State = System.Data.Entity.EntityState.Modified;
            });

            //删除
            DB.tbl_order.Remove(list[0]);
             
            //保存
            DB.SaveChanges();






            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}