using Microsoft.VisualStudio.TestTools.UnitTesting;
using StreamingContentLibrary;

namespace StreamingContentTests
{
    [TestClass]
    public class StreamingObjectTests
    {
        //AAA
        //Arrange
        //Act
        //Assert
        [TestMethod]
        public void ExampleTest()
        {
            //Arrange
            int numOne = 2;
            int numTwo = 5;

            //Act
            int numThree = numOne + numTwo;

            //Assertion
            Assert.AreEqual(7, numThree);

        }

        [TestMethod]
        public void TestProperty_ShouldReturnCorrectValue()
        {
            //Arrange
            StreamingContent content = new StreamingContent();
            
            //Act
            content.Title = "Hook";

            //Assert
            Assert.AreEqual("Hook", content.Title);
        }

        [TestMethod]
        public void TestConstructor_ShouldSetCorrectValues()
        {
            //Arrange
            //Act
            StreamingContent content = new StreamingContent("Hook", "Grown up peter pan", 8, MaturityRating.PG, 123);

            //Assert
            Assert.AreEqual("Hook", content.Title);
            Assert.AreEqual(MaturityRating.PG, content.MaturityRating);
        }

        //Some users are complaining that the family filter is not working as intended.
        //Have familyFriendly rating automatically filter out content that is R or NC_17
        [TestMethod]
        public void TestIsFamilyFriendly_ShouldReturnCorrectBool()
        {
            //Arrange
            StreamingContent content = new StreamingContent();
            //Act
            content.MaturityRating = MaturityRating.G;
            //Assert
            Assert.AreEqual(true, content.IsFamilyFriendly);
        }

        
    }
}
