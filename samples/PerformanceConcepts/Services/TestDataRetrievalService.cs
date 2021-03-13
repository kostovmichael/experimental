namespace PatternsAndConcepts.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    /// <summary>
    /// This is to be used for testing purposes ONLY! Not intended for production release
    /// </summary>
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

        public static string[] GetCommonWordsTestData(string filePath = null)
        {
            return GetTestDataStringArrayFromFile(filePath, "commonWords.txt", newLineSeparator);
        }
        public static string[] GetMThesaurStringArray()
        {
            return GetTestDataStringArrayFromFile("mthesaur.txt", new char[] { ',' });
        }


        public static string[] GetTestDataStringArrayFromFile(string fileName, char[] separator)
        {
            return GetTestDataStringArrayFromFile(null, fileName, separator);
        }


        public static string[] GetTestDataStringArrayFromFile(string pathToFile, string fileName, char[] separator)
        {
            if (pathToFile == null)
            {
                pathToFile = GetAppDataDirectoryPath();
            }
            string fileFullPath = Path.Combine(pathToFile, fileName);
            string fileRawText = System.IO.File.ReadAllText(fileFullPath);
            string[] arrayOfStrings = fileRawText.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            return arrayOfStrings;
        }

        public static string GetTestStringDataFromFile(string fileName)
        {
            string fileFullPath = Path.Combine(GetAppDataDirectoryPath(), fileName);
            return System.IO.File.ReadAllText(fileFullPath);
        }

        public static List<string> GetTestStreamDataFromFile(string fileName)
        {
            string fileFullPath = Path.Combine(GetAppDataDirectoryPath(), fileName);

            List<string> listOfStringsChunks = new List<string>(2600000);
            using (var streamReader = System.IO.File.OpenText(fileFullPath))
            {
                string line1 = string.Empty;
                while ((line1 = streamReader.ReadLine()) != null)
                {
                    listOfStringsChunks.AddRange(line1.Split(','));
                }
            }
            return listOfStringsChunks;
        }
    }
}
