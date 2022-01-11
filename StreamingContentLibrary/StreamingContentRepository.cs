using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingContentLibrary
{
    public class StreamingContentRepository
    {
        private readonly List<StreamingContent> _repo = new List<StreamingContent>();
        //CRUD
        //Create
        public bool AddContentToRepository(StreamingContent content)
        {
            int startingCount = _repo.Count;
            _repo.Add(content);

            return _repo.Count > startingCount;
        }
        //Read
        //Get all
        public List<StreamingContent> GetContents()
        {
            return _repo;
        }
        //Get by title
        public StreamingContent GetContentByTitle(string title)
        {
            //Look through our collection
            foreach (StreamingContent target in _repo)
            {
                //If we find the title return it
                if (target.Title.ToLower() == title.ToLower())
                {
                    return target;
                }
            }

            //If we dont find it do something else
            return null;//--not best practice better would be throwing an exception. 

        }

        //Update
        public bool UpdateExistingContent(string originalTitle, StreamingContent newContent)
        {
            //Find the original content
            StreamingContent oldContent = GetContentByTitle(originalTitle);
            //If we find it update it
            if (oldContent != null)
            {
                oldContent.Title = newContent.Title;
                oldContent.Description = newContent.Description;
                oldContent.MaturityRating = newContent.MaturityRating;
                oldContent.StarRating = newContent.StarRating;
                oldContent.RunTimeInMinutes = newContent.RunTimeInMinutes;
                // oldContent.IsFamilyFriendly = newContent.IsFamilyFriendly;

                //Alternate way of updating
                // int index = _repo.IndexOf(oldContent);
                // _repo[index] = newContent;

                return true;
            }
            //if not say we couldnt
            return false;
        }

        //Delete
        public bool DeleteExistingContent(StreamingContent existingContent)
        {
            return _repo.Remove(existingContent);
        }

    }
}