using System;
using System.IO;
using System.Collections.Generic;

namespace SpaceCatGamesDevTool.Services
{
    public static class Logger
    {
        private static readonly string LogFile = "devtool.log";
        private static readonly object lockObj = new object();

        public static void Log(string message)
        {
            lock (lockObj)
            {
                File.AppendAllText(LogFile, $"[{DateTime.Now}] {message}\n");
            }
        }

        public static List<string> GetLastEntries(int count)
        {
            if (!File.Exists(LogFile)) return new List<string>();
            var lines = File.ReadAllLines(LogFile);
            int skip = Math.Max(0, lines.Length - count);
            return new List<string>(lines).GetRange(skip, lines.Length - skip);
        }
    }
}
