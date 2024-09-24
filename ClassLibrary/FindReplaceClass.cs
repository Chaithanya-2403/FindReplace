using CsvHelper;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class FindReplaceClass
    {

        public static List<FindReplace> ReadFindReplacePairs(string csvFilePath)
        {
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return new List<FindReplace>(csv.GetRecords<FindReplace>());
            }
        }

        public static void ProcessTextFile(string textFilePath, List<FindReplace> findReplaceList)
        {
            var lines = File.ReadAllLines(textFilePath);
            var updatedLines = new List<string>();

            for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
            {
                string line = lines[lineIndex];
                string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int wordIndex = 0; wordIndex < words.Length; wordIndex++)
                {
                    string word = words[wordIndex];

                    // Find and Replace if needed
                    foreach (var findReplace in findReplaceList)
                    {
                        if (word.Equals(findReplace.Find, StringComparison.OrdinalIgnoreCase))
                        {
                            word = findReplace.Replace;
                        }
                    }

                    // Replace word in line
                    words[wordIndex] = word;

                    // Find word's start position (index) in the line
                    int wordPosition = line.IndexOf(words[wordIndex]);

                    Console.WriteLine($"Word: '{word}' | Line: {lineIndex + 1}, Position: {wordPosition}");
                }

                // Rebuild the modified line
                updatedLines.Add(string.Join(' ', words));
            }

            // Write updated content back to the file
            File.WriteAllText(textFilePath, string.Join("\n", updatedLines));
            Console.WriteLine($"\nThe file '{textFilePath}' has been updated with the replaced text.");

        }
    }
}
