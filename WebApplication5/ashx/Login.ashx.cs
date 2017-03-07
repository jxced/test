using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Security.Cryptography;//加密

namespace WebApplication5.ashx
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            d
            Model.Users u = new Model.Users();
            u.Name = context.Request.Form["name"];
            u.Pwd = context.Request.Form["pwd"];
            string vcode = context.Request.Form["vcode"].ToLower();
            HttpSessionState s = context.Session;
            string httpMethod = context.Request.HttpMethod.ToLower();
            if (httpMethod == "post")
            {
                if (context.Session["vcode"].ToString()==vcode)
                {
                    if (u.Name == "admin" && u.Pwd == "123")
                    {
                        GetPostState(u, vcode, s);
                        Model.Users us = s[u.Name] as Model.Users;
                        System.Text.StringBuilder sb = new System.Text.StringBuilder(200);
                        context.Response.Write("欢迎" + us.Name + "登陆");
                    }
                }
                else
                {
                    context.Response.Write("<script>alert('验证码错误');window.location='/index.html'</script>");
                    //context.Response.Redirect("/index.html");
                }
                
            }
        }

        private void GetPostState(Model.Users u,string vcode, HttpSessionState s)
        {
            //HttpContext.Current.Session
            s.Add(u.Name, u);
            s.Add("vcode", vcode);
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