using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
*    args[0]: %PATH_TO_PROJECTS_ON_PC%\third\third\test 
*    args[1]: mask(if no mask please write "null") 
*    args[2+]: phrases to search
*    Base tasks: +
*    recursive search: +
*    mask search: +
*    multi phrase search: +
*    multi search entrance variants: -
*/
namespace third
{
    internal class Program
    {
        private static ArrayList paths = new ArrayList();
        private static Dictionary<string, int> phrases = new Dictionary<string, int>();

        public static void Main(string[] args)
        {
            var path = args[0];
            string mask = args[1];
            if (mask == "null") mask = "*";

            for (int i = 2; i < args.Length; i++)
            {
                phrases.Add(args[i], 0);
            }

            ContainmentCounting(path, mask);
            foreach(KeyValuePair<string, int> phrase in phrases)
            {
                Console.WriteLine("Key = {0}, Value = {1}", phrase.Key, phrase.Value);
            }
        }
        
        private static void ContainmentCounting(string directory, string mask)
        {
            DirectoryInfo DI = new DirectoryInfo(directory);
            FileInfo[] FI = DI.GetFiles(mask);
            for (int i = 0; i < FI.Length; i++)
            {
                Console.WriteLine(FI[i].FullName);
                paths.Add(FI[i].FullName);
                string text = File.ReadAllText(FI[i].FullName);
                for (int j = 0; j < phrases.Count; j++)
                {
                    string kek = phrases.Keys.ElementAt(j); 
                    phrases[kek] += GetCountKeyInFile(text, kek);
                }
            }

            foreach (var subDirectory in Directory.EnumerateDirectories(directory))
            {
                ContainmentCounting(subDirectory, mask);
            }
        }

        private static int GetCountKeyInFile(string text, string key)
        {
            return text.Split(new string[] {key}, StringSplitOptions.None).Length - 1;
        }
    }
}