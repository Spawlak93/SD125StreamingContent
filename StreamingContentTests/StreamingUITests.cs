using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StreamingContentUI;
using StreamingContentUI.Consoles;

namespace StreamingContentTests
{
    [TestClass]
    public class StreamingUITests
    {
        [TestMethod]
        public void GetList_OutputShouldContainListOfContent()
        {
            //AAA
            //Arrange
            //Need to input 1 and 6
            List<string> inputList = new List<string> { "1", "6" };
            MockConsole console = new MockConsole(inputList);
            UserInterface ui = new UserInterface(console);

            //Act
            ui.Run();

            //Assert
            bool result = console.Output.Contains("The Real Reality TV");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateNew_OutputShouldContainAddedInformation()
        {   
            //Arrange
            //3 title description starRating maturityRating Runtime 1 6
            string customDescription = "A custom Descrption";

            List<string> inputList = new List<string> { "3", "Title", customDescription, "9.2", "3", "123", "1", "6" };
            MockConsole console = new MockConsole(inputList);
            UserInterface ui = new UserInterface(console);

            //Act
            ui.Run();

            //Assert
            Assert.IsTrue(console.Output.Contains(customDescription));
        }

        //Get By Title
        
    }
}