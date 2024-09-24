using ClassLibrary;

namespace ConsoleAppforFindReplace
{
    public class Program
    {
        static void Main(string[] args)
        {
            // File paths
            Console.Write("Enter the input CSV file path: ");
            string textFilePath = Console.ReadLine();
            Console.Write("Enter the output TSV file path: ");
            string csvFilePath = Console.ReadLine();

            // Read the CSV file to get find-replace pairs
            var findReplaceList = FindReplaceClass.ReadFindReplacePairs(csvFilePath);

            // Process the text file
            FindReplaceClass.ProcessTextFile(textFilePath, findReplaceList);
        }
    }
}