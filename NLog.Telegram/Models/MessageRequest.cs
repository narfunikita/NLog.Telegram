using System.Runtime.Serialization;

namespace NLog.Telegram
{
    [DataContract]
    public class MessageRequest
    {
        [DataMember(Name = "chat_id")]
        public string ChatId { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "disable_web_page_preview")]
        public string DisableWebPagePreview { get; set; }

        [DataMember(Name = "reply_to_message_id")]
        public int? ReplyToMessageId { get; set; }
    }
}
