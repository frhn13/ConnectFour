using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConnectFour
{
    class Files
    {
        private static readonly string rootPath = AppDomain.CurrentDomain.BaseDirectory;
        private static String fileName = "Winners.txt";

        public static void WriteToFile(String name)
        {
            File.AppendAllText(fileName, name+"\n");
        }

        public static List<String> ReadFromFile()
        {
            List<String> winners = new List<String>();
            String winner;
            StreamReader readFile = null;
            try
            {
                readFile = new StreamReader(Path.Combine(rootPath, fileName));
                do
                {
                    winner = readFile.ReadLine();
                    winners.Add(winner);
                } while (winner != null);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("No winners yet.");
            }
            finally
            {
                readFile.Close();
            }
            return winners;
        }
    }
}
