using System;

namespace BenchmarkNetPlayground.Services
{
    using System.IO;

    public class TestDataRetrievalService
    {

        private static string appDataDirectoryPath = null;
        private static readonly char[] newLineSeparator = new char[] { '\r', '\n' };

        public static string GetAppDataDirectoryPath()
        {
            if (appDataDirectoryPath == null)
            {
                appDataDirectoryPath = Path.Combine(
                    Environment.CurrentDirectory.Split(new String[] { "bin" },
                        StringSplitOptions.None)[0], "App_Data");
            }

            return appDataDirectoryPath;
        }

        public static string[] GetCommonWordsTestData()
        {
            return GetTestDataStringArrayFromFile("commonWords.txt", newLineSeparator);
        }
        public static string[] GetMThesaurStringArray()
        {
           return GetTestDataStringArrayFromFile("mthesaur.txt",new char[] { ',' });
        }


      public static string[] GetTestDataStringArrayFromFile(string fileName, char[] separator)
        {
            string fileFullPath = Path.Combine(GetAppDataDirectoryPath(), fileName);
            string fileRawText = System.IO.File.ReadAllText(fileFullPath);
            string[] arrayOfStrings = fileRawText.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            return arrayOfStrings;
        }
    }
}
