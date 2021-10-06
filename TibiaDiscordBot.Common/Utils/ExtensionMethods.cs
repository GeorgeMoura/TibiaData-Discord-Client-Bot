using System;

namespace TibiaDiscordBot.Common.Utils
{
    public static class ExtensionMethods
    {
        public static string TruncateLongString(this string str, int initial, int maxLength)
        {
            if (string.IsNullOrEmpty(str)) return str;

            int strLeftLength = str.Length - initial;

            return str.Substring(initial, Math.Min(strLeftLength, maxLength));
        }
    }
}
