using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dnc.Api.Throttle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NETCORE.Dnc.Api.Throttle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Route("Geth")]
        // GET api/values
        [HttpGet]
        //[RateValve(Policy = Policy.Ip, Limit = 2, Duration = 30)]//以上特性代表给Get接口添加一个速率阀门，指定每个IP，30秒内最多调用10次该接口。
        [RateValve(Policy = Policy.UserIdentity, Limit = 1, Duration = 30)]
        public ActionResult<IEnumerable<string>> Geth()
        {
            return Ok("ok");
        }

        /// <summary>
        /// Api限流管理服务
        /// </summary>
        private readonly IApiThrottleService _service;

        public ValuesController(IApiThrottleService service)
        {
            _service = service;
        }

        [HttpPost]
        [BlackListValve(Policy = Policy.Ip)]
        [Route("AddBlackList")]
        public async Task AddBlackList()
        {
            var ip = GetIpAddress(HttpContext);
            //添加IP黑名单
            await _service.AddRosterAsync(RosterType.BlackList,
                "WebApiTest.Controllers.ValuesController.AddBlackList",
                Policy.Ip, null, TimeSpan.FromSeconds(60), ip);
        }

        /// <summary>
        /// 取得客户端IP地址
        /// </summary>
        private static string GetIpAddress(HttpContext context)
        {
            var ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ip))
            {
                ip = context.Connection.RemoteIpAddress.ToString();
            }
            return ip;

        }
    }
}
