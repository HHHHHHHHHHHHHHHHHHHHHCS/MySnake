using System;
using System.IO;
using UnityEngine;


public class Debuger
{
    public static bool EnableLog;

    public static bool EnableTime = true;

    public static bool EnableSave = false;

    public static bool EnableStack = false;

    public static string LogFileDir = "";

    public static string LogFileName = "";

    public static string LogFilePath
    {
        get
        {
            return LogFileDir + LogFileName;
        }
    }

    public static string Prefix = "> ";

    public static StreamWriter LogFileWriter = null;

    public static bool UseUnityEngine = true;

    private static void Internal_Log(string msg, object context = null)
    {
        bool useUnityEngine = Debuger.UseUnityEngine;
        if (useUnityEngine)
        {
            Debug.Log(msg, (UnityEngine.Object)context);
        }
        else
        {
            Console.WriteLine(msg);
        }
    }

    private static void Internal_LogWarning(string msg, object context = null)
    {
        bool useUnityEngine = Debuger.UseUnityEngine;
        if (useUnityEngine)
        {
            Debug.LogWarning(msg, (UnityEngine.Object)context);
        }
        else
        {
            Console.WriteLine(msg);
        }
    }

    private static void Internal_LogError(string msg, object context = null)
    {
        bool useUnityEngine = Debuger.UseUnityEngine;
        if (useUnityEngine)
        {
            Debug.LogError(msg, (UnityEngine.Object)context);
        }
        else
        {
            Console.WriteLine(msg);
        }
    }

    public static void Log(object message)
    {
        bool flag = !Debuger.EnableLog;
        if (!flag)
        {
            string str = Debuger.GetLogTime() + message;
            Debug.Log(Debuger.Prefix + str, null);
            Debuger.LogToFile("[I]" + str, false);
        }
    }

    public static void Log(object message, object context)
    {
        bool flag = !Debuger.EnableLog;
        if (!flag)
        {
            string str = Debuger.GetLogTime() + message;
            Debuger.Internal_Log(Debuger.Prefix + str, context);
            Debuger.LogToFile("[I]" + str, false);
        }
    }

    public static void LogError(object message)
    {
        string str = Debuger.GetLogTime() + message;
        Debuger.Internal_LogError(Debuger.Prefix + str, null);
        Debuger.LogToFile("[E]" + str, true);
    }

    public static void LogError(object message, object context)
    {
        string str = Debuger.GetLogTime() + message;
        Debuger.Internal_LogError(Debuger.Prefix + str, context);
        Debuger.LogToFile("[E]" + str, true);
    }

    public static void LogWarning(object message)
    {
        string str = Debuger.GetLogTime() + message;
        Debuger.Internal_LogWarning(Debuger.Prefix + str, null);
        Debuger.LogToFile("[W]" + str, false);
    }

    public static void LogWarning(object message, object context)
    {
        string str = Debuger.GetLogTime() + message;
        Debuger.Internal_LogWarning(Debuger.Prefix + str, context);
        Debuger.LogToFile("[W]" + str, false);
    }

    public static void Log(string tag, string message)
    {
        bool flag = !Debuger.EnableLog;
        if (!flag)
        {
            message = Debuger.GetLogText(tag, message);
            Debuger.Internal_Log(Debuger.Prefix + message, null);
            Debuger.LogToFile("[I]" + message, false);
        }
    }

    public static void Log(string tag, string format, params object[] args)
    {
        bool flag = !Debuger.EnableLog;
        if (!flag)
        {
            string logText = Debuger.GetLogText(tag, string.Format(format, args));
            Debuger.Internal_Log(Debuger.Prefix + logText, null);
            Debuger.LogToFile("[I]" + logText, false);
        }
    }

    public static void LogError(string tag, string message)
    {
        message = Debuger.GetLogText(tag, message);
        Debuger.Internal_LogError(Debuger.Prefix + message, null);
        Debuger.LogToFile("[E]" + message, true);
    }

    public static void LogError(string tag, string format, params object[] args)
    {
        string logText = Debuger.GetLogText(tag, string.Format(format, args));
        Debuger.Internal_LogError(Debuger.Prefix + logText, null);
        Debuger.LogToFile("[E]" + logText, true);
    }

    public static void LogWarning(string tag, string message)
    {
        message = Debuger.GetLogText(tag, message);
        Debuger.Internal_LogWarning(Debuger.Prefix + message, null);
        Debuger.LogToFile("[W]" + message, false);
    }

    public static void LogWarning(string tag, string format, params object[] args)
    {
        string logText = Debuger.GetLogText(tag, string.Format(format, args));
        Debuger.Internal_LogWarning(Debuger.Prefix + logText, null);
        Debuger.LogToFile("[W]" + logText, false);
    }

    private static string GetLogText(string tag, string message)
    {
        string str = "";
        bool enableTime = Debuger.EnableTime;
        if (enableTime)
        {
            str = DateTime.Now.ToString("HH:mm:ss.fff") + " ";
        }
        return str + tag + "::" + message;
    }

    private static string GetLogTime()
    {
        string result = "";
        bool enableTime = Debuger.EnableTime;
        if (enableTime)
        {
            result = DateTime.Now.ToString("HH:mm:ss.fff") + " ";
        }
        return result;
    }

    private static void LogToFile(string message, bool EnableStack = false)
    {
        bool flag = !Debuger.EnableSave;
        if (!flag)
        {
            bool flag2 = Debuger.LogFileWriter == null;
            if (flag2)
            {
                Debuger.LogFileName = DateTime.Now.GetDateTimeFormats('s')[0].ToString();
                Debuger.LogFileName = Debuger.LogFileName.Replace("-", "_");
                Debuger.LogFileName = Debuger.LogFileName.Replace(":", "_");
                Debuger.LogFileName = Debuger.LogFileName.Replace(" ", "");
                Debuger.LogFileName += ".log";
                bool flag3 = string.IsNullOrEmpty(Debuger.LogFileDir);
                if (flag3)
                {
                    try
                    {
                        bool useUnityEngine = Debuger.UseUnityEngine;
                        if (useUnityEngine)
                        {
                            Debuger.LogFileDir = Application.dataPath + "/../DebugerLog/";
                        }
                        else
                        {
                            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                            Debuger.LogFileDir = baseDirectory + "/DebugerLog/";
                        }
                    }
                    catch (Exception ex)
                    {
                        Debuger.Internal_LogError(Debuger.Prefix + "获取 Application.persistentDataPath 报错！" + ex.Message, null);
                        return;
                    }
                }
                string path = Debuger.LogFileDir + Debuger.LogFileName;
                try
                {
                    bool flag4 = !Directory.Exists(Debuger.LogFileDir);
                    if (flag4)
                    {
                        Directory.CreateDirectory(Debuger.LogFileDir);
                    }
                    Debuger.LogFileWriter = File.AppendText(path);
                    Debuger.LogFileWriter.AutoFlush = true;
                }
                catch (Exception ex2)
                {
                    Debuger.LogFileWriter = null;
                    Debuger.Internal_LogError("LogToCache() " + ex2.Message + ex2.StackTrace, null);
                    return;
                }
            }
            bool flag5 = Debuger.LogFileWriter != null;
            if (flag5)
            {
                try
                {
                    Debuger.LogFileWriter.WriteLine(message);
                    bool flag6 = (EnableStack || Debuger.EnableStack) && Debuger.UseUnityEngine;
                    if (flag6)
                    {
                        Debuger.LogFileWriter.WriteLine(StackTraceUtility.ExtractStackTrace());
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
