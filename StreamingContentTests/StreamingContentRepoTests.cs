using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StreamingContentLibrary;

namespace StreamingContentTests
{
    [TestClass]
    public class StreamingContentRepoTests
    {
        //TestInitialize
        private StreamingContent _content;
        private StreamingContentRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
            //All of the code that we are running in every arrange
            //Creating a Content and a Repository
            _content = new StreamingContent("Titanic", "Boat with small doors", 7.5, MaturityRating.PG_13, 500);
            _repo = new StreamingContentRepository();

            //Adding Content to repository
            _repo.AddContentToRepository(_content);
        }

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
        [TestMethod]
        public void GetAllContent_ShouldReturnCorrectList()
        {
            //Arrange
            StreamingContent content = new StreamingContent();
            StreamingContentRepository repo = new StreamingContentRepository();
            StreamingContent book = new StreamingContent();
            repo.AddContentToRepository(content);
            repo.AddContentToRepository(book);

            //Act
            List<StreamingContent> result = repo.GetContents();

            //Assert
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(book));
        }
        
        //GetContentByTitle
        [TestMethod]
        public void GetContentByTitle_ShouldReturnCorrectContent()
        {
            //Arrange
            StreamingContent content = new StreamingContent();
            StreamingContent jaws = new StreamingContent("Jaws", "Shark Movie", 7.8, MaturityRating.PG_13, 99);
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
        [TestMethod]
        public void DeleteContent_ShouldRemoveContent()
        {
            //Arrange
            //Handled by the TestInitialize

            //Act
            bool result = _repo.DeleteExistingContent(_content);

            //Assert
            Assert.IsTrue(result);

            //Secondary assertion option
            List<StreamingContent> resultList = _repo.GetContents();

            Assert.IsFalse(resultList.Contains(_content));
        }

    }
}