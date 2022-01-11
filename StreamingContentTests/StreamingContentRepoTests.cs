using Microsoft.VisualStudio.TestTools.UnitTesting;
using StreamingContentLibrary;

namespace StreamingContentTests
{
    [TestClass]
    public class StreamingContentRepoTests
    {
        [TestMethod]
        public void TestAddToRepo_ShouldGetTrue()
        {
            //Arrange
            StreamingContent content = new StreamingContent();
            StreamingContentRepository repo = new StreamingContentRepository();
            //Act
            bool result = repo.AddContentToRepository(content);

            //Assert
            Assert.IsTrue(result);
        }

        //GetContents
        
        //GetContentByTitle
        [TestMethod]
        public void GetContentByTitle_ShouldReturnCorrectContent()
        {
            //Arrange
            StreamingContent content = new StreamingContent();
            StreamingContent jaws = new StreamingContent("Jaws", "Shark Movie", 7.8, MaturityRating.PG_13, false, 99);
            StreamingContentRepository repo = new StreamingContentRepository();
            repo.AddContentToRepository(content);
            repo.AddContentToRepository(jaws);

            //Act
            StreamingContent result = repo.GetContentByTitle("Jaws");

            //Assert
            Assert.AreEqual("Shark Movie" , result.Description);

        }

        //UpdateContent

        //DeleteContent

    }
}