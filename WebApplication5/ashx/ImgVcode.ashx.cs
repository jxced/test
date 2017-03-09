using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Text;
using System.Web.SessionState;

namespace WebApplication5.ashx
{
    /// <summary>
    /// ImgVcode 的摘要说明
    /// </summary>
    public class ImgVcode : IHttpHandler,IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            using (Image img = new Bitmap(55, 25))
            {
                using (Graphics gra = Graphics.FromImage(img))
                {
                    gra.Clear(Color.DarkSeaGreen);
                    string s = Getstring(4);
                    context.Session["vcode"] = s.ToString().ToLower();
                    gra.DrawString(s, new Font("宋体",18, FontStyle.Strikeout),new SolidBrush(Color.DarkRed),new PointF(1,1));
                    gra.DrawLines(Pens.AliceBlue, new PointF[] {
                        new PointF(0,8),
                        new PointF(50,10),
                        new PointF(0,20),
                        new PointF(50,16)
                    });
                    
                }
                img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
            }
            
        }
        private string Getstring(int count)
        {
            Random r = new Random();
            string[] s = {"a","b","c","d","e","h","g","2","3","4","5", "A", "B", "C", "D", "E", "F", "G", "6", "7", "9", "y","k" };
            System.Text.StringBuilder sb = new System.Text.StringBuilder(count);
            for (int i = 0; i < count; i++)
            {
                sb .Append(s[r.Next(s.Length - 1)]);
            }
            return sb.ToString();
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