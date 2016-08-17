using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using Microsoft.Owin;
using Newtonsoft.Json;
using Owin;

namespace WebBalloon
{
    public class BallonNotifierStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Run(ctx =>
            {
                if (ValidateRequest(ctx.Request))
                {
                    var body = new StreamReader(ctx.Request.Body).ReadToEnd();
                    PrintTrace(body);

                    var notification = JsonConvert.DeserializeObject<Notification>(body);
                    var notifier = new BalloonNotifier();
                    notifier.Notify(notification);
                }
                else
                {
                    Console.WriteLine($"{Now}: Bad request");
                    PrintUsage();
                    ctx.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                }
                
                return ctx.Response.WriteAsync("");
            });
        }

        private static bool ValidateRequest(IOwinRequest req)
        {
            return req.Method == HttpMethod.Post.ToString() && req.ContentType == "application/json";
        }

        private string Now => DateTime.Now.ToString(CultureInfo.CurrentCulture);

        private void PrintUsage()
        {
            Console.WriteLine($"{Now}: Usage: POST http://localhost:28660");
            Console.WriteLine("{ \"Title\":  \"A title\", \"Text\":  \"Some text\" }");
        }

        private void PrintTrace(string body)
        {
            Console.WriteLine($"{Now}: new request received");
            Console.WriteLine(body);
        }
    }
}