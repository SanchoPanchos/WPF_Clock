using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_HW1.Model
{
    class StaticFunctions
    {
        public static void saveUser(string email)
        {
            // Create a string array with the lines of text
            string[] lines = { "First line", "Second line", "Third line" };

            // Set a variable to the My Documents path.
            string mydocpath =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(mydocpath + @"\WriteLines.txt"))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }
        }

        public static string EmailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        public static List<string> TimeZones()
        {
            List<string> TimeZones = new List<string>();
            TimeZones.Add("UTC-11");
            TimeZones.Add("UTC-10");
            TimeZones.Add("UTC-9");
            TimeZones.Add("UTC-8");
            TimeZones.Add("UTC-7");
            TimeZones.Add("UTC-6");
            TimeZones.Add("UTC-5");
            TimeZones.Add("UTC-4");
            TimeZones.Add("UTC-3");
            TimeZones.Add("UTC-2");
            TimeZones.Add("UTC-1");
            TimeZones.Add("UTC+0");
            TimeZones.Add("UTC+1");
            TimeZones.Add("UTC+2");
            TimeZones.Add("UTC+3");
            TimeZones.Add("UTC+4");
            TimeZones.Add("UTC+5");
            TimeZones.Add("UTC+6");
            TimeZones.Add("UTC+7");
            TimeZones.Add("UTC+8");
            TimeZones.Add("UTC+9");
            TimeZones.Add("UTC+10");
            TimeZones.Add("UTC+11");
            TimeZones.Add("UTC+12");
            return TimeZones;
        }
    }
}
