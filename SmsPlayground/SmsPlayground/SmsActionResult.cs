using System;
using System.Net.Http;

namespace SmsPlayground
{
    public class SmsActionResult
    {
        public bool IsSuccessfull { get; set; }

        public static SmsActionResult FromHttpResponse(HttpResponseMessage response)
        {
            return new SmsActionResult
            {
                IsSuccessfull = response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK,
            };
        }
    }
}