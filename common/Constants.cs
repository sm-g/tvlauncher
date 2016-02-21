using System;

namespace tvlauncher.common
{
    public static class Constants
    {
        #region Settings

        public const string serverHost = "192.168.0.1";
        public const int serverPort = 8002;

        public const string tvHost = "192.168.0.1";
        public const int tvPort = 8001;
        public readonly static string tvUri = "http://" + tvHost + ":" + tvPort;

        public const int bufferLength = 256;
        public const int pingTimeOutMilliseconds = 1000;

        public readonly static string vlcExePath = Environment.MachineName == "MAIN" ? "L:\\Program Files\\vlc-2.0.3\\vlc.exe" : "C:\\Program Files\\vlc-2.0.3\\vlc.exe";
        public readonly static string vlcFolderPath = Environment.MachineName == "MAIN" ? "L:\\Program Files\\vlc-2.0.3" : "C:\\Program Files\\vlc-2.0.3";

        public const string rtmpdumpPath = "\"L:\\Program Files\\rtmpdump-2.3\\rtmpdump.exe\"";
        public const string rtmpdumpArgumentsBeginning = " --rtmp \"rtmp://fms.hutor.ru\" --app \"tv/\" --swfUrl \"http://tv.hutor.ru/player-licensed.swf\" --tcUrl \"rtmp://fms.hutor.ru/tv/\" --playpath \"";
        public readonly static string rtmpdumpArgumentsEnding = "\" --quiet | \"" + vlcExePath + "\" --qt-start-minimized --no-qt-system-tray --sout=\"#std{access=http,mux=asf,dst=" + tvHost + ":" + tvPort + "}\" -";
        #endregion

        #region UI

        public const string uiClientConnecting = "Подключение к серверу...";
        public readonly static string uiClientConnected = " подключено." + Environment.NewLine + "Выберите канал.";
        public const string uiClientStopped = "Остановлено. Причина: ";
        public const string uiClientStoppedAgain = "Уже остановлено. Новая причина: ";
        public const string uiClientRequestChannel = "Переключение на канал № ";

        public const string uiServerGreeting = "Сервер работает.";
        public const string uiServerDontKnow = " - неизвестная команда.";
        public const string uiServerStopping = "Сервер остановлен.";

        public const string uiLauncherFormTitleClientNotConnected = "Выбор каналов — не подключен";
        public const string uiLauncherFormTitleClientConnected = "Выбор каналов";
        public const string uiLauncherShowOutput = "Лог";
        public const string uiLauncherHideOutput = "Скрыть лог";
        public const string uiLauncherClientConnected = "Подключился к серверу";
        public const string uiLauncherClientLaunched = "Ожидаю сигнал...";
        public const string uiLauncherRecievingStarted = "Канал показывает";
        public const string uiLauncherRecievingFailed = "Канал не показывает";
        public const int uiLauncherChannelButtonMinWidth = 100;
        public const int uiLauncherChannelButtonMinHeight = 70;
        public const int uiLauncherChannelButtonMarginAll = 3;
        public readonly static int uiLauncherChannelsPanelMinWidth = uiLauncherChannelButtonMinWidth + System.Windows.Forms.SystemInformation.VerticalScrollBarWidth + uiLauncherChannelButtonMarginAll * 2;

        public const string uiBroadcasterCloseMenu = "Закрыть";
        public const string uiBroadcasterClosingConnected = "Подключенный клиент перестанет работать";
        public const string uiBroadcasterClosingNotConnected = "Клиентов нет";

        public const int uiPlayerShowControlsMargin = 200;
        public const string uiPlayerStatePlaying = "Показывает";
        public const string uiPlayerStateStopped = "Остановлен";
        public const string uiPlayerStatePaused = "Пауза";
        public const string uiPlayerStateNotCreated = "Неактивен";
        #endregion
    }

}
