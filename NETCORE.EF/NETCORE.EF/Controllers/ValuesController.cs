using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NETCORE.EF.Models;

namespace NETCORE.EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly db1Context DB;

        public ValuesController(db1Context _db)
        {
            DB = _db;
        }



        //Dapper 事务
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            using (IDbConnection connection = DB.Database.GetDbConnection())
            {
                connection.Open();

                IDbTransaction transaction = connection.BeginTransaction();
                try
                {
                    //修改
                    var list = connection.Query<TblOrder>("select * from tbl_order where order_code=@order_code", new { order_code = "119" }).ToList();

                    string str = "UPDATE tbl_order SET Text='开心开心' where order_code=@order_code";

                    connection.Execute(str, list,transaction);


                    //删除
                    list = connection.Query<TblOrder>("select * from tbl_order order by id").ToList();

                    connection.Execute("delete from tbl_order where id =@id", list.Take(2).ToList(), transaction);


                    transaction.Commit();

                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                }

            }

            return new string[] { "value1", "value2" };
        }



        //Dapper 操作
        //[HttpGet]
        public ActionResult<IEnumerable<string>> Get0()
        {

            IDbConnection connection = DB.Database.GetDbConnection();

            //查询
            var queryRes = connection.Query<TblOrder>("select * from tbl_order where amount=@amount", new { amount = "10" }).ToList();



            //新增
            List<Models.TblOrder> list = new List<TblOrder>() {new TblOrder() {  Amount = 10, Uptime= DateTime.Now, Order_Code = "119", User_Id = 2  ,Text="aaaa"},
                                                               new TblOrder() {  Amount = 10, Uptime= DateTime.Now, Order_Code = "118", User_Id = 2  ,Text="bbbbb"},
                                                               new TblOrder() {  Amount = 10, Uptime= DateTime.Now, Order_Code = "117", User_Id = 2  ,Text="ccccc"}};

            string str = "INSERT INTO tbl_order (order_code,user_id,amount,uptime,text) VALUES(@order_code,@user_id,@amount,@uptime,@text)";

            connection.Execute(str, list);


            //修改
            list = connection.Query<TblOrder>("select * from tbl_order where order_code=@order_code", new { order_code = "117" }).ToList();

            str = "UPDATE tbl_order SET Text='abcabc' where order_code=@order_code";

            connection.Execute(str, list);


            //删除
            list = connection.Query<TblOrder>("select * from tbl_order order by id").ToList();

            connection.Execute("delete from tbl_order where id =@id", list.Take(2).ToList());




            return new string[] { "value1", "value2" };
        }

        // 带事物的增删查改
        //[HttpGet]
        public ActionResult<IEnumerable<string>> Get1()
        {
            using (IDbContextTransaction transaction = DB.Database.BeginTransaction())
            {
                try
                {
                    //新增 多条
                    List<Models.TblOrder> list = new List<TblOrder>() {new TblOrder() {  Amount = 10, Uptime= DateTime.Now, Order_Code = "9", User_Id = 2  ,Text="aaaa"},
                                                               new TblOrder() {  Amount = 10, Uptime= DateTime.Now, Order_Code = "8", User_Id = 2  ,Text="bbbbb"},
                                                                new TblOrder() {  Amount = 10, Uptime= DateTime.Now, Order_Code = "7", User_Id = 2  ,Text="ccccc"}};

                    DB.TblOrder.AddRange(list);


                    DB.SaveChanges();


                    //throw new Exception();


                    List<Models.TblOrder> list2 = DB.TblOrder.Where(t => true).ToList();

                    list2.ForEach(t => { t.Text = "bkas"; });

                    DB.TblOrder.UpdateRange(list2);

                    DB.SaveChanges();


                    Trans(transaction);//事务做为参数传递。


                    //提交事务
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error occurred.");
                }
            }


            return new string[] { "value1", "value2" };

        }


        //带事务参数的方法
        private void Trans(IDbContextTransaction transaction)
        {

            //新增 多条
            List<Models.TblOrder> list = new List<TblOrder>() {new TblOrder() {  Amount = 10, Uptime= DateTime.Now, Order_Code = "213", User_Id = 2  ,Text="aaaa"},
                                                               new TblOrder() {  Amount = 10, Uptime= DateTime.Now, Order_Code = "214", User_Id = 2  ,Text="bbbbb"},
                                                                new TblOrder() {  Amount = 10, Uptime= DateTime.Now, Order_Code = "215", User_Id = 2  ,Text="ccccc"}};

            DB.TblOrder.AddRange(list);

            DB.SaveChanges();
        }





        // 增删查改
        //[HttpGet]
        public ActionResult<IEnumerable<string>> Get2()
        {
            //查询
            var queryRes1 = DB.TblOrder.Where(t => true).ToList();




            #region == 新增 数据 ==

            //新增 单条
            Models.TblOrder model = new Models.TblOrder() { Amount = 10, Uptime = DateTime.Now, Order_Code = "222222", User_Id = 2, Text = "aaaa" };

            DB.TblOrder.Add(model);

            DB.SaveChanges();


            //新增 多条
            List<Models.TblOrder> list = new List<TblOrder>() {new TblOrder() {  Amount = 10, Uptime= DateTime.Now, Order_Code = "222222", User_Id = 2  ,Text="aaaa"},
                                                               new TblOrder() {  Amount = 10, Uptime= DateTime.Now, Order_Code = "333333", User_Id = 2  ,Text="aaaa"} };

            DB.TblOrder.AddRange(list);

            DB.SaveChanges();

            #endregion


            #region == 修改 数据 ==
            //修改 单条
            model = queryRes1.First();

            model.Text = "update_" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToLongTimeString();

            DB.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //也可以

            DB.SaveChanges();


            //修改 多条
            list = queryRes1.Skip(2).Take(3).ToList();

            list.ForEach(t =>
            {

                t.Text = "update_" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToLongTimeString();

                //DB.Entry(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;


            });

            DB.SaveChanges();
            #endregion


            #region == 修改2 数据 ==

            //修改 单条
            model = queryRes1.First();

            model.Text = "update2_" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToLongTimeString();

            DB.TblOrder.Update(model);

            DB.SaveChanges();


            //修改 多条
            list = queryRes1.Skip(2).Take(3).ToList();

            list.ForEach(t =>
            {

                t.Text = "update2_" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToLongTimeString();

            });

            DB.TblOrder.UpdateRange(list);

            DB.SaveChanges();

            #endregion


            #region == 删除 数据 ==
            //删除 单条

            model = queryRes1.First();

            DB.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            DB.SaveChanges();


            //修改 多条
            list = queryRes1.Skip(2).Take(3).ToList();

            list.ForEach(t =>
            {
                DB.Entry(t).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            });

            DB.SaveChanges();

            #endregion


            #region  == 删除2 数据 ==

            queryRes1 = DB.TblOrder.Where(t => true).ToList();

            //删除 单条
            model = queryRes1.First();

            DB.TblOrder.Remove(model);

            DB.SaveChanges();


            //修改 多条
            list = queryRes1.Skip(2).Take(3).ToList();

            DB.TblOrder.RemoveRange(list);

            DB.SaveChanges();
            #endregion


            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
