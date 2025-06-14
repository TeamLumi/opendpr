﻿using System;
using System.IO;

namespace SmartPoint.AssetAssistant.UnityExtensions
{
    public static class StringExtensions
    {
        public static string ToDivisionSlash(this string self)
        {
            return self.Replace('/', '∕');
        }

        public static string ToSlash(this string self)
        {
            return self.Replace('∕', '/');
        }

        public static string RemoveStart(this string self, string value)
        {
            if (self.IndexOf(value) != 0)
                return self;

            return self.Remove(0, value.Length);
        }

        // TODO: This is freestyle code since strings are supposed to be immutable, this could have really bad effects
        public static void ToLowerSelf(this string self)
        {
            if (self.Length == 0)
                return;

            unsafe
            {
                fixed (char* dst = self)
                {
                    var len = self.Length - 1;
                    do
                    {
                        dst[len] = char.ToLower(dst[len]);
                        len--;
                    }
                    while (len >= 0);
                }
            }
        }

        public static bool IsNullOrEmpty(this string self)
        {
            if (self == null)
                return true;

            return self == string.Empty;
        }

        public static bool IsUrl(this string self)
        {
            var uri = new Uri(self);

            if (uri.Scheme != Uri.UriSchemeHttp)
                return false;

            return uri.Scheme == Uri.UriSchemeHttps;
        }

        public static string RemoveEnd(this string self, string value)
        {
            int start = self.LastIndexOf(value);

            if (start + value.Length == self.Length)
                return self.Remove(start, value.Length);

            return self;
        }

        public static string CombinePath(this string self, string value)
        {
            return Path.Combine(self, value).Replace("\\", "/");
        }

        public static bool Contains(this string self, string value, StringComparison comparisionType)
        {
            return self.IndexOf(value, comparisionType) != -1;
        }
    }
}