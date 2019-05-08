using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NewLife.Agent;

namespace NETCORE.WindowsService
{
    public class Program
    {

        static string[] _args;

        public static void Main(string[] args)
        {
            _args = args;

            TestAgentServices.ServiceMain();

            //CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();


        public class TestAgentServices : AgentServiceBase<TestAgentServices>
        {
            #region 属性

            /// <summary>显示名</summary>
            public override string DisplayName => "Agent测试服务";

            /// <summary>描述</summary>
            public override string Description => "Agent测试服务的描述信息！";
            #endregion

            #region 构造函数
            /// <summary>实例化一个代理服务</summary>
            public TestAgentServices()
            {
                // 一般在构造函数里面指定服务名
                ServiceName = "TestAgent";
            }
            #endregion

            #region 执行任务
            protected override void StartWork(string reason)
            {

                CreateWebHostBuilder(_args).Build().Run();
                WriteLog("当前时间{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                base.StartWork(reason);
            }
            #endregion
        }

    }



}
