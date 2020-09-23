using System;
using System.IO;
using System.Text.RegularExpressions;

namespace androidVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            string CurrentPath = Environment.CurrentDirectory + "\\AndroidManifest.xml";
            string CurrentPathCordova = Environment.CurrentDirectory + "\\config.xml";
            if (args.Length == 1) {
                CurrentPath = args[0].TrimEnd('/').TrimEnd('\\') +  "\\AndroidManifest.xml";
                CurrentPathCordova = args[0].TrimEnd('/').TrimEnd('\\') + "\\config.xml";
            }

            if (File.Exists(CurrentPathCordova))
            {
                Console.WriteLine("Currently work On Cordova File: \n" + CurrentPathCordova);
                String Content = File.ReadAllText(CurrentPathCordova);
                if (Content.IndexOf("android-versionCode=") != -1)
                {
                    Regex regex = new Regex("android-versionCode=\".*?\"");
                    Match match = regex.Match(Content);
                    string matchValue = match.Value;
                    string newVersionCode = "android-versionCode=\"" +
                        now.Year.ToString().Substring(2, 2) +
                        now.Month.ToString("00") +
                        now.Day.ToString("00") +
                        now.Hour.ToString("00") +
                        now.Minute.ToString("00") + "\"";
                    Content = Content.Replace(matchValue, newVersionCode);
                    Console.WriteLine("versionCode: " + matchValue + "\t\t>>>>>>>>>>>>>>>>\t" + newVersionCode);
                }
                if (Content.IndexOf("version=\"") != -1)
                {
                    Regex regex = new Regex("version=\".*?\"");
                    Match match = regex.Match(Content);
                    string matchValue = match.Value;
                    string newversionName = "version=\"" +
                        now.Year.ToString() + "." +
                        now.Month.ToString("00") +
                        now.Day.ToString("00") + "." +
                        now.Hour.ToString("00") +
                        now.Minute.ToString("00") + "\"";
                    Content = Content.Replace(matchValue, newversionName);
                    Console.WriteLine("version:\t     " + matchValue + "\t\t>>>>>>>>>>>>>>>>\t        " + newversionName);
                }
                File.WriteAllText(CurrentPathCordova, Content);
            }
            else
            {
                Console.WriteLine("Cordova Config file NOT exist:" + CurrentPathCordova);
            }

            if (File.Exists(CurrentPath))
            {
                Console.WriteLine("Current work On: \n" + CurrentPath);
                String Content = File.ReadAllText(CurrentPath);
                if (Content.IndexOf("android:versionCode=") != -1)
                {
                    Regex regex = new Regex("android:versionCode=\".*?\"");
                    Match match = regex.Match(Content);
                    string matchValue = match.Value;
                    string newVersionCode = "android:versionCode=\"" +
                        now.Year.ToString().Substring(2, 2) +
                        now.Month.ToString("00") +
                        now.Day.ToString("00") +
                        now.Hour.ToString("00") +
                        now.Minute.ToString("00") + "\"";
                    Content = Content.Replace(matchValue, newVersionCode);
                    Console.WriteLine("versionCode: " + matchValue + "\t\t>>>>>>>>>>>>>>>>\t" + newVersionCode);
                }
                if (Content.IndexOf("android:versionName=") != -1)
                {
                    Regex regex = new Regex("android:versionName=\".*?\"");
                    Match match = regex.Match(Content);
                    string matchValue = match.Value;
                    string newversionName = "android:versionName=\"" +
                        now.Year.ToString() + "." +
                        now.Month.ToString("00") +
                        now.Day.ToString("00") + "." +
                        now.Hour.ToString("00") +
                        now.Minute.ToString("00") + "\"";
                    Content = Content.Replace(matchValue, newversionName);
                    Console.WriteLine("versionName: " + matchValue + "\t>>>>>>>>>>>>>>>>\t" + newversionName);
                }
                //Console.WriteLine("File content: >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                //Console.WriteLine(Content);
                File.WriteAllText(CurrentPath, Content);
            }
            else
            {
                Console.WriteLine("Android File NOT exist:" + CurrentPath);
            }
        }
    }
}
