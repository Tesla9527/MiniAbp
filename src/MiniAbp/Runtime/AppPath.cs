﻿using System;
using System.IO;
using System.Text.RegularExpressions;

namespace MiniAbp.Runtime
{
    public class AppPath
    {
        public static string RootPath => AppDomain.CurrentDomain.BaseDirectory;
        public static string ConvertFormatConnection(string path)
        {
            const string pathDirectory = "DataDirectory";
            if (path.Contains(pathDirectory))
            {
                var rx = new Regex(@"(\|\s*DataDirectory\s*\|)");
                var matchs = rx.Match(path);
                if (matchs.Groups.Count > 1)
                {
                    var rt = matchs.Groups[1].Value;
                    path = path.Replace(rt, GetAppDataPath());
                }
                return path;
            }
            else
            {
                return path;
            }
        }

        public static string GetAppDataPath()
        {
            string p = RootPath;
            if (p.IndexOf("\\bin\\", StringComparison.Ordinal) > 0)
            {
                if (p.EndsWith("\\bin\\Debug\\"))
                    p = p.Replace("\\bin\\Debug", "");
                if (p.EndsWith("\\bin\\Release\\"))
                    p = p.Replace("\\bin\\Release", "");
            }
            if (!p.EndsWith("App_Data\\")) p = p + "App_Data\\";
            return p;
        }

        /// <summary>
        /// Get directory, if not exist then create.
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static string GetDir(string directory)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            return directory;
        }

        /// <summary>
        /// Get relevant directory, if not exist then create.
        /// </summary>
        /// <param name="relevantDir"></param>
        /// <returns></returns>
        public static string GetRelativeDir(string relevantDir)
        {
            var dir = RootPath + relevantDir;
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return dir;
        }
    }
}