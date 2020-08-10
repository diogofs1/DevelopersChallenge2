using System;
using System.IO;
using System.Text;

namespace Concilia
{
    public static class ConciliaExtrato
    {
        public static void ConciliarExtrato(string targetDirectory)
        {
            string newFile = @"./OfxFiles/ExtratoConciliado.ofx";

            if (string.IsNullOrEmpty(targetDirectory))
            {
                throw new ArgumentException($"'{nameof(targetDirectory)}' cannot be null or empty", nameof(targetDirectory));
            }

            // Check if file already exists. If yes, delete it.     
            if (File.Exists(newFile))
            {
                File.Delete(newFile);
            }

            // Create a new file     
            // using FileStream fs = File.Create(newFile);
                            
            
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                // Open the file to read from.
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        byte[] conteudo = new UTF8Encoding(true).GetBytes(fileName);
                        using StreamWriter sw = File.AppendText(newFile);
                        sw.WriteLine(s);
                    }
                }
            }
        }
    }
}
