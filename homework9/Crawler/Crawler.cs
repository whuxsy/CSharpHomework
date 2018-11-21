using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Crawler
{
    class Crawler
    {
        
        private Hashtable urls = new Hashtable();
        private int count = 0;
        
   

        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();
            string startUrl1 = "http://www.cnblogs.com/dstang2000/";
            string startUrl2 = "https://www.cnblogs.com/dstang2000/archive/";

            myCrawler.urls.Add(startUrl1, false);
            myCrawler.urls.Add(startUrl2, false);
            Parallel.Invoke(new Action[] {
                ()=>myCrawler.Crawl(),
                ()=>myCrawler.Crawl()
            });
        }

        private void Crawl()
        {
            Console.WriteLine($"爬虫{Thread.CurrentThread.ManagedThreadId}开始爬行了...");
            while (true)
            {
                string current = null;
                
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;//已经下载过的不再下载
                    current = url;
                    urls[current] = true;
                    break;
                }

                if (current == null || count > 50)
                    break;              
                Console.WriteLine($"爬虫{Thread.CurrentThread.ManagedThreadId}爬行" + current + "页面");
                string html = DownLoad(current);
                Parse(html);
                
            }
            Console.WriteLine($"爬虫{Thread.CurrentThread.ManagedThreadId}爬行结束");
        }

        /// <summary>
        /// 下载html
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = (count++).ToString() + ".html";
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void Parse(string html)
        {
            try
            {
                string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
                MatchCollection matches = new Regex(strRef).Matches(html);
                foreach (Match match in matches)
                {
                    strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', ' ', '>');
                    if (strRef.Length == 0) continue;
                    if (urls[strRef] == null) urls[strRef] = false;
                }
            }
            catch (Exception e)
            {
                return;
            }
        }
    }
}
