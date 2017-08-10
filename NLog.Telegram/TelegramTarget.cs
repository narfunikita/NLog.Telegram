using NLog.Common;
using NLog.Config;
using NLog.Targets;
using System;

namespace NLog.Telegram
{
    [Target("Telegram")]
    public class TelegramTarget : TargetWithLayout
    {
        public TelegramTarget()
        {
            BaseUrl = "https://api.telegram.org/bot";
        }

        public string BaseUrl { get; set; }

        [RequiredParameter]
        public string BotToken { get; set; }

        [RequiredParameter]
        public string ChatId { get; set; }

        protected override void InitializeTarget()
        {
            if (String.IsNullOrWhiteSpace(BotToken))
                throw new ArgumentOutOfRangeException("BotToken", "BotToken cannot be empty.");

            if (String.IsNullOrWhiteSpace(ChatId))
                throw new ArgumentOutOfRangeException("ChatId", "ChatId cannot be empty.");

            base.InitializeTarget();
        }

        protected override void Write(AsyncLogEventInfo info)
        {
            try
            {
                Send(info);
            }
            catch (Exception e)
            {
                info.Continuation(e);
            }
        }

        private void Send(AsyncLogEventInfo info)
        {
            var message = Layout.Render(info.LogEvent);

            var uriBuilder = new UriBuilder(BaseUrl + BotToken);
            uriBuilder.Path += "/sendMessage";

            var url = uriBuilder.Uri.ToString();

            var builder = TelegramMessageBuilder
                .Build(url, message)
                .ToChat(ChatId)
                .OnError(e => info.Continuation(e));

            builder.Send();
        }
    }
}