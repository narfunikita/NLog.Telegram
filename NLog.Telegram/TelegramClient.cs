using System;
using System.IO;
using System.Net;

namespace NLog.Telegram
{
    public class TelegramClient
    {
        public event Action<Exception> Error;

        public void Send(string url)
        {
            var str = string.Empty;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);

                using (var response = (HttpWebResponse)request.GetResponse())
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    str = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                OnError(e);
            }
        }

        private void OnError(Exception obj)
        {
            if (Error != null)
                Error(obj);
        }
    }
}