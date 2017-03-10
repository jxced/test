using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.Web.Script.Serialization;

namespace WebApplication5.ashx
{
    /// <summary>
    /// selected 的摘要说明
    /// </summary>
    public class selected : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            List<Users> u = new List<Users>()
            {
                new Users()
                {
                     Name="zhangsan",
                     Pwd="123"
                },
                new Users()
                {
                    Name="lisi",
                    Pwd="369"
                },
                new Users()
                {
                    Name="wangwu",
                    Pwd="258"
                }
            };
            JavaScriptSerializer jsoner = new JavaScriptSerializer();//创建json序列化器
            string jsonStr = jsoner.Serialize(u); //把对象序列化成json字符串
            context.Response.Write(jsonStr);
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