using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProxyApp.Services
{
    /// <summary>
    /// This class help us to read data from specific file
    /// </summary>
    public class FileHelper
    {
        private static string FileName = @"../../Files\Words.txt";
        /// <summary>
        ///  This function get data from Specific file 
        ///  if data not found returns null
        /// </summary>
        /// <returns></returns>
        public static string[] GetAllData()
        {
            if (File.Exists(FileName))
            {
                var text = File.ReadAllText(FileName);
                var data = text.Split('\n');
                return data;
            }
            return null;
        }

        public static void AppendTextToFile(string text)
        {
            if (File.Exists(FileName))
            {
                File.AppendAllText(FileName, $"{text}\n");
            }
        }
    }
}
