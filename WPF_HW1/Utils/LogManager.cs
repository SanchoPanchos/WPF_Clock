using System;
using System.IO;
using WPF_HW1.Utils;

namespace WPF_HW1
{
    static class LogManager
    {
        public static void Log(string message)
        {
            ReadWriteManager.WriteToFile(Constants.ClientLogDirPath, "Logs " + DateTime.Now.ToString(Constants.DateFormat), ".txt", 
                DateTime.Now.ToString(Constants.TimeFormat) + "   " + message);
        }

    }
}