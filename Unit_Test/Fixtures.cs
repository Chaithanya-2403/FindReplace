using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test
{
    public class Fixtures
    {
        public string Name { get; set; }
        public string inputContent { get; set; }
        public string csvContent { get; set; }
        public string ExpectedOutput { get; set; }
        public bool ExpectedResult { get; set; }

        public static object[][] TestData = new object[][]
        {
            new object[]
            {
                new Fixtures
                {
                    Name = "Replacing the text",
                    inputContent = "she is my manager, she asked me to complete the work by the evening",
                    csvContent = "Find,Replace\nshe,he",
                    ExpectedOutput = "he is my manager, he asked me to complete the work by the evening",
                    ExpectedResult = true
                }
            },
            new object[]
            {
                new Fixtures
                {
                    Name = "Find and Replace words",
                    inputContent = "she is my manager, she asked me to complete the work by the evening",
                    csvContent = "Find,Replace\nshe,he",
                    ExpectedOutput = "he is my manager, she asked me to complete the work by the evening",
                    ExpectedResult = false
                }
            }
        };
    }

    public class FindReplaceFixtures
    {
        public string Name { get; set; }
        public string csvContent { get; set; }
        public int Count { get; set; }
        public string Find { get; set; }
        public string Replace { get; set; }
        public bool ExpectedResult { get; set; }

        public static object[][] TestData = new object[][]
        {
            new object[]
            {
                new FindReplaceFixtures
                {
                    Name = "When Find and Replace words",
                    csvContent = "Find,Replace\nshe,he",
                    Count = 1,
                    Find = "she",
                    Replace = "he",
                    ExpectedResult = true
                }
            },
            new object[]
            {
                new FindReplaceFixtures
                {
                    Name = "When Find and Replace words are wrong",
                    csvContent = "Find,Replace\nshe,he",
                    Count = 2,
                    Find = "she",
                    Replace = "he",
                    ExpectedResult = false
                }
            }
        };
    }
}
