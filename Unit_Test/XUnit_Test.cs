using ClassLibrary;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Unit_Test
{
    public class XUnit_Test
    {
        private readonly string _inputFilePath = "D:/input.txt";  // Replace your input file path
        private readonly string _csvFilePath = "D:/output.csv";  // Replace your output file path

        [Fact]
        public void TestProcessAndReplaceTextFile_WordsReplacedCorrectly()
        {
            // Arrange
            var inputContent = "she is my manager, she asked me to complete the work by the evening";
            File.WriteAllText(_inputFilePath, inputContent);

            var csvContent = "Find,Replace\nshe,he";
            File.WriteAllText(_csvFilePath, csvContent);

            var expectedOutput = "he is my manager, he asked me to complete the work by the evening";

            // Act
            var findReplaceList = FindReplaceClass.ReadFindReplacePairs(_csvFilePath);
            FindReplaceClass.ProcessTextFile(_inputFilePath, findReplaceList);

            // Assert
            var modifiedContent = File.ReadAllText(_inputFilePath);
            Assert.Equal(expectedOutput, modifiedContent);
        }

        [Fact]
        public void TestReadFindReplacePairs_ReturnsCorrectList()
        {
            // Arrange
            var csvContent = "Find,Replace\nshe,he";
            File.WriteAllText(_csvFilePath, csvContent);

            // Act
            var findReplaceList = FindReplaceClass.ReadFindReplacePairs(_csvFilePath);

            // Assert
            Assert.Equal(1, findReplaceList.Count);
            Assert.Equal("she", findReplaceList[0].Find);
            Assert.Equal("he", findReplaceList[0].Replace);
        }

        [Theory]
        [MemberData(nameof(Fixtures.TestData), MemberType = typeof(Fixtures))]
        public void TestProcessAndReplaceTextFile_WordsReplacedCorrectly_withMemberData(Fixtures fixtures)
        {
            // Arrange
            bool isMatched = false;
            File.WriteAllText(_inputFilePath, fixtures.inputContent);

            File.WriteAllText(_csvFilePath, fixtures.csvContent);
            // Act
            var findReplaceList = FindReplaceClass.ReadFindReplacePairs(_csvFilePath);
            FindReplaceClass.ProcessTextFile(_inputFilePath, findReplaceList);

            // Assert
            var modifiedContent = File.ReadAllText(_inputFilePath);
            if(fixtures.ExpectedOutput == modifiedContent)
            {
                isMatched = true;
                Assert.True(isMatched);
            }
            else
            {
                Assert.False(isMatched);
            }
        }

        [Theory]
        [MemberData(nameof(FindReplaceFixtures.TestData), MemberType = typeof(FindReplaceFixtures))]
        public void TestReadFindReplacePairs_withMemberData(FindReplaceFixtures fixtures)
        {
            bool isCorrect = false;
            // Arrange
            File.WriteAllText(_csvFilePath, fixtures.csvContent);

            // Act
            var findReplaceList = FindReplaceClass.ReadFindReplacePairs(_csvFilePath);

            // Assert
            if(findReplaceList.Count == fixtures.Count && findReplaceList[0].Find == fixtures.Find && findReplaceList[0].Replace == fixtures.Replace)
            {
                isCorrect = true;
                Assert.True(isCorrect);
            }
            else
            {
                Assert.False(isCorrect);
            }
        }
    }
}