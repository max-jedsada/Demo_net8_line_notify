using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace Demo_net8_line_notify.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LineNotiController : ControllerBase
    {
        private readonly ILogger<LineNotiController> _logger;

        public LineNotiController(ILogger<LineNotiController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "SendLineNoti")]
        public string SendLineNoti()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("https://notify-api.line.me/api/notify");
                var postData = string.Format("message={0}", "Test send msg.");
                var data = Encoding.UTF8.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.Headers.Add("Authorization", "Bearer " + "90Ftko1sPasdasdasdasdasdasdasdasdasdasd");

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return "OK มั้ง";
        }
    }
}
