using Polly;
using System;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;

namespace NETCORE.POLLY
{
    class Program
    {
        static void Main(string[] args)
        {
            Policy
         // 1. 指定要处理什么异常
         .Handle<HttpRequestException>()
         //    或者指定需要处理什么样的错误返回
         .OrResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.BadGateway)
         // 2. 指定重试次数和重试策略
         .Retry(3, (exception, retryCount, context) =>
         {
             Console.WriteLine($"开始第 {retryCount} 次重试：");
         })

         // 3. 执行具体任务
         .Execute(ExecuteMockRequest);

            Policy.Handle<COMException>()
    .CircuitBreaker(2, TimeSpan.FromMinutes(1));

            Policy.Timeout(30, onTimeout: (context, timespan, task) =>
            {
                // do something
            });
             

            Console.WriteLine("程序结束，按任意键退出。");
            Console.ReadKey();
        }



        static HttpResponseMessage ExecuteMockRequest()
        {
            // 模拟网络请求
            Console.WriteLine("正在执行网络请求...");
            Thread.Sleep(3000);
            // 模拟网络错误
            return new HttpResponseMessage(HttpStatusCode.BadGateway);
        }

    }
}
