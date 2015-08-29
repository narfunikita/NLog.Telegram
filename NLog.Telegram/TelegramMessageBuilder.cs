using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NLog.Telegram
{
    public class TelegramMessageBuilder
    {
        private readonly string _baseUrl;

        private readonly TelegramClient _client;

        private readonly MessageRequest _request;

        /// <summary>
        /// telegram text restriction
        /// </summary>
        private readonly static int MaxTextLength = 4096;

        public TelegramMessageBuilder(string baseUrl, string text)
        {
            this._baseUrl = baseUrl;
            this._client = new TelegramClient();
            this._request = new MessageRequest() { Text = text };
        }

        public static TelegramMessageBuilder Build(string baseUrl, string text)
        {
            return new TelegramMessageBuilder(baseUrl, text);
        }

        public TelegramMessageBuilder OnError(Action<Exception> error)
        {
            this._client.Error += error;

            return this;
        }

        public TelegramMessageBuilder ToChat(string chatId)
        {
            _request.ChatId = chatId;
            return this;
        }

        public void Send()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("chat_id", _request.ChatId);
            dic.Add("text", _request.Text == null ? null : _request.Text.Substring(0, MaxTextLength));
            var array = dic
                .Select(x => string.Format("{0}={1}", HttpUtility.UrlEncode(x.Key), HttpUtility.UrlEncode(x.Value)))
                .ToArray();

            var url = this._baseUrl + "?" + string.Join("&", array);

            this._client.Send(url);
        }
    }
}