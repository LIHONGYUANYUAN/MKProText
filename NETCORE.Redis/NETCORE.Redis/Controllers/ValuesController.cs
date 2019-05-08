using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NETCORE.Redis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
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
