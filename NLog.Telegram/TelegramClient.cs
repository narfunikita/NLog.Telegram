using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NLog.Telegram
{
    public class TelegramClient
    {
        public event Action<Exception> Error;

        public void Send(string url)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.UploadStringAsync(new Uri(url), "GET");
                }
            }
            catch (Exception e)
            {
                this.OnError(e);
            }
        }

        private void OnError(Exception obj)
        {
            if (this.Error != null)
                this.Error(obj);
        }
    }
}