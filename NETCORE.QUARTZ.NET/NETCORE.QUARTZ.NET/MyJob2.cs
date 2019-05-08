using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETCORE.QUARTZ.NET
{
    public class MyJob2 : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            var jobData = context.JobDetail.JobDataMap;//获取Job中的参数

            var triggerData = context.Trigger.JobDataMap;//获取Trigger中的参数

            var data = context.MergedJobDataMap;//获取Job和Trigger中合并的参数

            var value1 = jobData.GetInt("key1");
            var value2 = jobData.GetString("key2");

            var dateString = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"); return Task.Run(() =>
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Users\lihongyuan\Desktop\error2.log", true, Encoding.UTF8))
                {
                    sw.WriteLine(dateString);
                }
            });
        }
    }
}
