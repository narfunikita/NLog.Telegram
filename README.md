NLog.Telegram
==========
An NLog target for Telegram

Usage
=====
1. Create a TelegramBot(https://core.telegram.org/bots#3-how-do-i-create-a-bot).
2. Configure NLog to use `NLog.Telegram`:

### NLog.config

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">

  <extensions>
    <add assembly="NLog.Telegram" />
  </extensions>

  <targets async="true">
    <target xsi:type="Telegram"
            name ="telegramTarget"
			layout="${message}"
            botToken ="xxx"
            chatId="xxx" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="telegramTarget" />
  </rules>
</nlog>
```


### Configuration Options

Key        | Description
----------:| -----------
BotToken    | Your telegram bot token (e.g 123456:ABC-DEF1234ghIkl-zyx57W2v1u123ew11)
ChatId   | Unique identifier for the message recipient — User or GroupChat id
BaseUrl | Optional. Api bot Url. Default: https://api.telegram.org/bot