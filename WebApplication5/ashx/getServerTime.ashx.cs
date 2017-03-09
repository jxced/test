using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.ashx
{
    /// <summary>
    /// getServerTime 的摘要说明
    /// </summary>
    public class getServerTime : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string dateTime=DateTime.Now.ToString();
            context.Response.Write(dateTime);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}