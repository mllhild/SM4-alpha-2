using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class ErrorLogger
{
    public static void LogErrorInFile(string errorText)
    {
        string pathDir = Application.streamingAssetsPath;
        PrintLog(Path.Combine(pathDir, "ErrorLog.xml"), errorText, true);
    }
    private static void PrintLog(string path, string log, bool append)
    {
        StreamWriter tw = new StreamWriter(path, append);
        tw.WriteLine(DateTime.Now.ToString("u"));
        tw.WriteLine(log);
        tw.Close();
    }

}
