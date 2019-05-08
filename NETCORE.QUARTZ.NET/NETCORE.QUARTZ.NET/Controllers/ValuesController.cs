using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quartz;

namespace NETCORE.QUARTZ.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private IScheduler _scheduler;
        public ValuesController(ISchedulerFactory schedulerFactory)
        {
            this._schedulerFactory = schedulerFactory;
        }



        [HttpGet]
        public async Task<string[]> Get()
        {
            //1、通过调度工厂获得调度器
            _scheduler = await _schedulerFactory.GetScheduler();
            //2、开启调度器
            await _scheduler.Start();
            //3、创建一个触发器
            var trigger = TriggerBuilder.Create()
                            .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever())//每两秒执行一次
                            .Build();
            //4、创建任务
            var jobDetail = JobBuilder.Create<MyJob>()
                            .WithIdentity("job", "group")
                            .Build();
            //5、将触发器和任务器绑定到调度器中
            await _scheduler.ScheduleJob(jobDetail, trigger);







            var trigger3 = TriggerBuilder.Create()
                       .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever())//间隔2秒 一直执行
                       .UsingJobData("key1", 321)  //通过在Trigger中添加参数值
                       .UsingJobData("key2", "123")
                       .WithIdentity("trigger2", "group1")
                       .Build();

            IJobDetail job = JobBuilder.Create<MyJob2>()
                               .UsingJobData("key1", 123)//通过Job添加参数值
                               .UsingJobData("key2", "123")
                               .WithIdentity("job1", "group1")
                               .Build();

            await _scheduler.ScheduleJob(job, trigger3);




            return await Task.FromResult(new string[] { "value1", "value2" });
        }


    }
}
