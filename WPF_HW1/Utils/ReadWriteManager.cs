using System;
using System.IO;

namespace WPF_HW1.Utils
{
    class ReadWriteManager
    {

        private static void CheckingCreateFile(string foldername, string filename, string fileExtension)
        {
            if (!Directory.Exists(foldername)){
                Directory.CreateDirectory(foldername);
            }
            string path = Path.Combine(foldername,
             filename + fileExtension);
            if (!File.Exists(path)){
                File.Create(path).Close();
            }
        }

        public static void WriteToFile(string foldername, string filename, string fileExtension, string text)
        {
            StreamWriter writer = null;
            FileStream file = null;
            try
            {
                CheckingCreateFile(foldername, filename, fileExtension);

                file = new FileStream(Path.Combine(foldername,
             filename + fileExtension), FileMode.Append);
                writer = new StreamWriter(file);
                writer.WriteLine(text);
            }
            catch
            {
            }
            finally
            {
                writer?.Close();
                file?.Close();
                writer = null;
                file = null;
            }
        }

        public static string ReadFromFile(string foldername, string filename, string fileExtension)
        {
            if (!Directory.Exists(foldername))
                return "";
            string path = Path.Combine(foldername,
             filename + fileExtension);
            if (!File.Exists(path))
                return Guid.NewGuid().ToString();
            return File.ReadAllText(path);
        }

        public static void DeleteFile(string foldername, string filename, string fileExtension){
            string path = Path.Combine(foldername,
                filename + fileExtension);
            File.Delete(path);

        }
    }
}
