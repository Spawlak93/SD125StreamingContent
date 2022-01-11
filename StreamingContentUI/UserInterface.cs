using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreamingContentLibrary;

namespace StreamingContentUI
{
    public class UserInterface
    {
        //This is where I define how my User Interface runs
        private readonly StreamingContentRepository _repo = new StreamingContentRepository();
        //Run method dictates what runs
        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        private void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine(
                    "Enter the number of your menu selection:\n" +
                    "1. Show all streaming content \n" +
                    "2. Find content by title\n" +
                    "3. Add new Content\n" +
                    "4. Update Content \n" +
                    "5. Remove Content \n" +
                    "6. Exit"
                );

                string userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        DisplayAllContent();
                        break;

                    case "2":
                        DisplayByTitle();
                        break;

                    case "3":
                    case "Add":
                        AddNewContent();
                        break;

                    case "4":
                        //TODO Update Content
                        break;

                    case "5":
                        RemoveExistingContent();
                        break;

                    case "6":
                        //EXIT
                        Console.WriteLine("Goodbye");
                        isRunning = false;
                        break;

                    default:
                        //What to do with invalid input
                        break;
                }
            }
        }

        //Display All Method
        private void DisplayAllContent()
        {
            Console.Clear();

            List<StreamingContent> listOfContent = _repo.GetContents();

            foreach (StreamingContent content in listOfContent)
            {
                PrintContent(content);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }



        //Display By Title
        private void DisplayByTitle()
        {
            Console.Clear();

            Console.WriteLine("What Title are you looking for?");

            string targetTitle = Console.ReadLine();

            StreamingContent content = _repo.GetContentByTitle(targetTitle);

            if (content != null)
            {
                //Content is found
                PrintContent(content);
            }
            else
            {
                //Content is not found
                Console.WriteLine("Title not found");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        //Add New
        private void AddNewContent()
        {
            Console.Clear();

            StreamingContent content = new StreamingContent();

            Console.WriteLine("Enter the title: ");
            content.Title = Console.ReadLine();

            Console.WriteLine("Enter a Description:");
            content.Description = Console.ReadLine();

            //Star Rating
            Console.WriteLine("Enter the star rating:");
            content.StarRating = double.Parse(Console.ReadLine());

            //Maturity Rating
            Console.WriteLine(
                "Select a Maturity Rating: \n" +
                "1: G" +
                "2. PG \n" +
                "3. PG-13 \n" +
                "4. R \n" +
                "5. NC-17 \n"
            );
            string maturityResponse = Console.ReadLine();
            switch (maturityResponse)
            {
                case "1":
                    content.MaturityRating = MaturityRating.G;
                    break;

                case "2":
                    content.MaturityRating = MaturityRating.PG;
                    break;

                case "3":
                    content.MaturityRating = MaturityRating.PG_13;
                    break;

                case "4":
                    content.MaturityRating = MaturityRating.R;
                    break;

                case "5":
                    content.MaturityRating = MaturityRating.NC17;
                    break;

            }

            //Runtime in Minutes
            Console.WriteLine("Enter the runtime in minutes:");
            content.RunTimeInMinutes = int.Parse(Console.ReadLine());

            _repo.AddContentToRepository(content);
            //Add confirmation that content was added.
        }

        //Update Existing Content
        private void UpdateExistingContent()
        {
            //Select What Content to Update
            //Asking for Title, or from list

            //Get Content to update it with
            //Perhaps look at how we created it inititally

            //Repo Update method
        }

        //Delete Content
        private void RemoveExistingContent()
        {
            Console.Clear();

            //Listing all content and letting user pick one
            Console.WriteLine("Select the Title you want to remove:");

            List<StreamingContent> contentList = _repo.GetContents();
            int counter = 1;

            foreach (StreamingContent content in contentList)
            {
                Console.WriteLine(counter + ". " + content.Title);
                counter++;
            }

            int contentSelection = int.Parse(Console.ReadLine());
            int targetIndex = contentSelection - 1;

            //check for valid selection
            if (targetIndex >= 0 && targetIndex < contentList.Count)
            {
                StreamingContent targetContent = contentList[targetIndex];

                if(_repo.DeleteExistingContent(targetContent))
                {
                    //Code for success
                    Console.WriteLine($"{targetContent.Title} was removed");
                }
                else
                {
                    Console.WriteLine("Something went wrong");
                }
            }
            else
            {
                //Invalid Selection
                Console.WriteLine("Invalid Selection");
            }

            //Potentially replace with helper method
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        //Seed Method
        private void SeedContent()
        {
            StreamingContent alien = new StreamingContent("Alien", "Deep Space Sci-Fi Horror", 8.4, MaturityRating.R, 99);
            StreamingContent theTrumanShow = new StreamingContent("The Truman Show", "The Real Reality TV", 9.3, MaturityRating.PG, 122);
            StreamingContent insideOut = new StreamingContent("Inside Out", "Do you ever look at someone and wonder \"What is going on inside their head?\"", 8.7, MaturityRating.G, 133);

            _repo.AddContentToRepository(alien);
            _repo.AddContentToRepository(theTrumanShow);
            _repo.AddContentToRepository(insideOut);
        }

        //Helper method
        private void PrintContent(StreamingContent content)
        {
            Console.WriteLine(
                                $"Title: {content.Title} \n" +
                                $"Description: {content.Description} \n" +
                                $"Stars: {content.StarRating} \n" +
                                $"Maturity Rating: {content.MaturityRating} \n" +
                                $"Family Friendly: {content.IsFamilyFriendly} \n" +
                                $"Runtime In Minutes: {content.RunTimeInMinutes}\n\n"
                                );
        }
    }
}