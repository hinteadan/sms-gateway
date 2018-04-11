using System.Threading.Tasks;
using System.Net.Http;
using System;

namespace SmsPlayground
{
    public class SmsGateway : IDisposable
    {
        private const string baseUrl = "http://smsgateway.me/api/v3/messages";
        private const string deviceId = "86013";
        private readonly string username;
        private readonly string password;
        private readonly HttpClient http = new HttpClient();

        protected bool isDisposed = false;

        public SmsGateway(string username = "hintea_dan@yahoo.co.uk", string password = "123qwe")
        {
            this.username = username;
            this.password = password;
        }

        ~SmsGateway()
        {
            Dispose(false);
        }

        public async Task<SmsActionResult> SendMessage(string phoneNumber, string message)
        {
            Uri url = new Uri($"{baseUrl}/send?email={username}&password={password}&device={deviceId}&number={phoneNumber}&message={message}");

            HttpResponseMessage response = await http.PostAsync(url, new StringContent(string.Empty, System.Text.Encoding.UTF8, "application/json"));

            return SmsActionResult.FromHttpResponse(response);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposed) return;

            if (isDisposing)
            {
                // free managed resources
                http.Dispose();
            }
            // free native resources if there are any.
        }
    }
}
