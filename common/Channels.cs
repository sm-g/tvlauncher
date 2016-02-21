using System;

namespace tvlauncher.common
{
    public static class Channels
    {
        public static Channel[] channels = 
        {
            new Channel("1", "Первый канал", "1kanal_h.stream", "first"),
            new Channel("2", "Россия 1", "rossia1.stream", "rossia1"),    
            new Channel("3", "РЕН ТВ", "rentv4.stream", "ren"),
            new Channel("4", "НТВ", "ntv.stream", "ntv"),
            new Channel("5", "Россия 2", "rtr2.stream", "rossia2"),            
            new Channel("6", "Россия 24", "rik.stream", "rossia24"),
            new Channel("7", "Домашний", "home.stream", "domashniy"),
            new Channel("8", "Звезда", "zvezda.stream", "zvezda"),
            new Channel("9", "СТС", "sts_h.stream", "sts"),
            new Channel("10", "Дом кино", "domkino.stream", "domkino"),
            new Channel("11", "Спорт 1", "sport1_h.stream", "sport1"),
            new Channel("12", "Discovery", "discovery.stream", "discovery")
        };

        public static bool IsAvailableChannel(string channel)
        {
            int ch;
            return Int32.TryParse(channel, out ch) && ch > 0 && ch <= channels.Length;
        }
    }

    public class Channel
    {
        public string Title;
        public string Name;
        public string IconName;
        public string StreamName;

        public Channel(string name, string title, string stream, string iconName)
        {
            Title = title;
            Name = name;
            IconName = iconName;
            StreamName = stream;
        }

        public static bool operator ==(Channel a, Channel b)
        {
            if (Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.GetHashCode() == b.GetHashCode();
        }

        public static bool operator !=(Channel a, Channel b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode() ^ Name.GetHashCode();
        }

        public override bool Equals(Object o)
        {
            if (o == null || GetType() != o.GetType())
                return false;
            Channel ch = (Channel)o;
            return (Title == ch.Title) && (Name == ch.Name);
        }
    }
}
