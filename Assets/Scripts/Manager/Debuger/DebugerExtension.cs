using System;
using System.Diagnostics;
using System.Reflection;

public static class DebugerExtension
{
    [Conditional("EnableLog")]
    public static void Log(this object obj, string message)
    {
        bool flag = !Debuger.EnableLog;
        if (!flag)
        {
            Debuger.Log(DebugerExtension.GetLogTag(obj), message);
        }

    }

    public static void LogError(this object obj, string message)
    {
        Debuger.LogError(DebugerExtension.GetLogTag(obj), message);
    }

    public static void LogWarning(this object obj, string message)
    {
        Debuger.LogWarning(DebugerExtension.GetLogTag(obj), message);
    }

    [Conditional("EnableLog")]
    public static void Log(this object obj, string format, params object[] args)
    {
        bool flag = !Debuger.EnableLog;
        if (!flag)
        {
            string message = string.Format(format, args);
            Debuger.Log(DebugerExtension.GetLogTag(obj), message);
        }
    }

    public static void LogError(this object obj, string format, params object[] args)
    {
        string message = string.Format(format, args);
        Debuger.LogError(DebugerExtension.GetLogTag(obj), message);
    }

    public static void LogWarning(this object obj, string format, params object[] args)
    {
        string message = string.Format(format, args);
        Debuger.LogWarning(DebugerExtension.GetLogTag(obj), message);
    }

    private static string GetLogTag(object obj)
    {
        FieldInfo field = obj.GetType().GetField("LOG_TAG");
        bool flag = field != null;
        string result;
        if (flag)
        {
            result = (string)field.GetValue(obj);
        }
        else
        {
            result = obj.GetType().Name;
        }
        return result;
    }
}