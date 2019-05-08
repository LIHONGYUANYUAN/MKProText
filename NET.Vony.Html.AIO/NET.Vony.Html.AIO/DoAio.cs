using Ivony.Html;
using Ivony.Html.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NET.Vony.Html.AIO
{
    public class DoAio
    {
        //一、抓取页面图片
        //1.拿到所有图片页面的地址
        //本次爬取的网站为https://www.mntup.com/，打开页面进入二级目录https://www.mntup.com/SiWa.html,并查页面看源代码，如下图：

        //    图片页都在class=“dana”的div下面,我们要拿去div中超链接的href，如下格式：
        //    <div class="dana"><a href =/ Rosimm / liantiyimeizi_4f4d781d.html title=[Rosi写真] NO.2637_红色吊带高叉连体衣妹子床上狗爬式秀浑圆翘臀撩人诱惑写真38P target = _blank >
        //     [Rosi写真]NO.2637_红色吊带高叉连体衣妹子床上狗爬式秀浑圆翘臀撩人诱惑写真38P<b> <font color = ff0000 > 2019 - 02 - 26 </ b ></ font >
        //    </ a ></ div >
        //首先考虑要拿到所有图片页面的超链接


        //需要定义一个list用来存放所有的页面链接
        static List<string> categoryUrl = new List<string>();

        string address = "https://www.mntup.com";

        string addressFile = "https://www.mntup.com/XiuRen.html";

        //加载url到文档
        IHtmlDocument source = null;

        public DoAio()
        {
            source = new JumonyParser().LoadDocument(addressFile, System.Text.Encoding.GetEncoding("utf-8"));
        }


        public void Grasp()
        {
            //获取所有class=dana的的a标签
            var divLinks = source.Find(".dana a");
            foreach (var aLink in divLinks)
            {
                var categoryName = aLink.Attribute("href").Value(); //获取a中的链接
                categoryUrl.Add(categoryName);
            }


            foreach (var url in categoryUrl)
            {
                //获取图片也的的文档
                IHtmlDocument html = new JumonyParser().LoadDocument($"{address}{url}", System.Text.Encoding.GetEncoding("utf-8"));

                //获取每个分页面并下载
                var pageLink = html.Find(".page a");
                foreach (var alingk in pageLink)
                {
                    string href = alingk.Attribute("href").Value();
                    Console.WriteLine($"获取分页地址{address}{href}");


                    //获取每一个分页的文档模型
                    IHtmlDocument htm2 = new JumonyParser().LoadDocument($"{address}{href}", System.Text.Encoding.GetEncoding("utf-8"));

                    //获取class=img的div下的img标签
                    var aLink = htm2.Find(".img img");

                    foreach (var link in aLink)
                    {
                        var imgsrc = link.Attribute("src").Value();
                        Console.WriteLine("获取到图片路径" + imgsrc);
                        Console.WriteLine($"开始下载图片{imgsrc}>>>>>>>");
                        DownLoadImg(new Image { Address = address + imgsrc, Title = url });

                    }
                }
            }
        }



        /// <summary>
        /// 异不下载图片
        /// </summary>
        /// <param name="image"></param>
        async static void DownLoadImg(Image image)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    int start = image.Address.LastIndexOf("/") + 1;

                    string fileName = image.Address.Substring(start, image.Address.Length - start);
                    //图片目录采用页面地址作为文件名
                    string directory = "f:/images/" + image.Title.Replace("/", "-").Replace("html", "") + "/";
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    await client.DownloadFileTaskAsync(new Uri(image.Address), directory + fileName);
                }
                catch (Exception)
                {
                    Console.WriteLine($"{image.Address}下载失败");
                    File.AppendText(@"f:/images/log.txt");
                }
                Console.WriteLine($"{image.Address}下载成功");
            }

        }


    }
}
