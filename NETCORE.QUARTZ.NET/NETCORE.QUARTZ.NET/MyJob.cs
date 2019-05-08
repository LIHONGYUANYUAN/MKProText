using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETCORE.QUARTZ.NET
{
    public class MyJob : IJob//创建IJob的实现类，并实现Excute方法。
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Users\lihongyuan\Desktop\error.log", true, Encoding.UTF8))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));
                }
            });
        }
    }

}
