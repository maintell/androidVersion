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
            if (args.Length == 1) {
                CurrentPath = args[0].TrimEnd('/').TrimEnd('\\') +  "\\AndroidManifest.xml";
            }

            if (File.Exists(CurrentPath))
            {
                Console.WriteLine("Current work On: " + CurrentPath);
                String Content = File.ReadAllText(CurrentPath);
                if (Content.IndexOf("android:versionCode=") != -1) {
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
                Console.WriteLine("File content: >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine(Content);
                File.WriteAllText(CurrentPath, Content);
            }
            else {
                Console.WriteLine("File NOT exist:" + CurrentPath);
            }
        }
    }
}
