using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NET.Redis.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            RedisHelper redisHelper = new RedisHelper("127.0.0.1:6379");

            //增加
            bool r1 = redisHelper.SetValue("mykey", "abcdefg");

            //查询
            string saveValue = redisHelper.GetValue("mykey");

            //更新
            bool r2 = redisHelper.SetValue("mykey", "NewValue");

            saveValue = redisHelper.GetValue("mykey");

            //删除
            bool r3 = redisHelper.DeleteKey("mykey");

            //查询 - null 
            string uncacheValue = redisHelper.GetValue("mykey");







            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
